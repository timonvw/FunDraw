using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public GameObject namenText;
    public Vector3 startPos;

	// Use this for initialization
	void Start ()
    {
        //begin pos opslaan 
        startPos = new Vector3(namenText.transform.position.x, namenText.transform.position.y, namenText.transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //als pos namenText groter is dan y 53 terug zetten op oude pos
        if(namenText.transform.position.y > 53f)
        {
            namenText.transform.position = startPos;
        }
        else
        {
            //naar boven laten gaan
            namenText.transform.Translate(0, 10 * Time.deltaTime, 0);
        }
	}
}
