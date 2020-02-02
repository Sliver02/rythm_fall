using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    private SelectBand selectBand;
    public Material material;

    public float startScale, scaleMultiplier;

    private int bandSelected;

    void Start ()
    {
        //selectBand = GetComponent<SelectBand>();
        //bandSelected = selectBand.bandSelected;
        
        SelectBand myParent = transform.parent.GetComponent<SelectBand>();
        bandSelected = myParent.bandSelected;
        
        //print("2 " + bandSelected);
    }
	
	void FixedUpdate ()
    {
        if (MusicController.audioBandBuffer[bandSelected] > 0)
        {
            transform.localScale = new Vector3((MusicController.audioBandBuffer[bandSelected] * scaleMultiplier) + startScale,
                                            (MusicController.audioBandBuffer[bandSelected] * scaleMultiplier) + startScale,
                                            (MusicController.audioBandBuffer[bandSelected] * scaleMultiplier) + startScale);
        }
    }
}
