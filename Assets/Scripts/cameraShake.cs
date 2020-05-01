using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    #region Singleton
    private static cameraShake _instance;
    public static cameraShake Instance
    {
        get
        {
            if (_instance == null)
            {
                //uit nog niet nodig
                //GameObject go = new GameObject("cameraShake");
                //go.AddComponent<cameraShake>();
            }

            return _instance;
        }
    }
    #endregion

    private Vector3 originalPos;

    void Awake()
    {
        //start values
        _instance = this;
    }


    // Use this for initialization
    void Start ()
    {
        originalPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Shake(float duration, float amount)
    {
        StopAllCoroutines();
        StartCoroutine(cShake(duration, amount));
    }

    private IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
