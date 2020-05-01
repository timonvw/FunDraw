using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Utializer : MonoBehaviour
{
    #region Singleton
    private static Utializer _instance;
    public static Utializer Instance
    {
        get
        {
            if (_instance == null)
            {
                //uit nog niet nodig
                //GameObject go = new GameObject("Utializer");
                //go.AddComponent<Utializer>();
            }

            return _instance;
        }
    }
    #endregion

    //vars Color
    private string dataPathColor = "../../../EV3_Data/colordata.txt";
    private string textColorData;
    private Color scannedColor;
    private Color scannedColorOld;
    private int counterArrayColor = 0;
    private Color[] colorOldArray;
    private bool colorOldBool = false;

    //get set vars
    public Color DrawColor { get; set; }
    public int layerDrawedLines { get; set; }
    public float lineWidth { get; set; }
    public bool drawEnabled { get; set; }

    //vars Motor
    private string dataPathMotor = "../../../EV3_Data/motordata.txt";
    [SerializeField]private string textMotorData;

    //get set properties
    [SerializeField]public int counter { get; set; }

    //game objects
    public GameObject pencil;
    public GameObject pencil2;
    public GameObject pencilOld1;
    public GameObject pencilOld2;
    public GameObject pencilOld3;
    public GameObject pencilOld4;
    public GameObject lineRenderer;

    void Awake()
    {
        //start values
        _instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        //start waardes
        colorOldArray = new Color[7];
        layerDrawedLines = 0;
        SetDrawColor(0);
        lineWidth = 0.2f;

        //start waardes kleuren en kleuren panel goed zetten
        for (int i = 0; i < 4; i++)
        {
            colorOldArray[i] = Color.white;
        }

        pencilOld1.GetComponent<Renderer>().material.color = colorOldArray[0];
        pencilOld2.GetComponent<Renderer>().material.color = colorOldArray[1];
        pencilOld3.GetComponent<Renderer>().material.color = colorOldArray[2];
        pencilOld4.GetComponent<Renderer>().material.color = colorOldArray[3];

        scannedColor = Color.white;
        pencil.GetComponent<Renderer>().material.color = scannedColor;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ColorHandler();
        MotorHandler();
    }

    public void ColorHandler()
    {
        //rgb code uitlezen file
        textColorData = System.IO.File.ReadAllText(dataPathColor);
        
        //string knippen en waarde apart zetten in een array
        string theText = textColorData;
        string[] splitString = theText.Split(new string[] { "," }, StringSplitOptions.None);

        //Debug.Log("" + splitString[0] + "," + splitString[1] + "," + splitString[2]);

        if(splitString[0] != "false")
        {
            //sla op en zet om in roob blauw groen 0 tot 1
            scannedColor = new Color(float.Parse(splitString[0]) / 255, float.Parse(splitString[1]) / 255, (float.Parse(splitString[2]) + 20) / 255);
            pencil.GetComponent<Renderer>().material.color = scannedColor;
            //Debug.Log(scannedColor);

            colorOldBool = true;
        }
        else
        {
            if(colorOldBool == true)
            {
                OldColorHandler(scannedColor);
            }
        }

    }

    public void OldColorHandler(Color oldColor)
    {
        colorOldArray[counterArrayColor] = oldColor;

        if (counterArrayColor > 2)
        {
            counterArrayColor = 0;
        }
        else
        {
            counterArrayColor++;
        }

        pencilOld1.GetComponent<Renderer>().material.color = colorOldArray[0];
        pencilOld2.GetComponent<Renderer>().material.color = colorOldArray[1];
        pencilOld3.GetComponent<Renderer>().material.color = colorOldArray[2];
        pencilOld4.GetComponent<Renderer>().material.color = colorOldArray[3];
        
        colorOldBool = false;
    }

    public void MotorHandler()
    {
        //graden uitlezen file
        textMotorData = System.IO.File.ReadAllText(dataPathMotor);

        //Debug.Log("" + textMotorData);

        //graden in pencil 2 toeveogen
        pencil2.transform.eulerAngles = new Vector3(0, 0, -float.Parse(textMotorData));
    }

    public void SetDrawColor(int colorIndex)
    {
        switch (colorIndex)
        {
            case 0:
                DrawColor = scannedColor;
                //Debug.Log(scannedColor);
                break;
            case 1:
                DrawColor = colorOldArray[0];
                //Debug.Log(colorOldArray[0]);
                break;
            case 2:
                DrawColor = colorOldArray[1];
                //Debug.Log(colorOldArray[1]);
                break;
            case 3:
                DrawColor = colorOldArray[2];
                //Debug.Log(colorOldArray[2]);
                break;
            case 4:
                DrawColor = colorOldArray[3];
                //Debug.Log(colorOldArray[3]);
                break;
        }

        //lineRenderer.GetComponent<LineRenderer>().materials[0].color = DrawColor;
    }
}
