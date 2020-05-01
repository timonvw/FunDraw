using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject optiesMenu;
    public GameObject gamesMenu;
    public GameObject creditsMenu;
    public GameObject logoAndName;

	// Use this for initialization
	void Start ()
    {
        //start active van objecten
        BackToStart();
    }

    //games menu openen
    public void ToGamesMenu()
    {
        startMenu.SetActive(false);
        optiesMenu.SetActive(false);
        gamesMenu.SetActive(true);
    }

    //optie menu openen
    public void ToOptieMenu()
    {
        startMenu.SetActive(false);
        optiesMenu.SetActive(true);
        gamesMenu.SetActive(false);
    }

    //terug naar start
    public void BackToStart()
    {
        startMenu.SetActive(true);
        optiesMenu.SetActive(false);
        gamesMenu.SetActive(false);
        creditsMenu.SetActive(false);
        logoAndName.SetActive(true);
    }

    //naar credits scene
    public void ToCredits()
    {
        startMenu.SetActive(false);
        optiesMenu.SetActive(false);
        gamesMenu.SetActive(false);
        creditsMenu.SetActive(true);
        logoAndName.SetActive(false);
    }

    //game aflsuiten
    public void QuitGame()
    {
        Application.Quit();
    }

    //naar vrij tekenen game
    public void ToCasual()
    {
        SceneManager.LoadScene("Casual_mode");
    }

    //naar minigame 1
    public void ToMinigame1()
    {
        SceneManager.LoadScene("Minigame1");
    }
}
