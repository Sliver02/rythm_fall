using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BassColor
{
    public float red, green, blu;
}

[System.Serializable]
public class MidColor
{
    public float red, green, blu;
}

[System.Serializable]
public class HighColor
{
    public float red, green, blu;
}

public class ColorByAudioBands : MonoBehaviour
{
    private SelectBand selectBand;

    private int bandSelected;

    public Material material;

    public BassColor bassColor;
    public MidColor midColor;
    public HighColor highColor;

    private float redMultiplier, greenMultiplier, blueMultiplier;

    void Start ()
    {
        //selectBand = GetComponent<SelectBand>();
        //bandSelected = selectBand.bandSelected;
        
        SelectBand myParent = transform.parent.GetComponent<SelectBand>();
        bandSelected = myParent.bandSelected;
        
        material = GetComponent<MeshRenderer>().materials[0];
        
        //print("3 " + bandSelected);
    }
	
	void Update ()
    {
        if (bandSelected >= 0 && bandSelected <= 3)
        {
            redMultiplier = bassColor.red;
            greenMultiplier = bassColor.green;
            blueMultiplier = bassColor.blu;
        }
        if (bandSelected >= 4 && bandSelected <= 5)
        {
            redMultiplier = midColor.red;
            greenMultiplier = midColor.green;
            blueMultiplier = midColor.blu;
        }
        if (bandSelected >= 6 && bandSelected <= 7)
        {
            redMultiplier = highColor.red;
            greenMultiplier = highColor.green;
            blueMultiplier = highColor.blu;
        }

        Color color = new Color(0.85f - MusicController.audioBandBuffer[7] * redMultiplier / 255,
                                0.85f - MusicController.audioBandBuffer[4] * greenMultiplier / 255,
                                0.85f - MusicController.audioBandBuffer[0] * blueMultiplier / 255);
        
        material.SetColor("_Color", color);
    }
}
