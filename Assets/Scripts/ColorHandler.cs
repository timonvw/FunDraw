using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void OnTriggerStay(Collider coll)
    {
       if(Utializer.Instance.drawEnabled == true)
        {
            switch (coll.gameObject.name)
            {
                case "pencil1":
                    Utializer.Instance.SetDrawColor(1);

                    break;
                case "pencil2":
                    Utializer.Instance.SetDrawColor(2);

                    break;
                case "pencil3":
                    Utializer.Instance.SetDrawColor(3);

                    break;
                case "pencil4":
                    Utializer.Instance.SetDrawColor(4);

                    break;
                case "pencilNew":
                    Utializer.Instance.SetDrawColor(0);

                    break;
            }
        }
    }
}
