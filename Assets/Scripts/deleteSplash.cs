using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSplash : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //toevoegen aan event callback
        MInigameManager.deleteSplash += Delete;
    }

    private void Delete()
    {
        Destroy(this.gameObject);
    }

    private void OnDisable()
    {
        MInigameManager.deleteSplash -= Delete;
    }
}
