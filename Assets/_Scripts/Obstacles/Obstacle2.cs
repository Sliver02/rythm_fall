using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    public float startScale, scaleMultiplier;
    public bool reverse;

    void FixedUpdate()
    {
        if (MusicController.amplitudeBuffer > 0)
        {
            if (reverse)
            {
                transform.localScale = new Vector3(startScale * scaleMultiplier - ((MusicController.amplitudeBuffer * scaleMultiplier) + startScale),
                                                   startScale * scaleMultiplier - ((MusicController.amplitudeBuffer * scaleMultiplier) + startScale),
                                                   startScale * scaleMultiplier - ((MusicController.amplitudeBuffer * scaleMultiplier) + startScale));
            }
            else
            {
                transform.localScale = new Vector3((MusicController.amplitudeBuffer * scaleMultiplier) + startScale,
                                                   (MusicController.amplitudeBuffer * scaleMultiplier) + startScale,
                                                   (MusicController.amplitudeBuffer * scaleMultiplier) + startScale);
            }
        }
    }
}