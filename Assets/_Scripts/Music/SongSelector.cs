using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SongSelector : MonoBehaviour
{
    public AudioClip[] clips;

    public int songIndex;

    private void Start()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        
        //Loading the items into the array
        clips = Resources.LoadAll<AudioClip>("Music");
    }
}