using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class MInigameManager : MonoBehaviour
{
    #region Singleton
    private static MInigameManager _instance;
    public static MInigameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //uit nog niet nodig
                //GameObject go = new GameObject("MInigameManager");
                //go.AddComponent<MInigameManager>();
            }

            return _instance;
        }
    }
    #endregion

    private string dataPathColor = "../../../EV3_Data/minigame1data.txt";
    private string textColorData;
    private string[] colors = new string[8];
    [SerializeField]private string guessColor;
    private Byte[] niksText = new UTF8Encoding(true).GetBytes("nuthing");
    private bool startTimer = false;
    private string colorOld;
    private bool startGame = false;
    private float timerStart = 3;

    public float timeGuess = 10f;
    public int stages = 10;
    public float timer = 11;
    public int score = 0;
    public int stage = 1;
    public int stageReal = 0;

    public Text scoreText;
    public Text stageText;
    public Text scannedColorText;
    public Text timerText;
    public Text endScore;
    public Text endScore2;
    public Text startTimerText;
    public Text startTimerText2;

    public GameObject witSplash;
    public GameObject zwartSplash;
    public GameObject roodSplash;
    public GameObject geelSplash;
    public GameObject groenSplash;
    public GameObject turqSplash;
    public GameObject blauwSplash;
    public GameObject paarsSplash;
    public GameObject endMenu;
    public GameObject startCount;

    //delegate event callback kleur lijne eraser
    public delegate void DeleteSplashes();
    public static event DeleteSplashes deleteSplash;


    void Awake()
    {
        //start values
        _instance = this;
        System.IO.File.OpenWrite(dataPathColor).Write(niksText, 0, niksText.Length);
    }

    // Use this for initialization
    void Start ()
    {
        //kleuren in array zetten
        colors[0] = "rood";
        colors[1] = "geel";
        colors[2] = "groen";
        colors[3] = "turg";
        colors[4] = "blauw";
        colors[5] = "paars";
        colors[6] = "zwart";
        colors[7] = "wit";

        endMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score: " + score;
        stageText.text = "Kleur: " + stageReal + "/10";

        if (startGame == true)
        {
            switch (stage)
            {
                //stage 1
                case 1:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 2:
                    ColorHandler();
                    stageReal = 1;
                    break;
                //stage 2
                case 3:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 4:
                    ColorHandler();
                    stageReal = 2;
                    break;
                //stage 3
                case 5:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 6:
                    ColorHandler();
                    stageReal = 3;
                    break;
                //stage 4
                case 7:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 8:
                    ColorHandler();
                    stageReal = 4;
                    break;
                //stage 5
                case 9:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 10:
                    ColorHandler();
                    stageReal = 5;
                    break;
                //stage 6
                case 11:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 12:
                    ColorHandler();
                    stageReal = 6;
                    break;
                //stage 7
                case 13:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 14:
                    ColorHandler();
                    stageReal = 7;
                    break;
                //stage 8
                case 15:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 16:
                    ColorHandler();
                    stageReal = 8;
                    break;
                //stage 9
                case 17:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 18:
                    ColorHandler();
                    stageReal = 9;
                    break;
                //stage 10
                case 19:
                    PickRandomColor();
                    StartCoroutine("TimerStage");
                    stage++;
                    break;
                case 20:
                    ColorHandler();
                    stageReal = 10;
                    break;
                case 21:
                    //einde whoohoo
                    startTimer = false;
                    timer = 10;
                    endMenu.SetActive(true);
                    endScore.text = score.ToString();
                    endScore2.text = score.ToString();
                    break;
            }

            if (startTimer == true)
            {
                timer -= Time.deltaTime;
                timerText.text = timer.ToString("0");
            }
        }
        else
        {
            StartCoroutine(TimerStart());
            timerStart -= Time.deltaTime;

            if(timerStart < 0.5f)
            {
                startTimerText.text = "Go !";
                startTimerText2.text = "Go !";
            }
            else
            {
                startTimerText.text = timerStart.ToString("0");
                startTimerText2.text = timerStart.ToString("0");
            }
        }
    }

    private void ColorHandler()
    {
        //rgb code uitlezen file
        textColorData = System.IO.File.ReadAllText(dataPathColor);
        
        //string knippen en waarde apart zetten in een array
        string theText = textColorData;
        string[] splitString = theText.Split(new string[] { "," }, StringSplitOptions.None);

        scannedColorText.text = "" + splitString[0];

        if (splitString[0] == guessColor)
        {
            //goed woohoo
            StopTime(1);
            Debug.Log("woohoo goed");
        }
        else
        {
            //fout
            Debug.Log("fout");
        }
     
    }

    //random color functie
    private void PickRandomColor()
    {
        int randomInt = UnityEngine.Random.Range(0,8);

        guessColor = colors[randomInt];

        while(guessColor == colorOld)
        {
            randomInt = UnityEngine.Random.Range(0, 8);

            guessColor = colors[randomInt];

            Debug.Log("NIEUW KLEUR");
        }

        colorOld = guessColor;

        switch (guessColor)
        {
            case "wit":
                GameObject splashW = Instantiate(witSplash) as GameObject;
                break;
            case "zwart":
                GameObject splashZ = Instantiate(zwartSplash) as GameObject;
                break;
            case "rood":
                GameObject splashR = Instantiate(roodSplash) as GameObject;
                break;
            case "geel":
                GameObject splashG = Instantiate(geelSplash) as GameObject;
                break;
            case "groen":
                GameObject splashGr = Instantiate(groenSplash) as GameObject;
                break;
            case "turg":
                GameObject splashT = Instantiate(turqSplash) as GameObject;
                break;
            case "blauw":
                GameObject splashB = Instantiate(blauwSplash) as GameObject;
                break;
            case "paars":
                GameObject splashP = Instantiate(paarsSplash) as GameObject;
                break;
        }
        //cameraShake.Instance.Shake(1f, 0.1f);
    }


    //timer IEnumerator
    private IEnumerator TimerStage()
    {
        timer = 11;
        startTimer = true;
        yield return new WaitForSeconds(11);
        StopTime(0);
        startTimer = false;
    }

    private IEnumerator TimerStart()
    {
        yield return new WaitForSeconds(3);
        startGame = true;
        startCount.SetActive(false);
    }

    //stop tijd functie
    private void StopTime(int correct)
    {
        StopCoroutine("TimerStage");
        DeleteOldSplashes();

        if (correct == 1)
        {
            score += (int)((1 + timer) * 15);
            MusicManager.Instance.PlayShotCorrect();
        }
        else
        {
            MusicManager.Instance.PlayShotWrong();
        }

        stage++;
    }

    //functie event callback alle lijnen ook mee kleuren achtergrond
    private void DeleteOldSplashes()
    {
        if (deleteSplash != null)
        {
            deleteSplash();
        }
    }

    //naar minigame 1
    public void ToMinigame1()
    {
        SceneManager.LoadScene("Minigame1");
    }

    //naar minigame 1
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
