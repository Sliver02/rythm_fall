using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBand : MonoBehaviour {

    public int[] bandsArray;

    [HideInInspector]
    public int bandSelected;

    void Start ()
    {
        bandSelected = bandsArray[Random.Range(0, bandsArray.Length)];
        //print("1 " + bandSelected);
    }
}
