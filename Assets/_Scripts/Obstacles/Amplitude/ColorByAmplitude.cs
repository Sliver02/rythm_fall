using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BandForColor
{
    public int red, green, blu;
}

[System.Serializable]
public class AmplitudeColor
{
    public float red, green, blu;
}

public class ColorByAmplitude : MonoBehaviour
{
    public Material material;
    public BandForColor bandForColor;
    public AmplitudeColor amplitudeColor;

    void Start ()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }
	
	void Update ()
    {
        Color color = new Color(0.85f - MusicController.audioBandBuffer[bandForColor.red] * amplitudeColor.red / 255,
                                0.85f - MusicController.audioBandBuffer[bandForColor.green] * amplitudeColor.green / 255,
                                0.85f - MusicController.audioBandBuffer[bandForColor.blu] * amplitudeColor.blu / 255);

        material.SetColor("_Color", color);
    }
}
