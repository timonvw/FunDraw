using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    private bool erasedLine;

	// Use this for initialization
	void Start ()
    {
        //kijk als deze lijn word getekend of het met de erase tool is gedaan
        if(Utializer.Instance.drawEnabled == false)
        {
            //toevoegen aan event callback
            UIHandler.onBackgroundChange += ColorChange;
        }

        //huidige kleur mee tekenen
        this.GetComponent<TrailRenderer>().materials[0].color = Utializer.Instance.DrawColor;

        //layer order steeds omhoog doen zodat alle trails over elkaar zitten
        this.GetComponent<TrailRenderer>().sortingOrder = Utializer.Instance.layerDrawedLines;
        Utializer.Instance.layerDrawedLines++;

        //huidige dikte pakken
        this.GetComponent<TrailRenderer>().widthMultiplier = Utializer.Instance.lineWidth;
    }

    //kleur veranderen als achtergrond kleur word veranderd
    private void ColorChange(Color color)
    {
        this.GetComponent<TrailRenderer>().materials[0].color = color;
    }

    private void OnDisable()
    {
        UIHandler.onBackgroundChange -= ColorChange;
    }
}
