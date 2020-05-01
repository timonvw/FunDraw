using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour 
{
    #region Singleton
    private static MusicManager _instance;
    public static MusicManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //GameObject go = new GameObject(MusicManager");
                //go.AddComponent<MusicManager>();
            }

            return _instance;
        }
    }
    #endregion

    [Header("Mixers")]
    public AudioMixer masterMixer;

    [Header("Audio sources")]
    public AudioSource Muziek;
    public AudioSource Effecten;
    public AudioSource EffectenLoop;
    public AudioSource Jetpack;
    public AudioSource Jetpack2;

    [Header("Audio clips")]
    public AudioClip mainMuziek;

    //effects
    public AudioClip sfxDeurOpen;
    public AudioClip sfxSpikeActive;
    public AudioClip sfxCorrectSound;
    public AudioClip sfxWrongSound;


    public float muziekVolume { get; set; }
	public float effectVolume { get; set; }
    private bool playOnce = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //start values
        _instance = this;
        muziekVolume = 1;
        effectVolume = 1;
    }

    public void stopAll()
	{
        Muziek.Stop();
        Effecten.Stop();
        EffectenLoop.Stop();
        Jetpack.Stop();
        Jetpack2.Stop();
    }

    public void PauzeMusic()
    {
        Muziek.Pause();
        Effecten.Pause();
        EffectenLoop.Pause();
        Jetpack.Pause();
        Jetpack2.Pause();
    }

    public void UnPauzeMusic()
    {
        Muziek.UnPause();
        Effecten.UnPause();
        EffectenLoop.UnPause();
        Jetpack.UnPause();
        Jetpack2.UnPause();
    }

    #region One shots (effects) functions
    //Play one shots (effects)
    public void PlayShotDoorOpen()
    {
        Effecten.PlayOneShot(sfxDeurOpen, 1f);
    }

    public void PlayShotCorrect()
    {
        Effecten.PlayOneShot(sfxCorrectSound, 1f);
    }

    public void PlayShotWrong()
    {
        Effecten.PlayOneShot(sfxWrongSound, 1f);
    }

    #endregion

    #region Normal sounds functions
    //normal play sounds
    public void PlayJetpackSound()
    {
        Jetpack.Play();
    }

    public void PlaySpikeActiveSound()
    {
        if(playOnce == false)
        {
            EffectenLoop.clip = sfxSpikeActive;
            EffectenLoop.Play();
            playOnce = true;
        }
    }

    #endregion

    #region Stop sounds
    //stop sounds
    #endregion

    #region set functions
    //set functions
    public void SetMasterLevelLVl(float masterLvl)
    {
        masterMixer.SetFloat("masterVolume", masterLvl);
		masterMixer.SetFloat("sfxVolume", masterLvl);
		masterMixer.SetFloat("musicVolume", masterLvl);
    }

    public void SetSfxLVl(float sfxLvl)
	{ 
		masterMixer.SetFloat("sfxVolume", sfxLvl);
	} 

	public void SetMusicLVl(float musicLvl)
	{ 
		masterMixer.SetFloat("musicVolume", musicLvl);
	}

    #endregion
}