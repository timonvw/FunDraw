using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawScript : MonoBehaviour
{
    //vars
    public GameObject trailPrefab;
    private GameObject thisTrail;
    private Vector3 startPos;
    private Plane objPlane;

	// Use this for initialization
	void Start ()
    {
        //plane om op te tekenen maken, facing de camera
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //als eerst scherm aanraakt of klikt
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            //maak een trail
            thisTrail = (GameObject)Instantiate(trailPrefab, this.transform.position, Quaternion.identity);
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //var
            float rayDistance;

            //kijken waar de muis de plane raakt en die positie ophalen en opslaan
            if(objPlane.Raycast(mRay, out rayDistance))
            {
                startPos = mRay.GetPoint(rayDistance);
            }
        }
        //terwijl je muis begweegt de trail meebewegen
        else if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            float rayDistance;

            if(objPlane.Raycast(mRay, out rayDistance))
            {
                thisTrail.transform.position = mRay.GetPoint(rayDistance);
            }
        }
        //als er te weinig ruimte is tussen de begin punt lijn en einde dan de trail verwijderen
        else if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            if(Vector3.Distance(thisTrail.transform.position, startPos) < 0.1)
            {
                //lijn destroyen als je op het zelfde punt eindigd, uitgezet moet nog verbeterd worden
                //Destroy(thisTrail);
            }
        }
	}
}
