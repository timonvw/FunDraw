using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    //camera
    public Camera cameraGame;

    //ui objects
    public Slider sliderDrawSize;
    public Text sliderDrawSizeText;
    public Button drawButton;
    public Button eraseButton;

    //spirtes
    public Sprite drawSelected;
    public Sprite draw;
    public Sprite eraseSelected;
    public Sprite erase;

    //delegate event callback kleur lijne eraser
    public delegate void ChangeEraserLineColor(Color color);
    public static event ChangeEraserLineColor onBackgroundChange;
  
	// Use this for initialization
	void Start ()
    {
        DrawLine();
    }

    //background kleur verander knoppen functie
    public void ChangeBackground(string colorString)
    {
        //string knippen en waarde apart zetten in een array
        string theText = colorString;
        string[] splitString = theText.Split(new string[] { "," }, StringSplitOptions.None);

        //camera achtergrond veranderen
        cameraGame.backgroundColor = new Color(float.Parse(splitString[0]) / 255, float.Parse(splitString[1]) / 255, (float.Parse(splitString[2])  / 255));

        //alle erased lijnen ook mee veranderen
        ChangeColorErasedLines();
    }

    //terug naar menu funcite
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //functie set draw size
    public void SetDrawSize()
    {
        Utializer.Instance.lineWidth = sliderDrawSize.value;
        sliderDrawSizeText.text = "Kwast groote: " + sliderDrawSize.value.ToString("0.00");
    }

    //teken functie
    public void DrawLine()
    {
        //sprites veranderen
        drawButton.GetComponent<Image>().sprite = drawSelected;
        eraseButton.GetComponent<Image>().sprite = erase;

        Utializer.Instance.drawEnabled = true;
    }

    //erase funcite
    public void EraseLine()
    {
        //sprites veranderen
        drawButton.GetComponent<Image>().sprite = draw;
        eraseButton.GetComponent<Image>().sprite = eraseSelected;

        Utializer.Instance.drawEnabled = false;

        //draw kleur verandere naar achtergrond kleur
        Utializer.Instance.DrawColor = cameraGame.backgroundColor;
    }

    //functie event callback alle lijnen ook mee kleuren achtergrond
    private void ChangeColorErasedLines()
    {
        if(onBackgroundChange != null)
        {
            onBackgroundChange(cameraGame.backgroundColor);
        }
    }

}
