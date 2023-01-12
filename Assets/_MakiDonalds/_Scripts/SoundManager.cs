using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Debug.Log(audio.volume);
        audio.volume = 0.4f;
        Debug.Log(audio.volume);
    }

    public void VolumeUp()
    {
        if(audio.volume <= 1.0f)
        {
            audio.volume += 0.2f;
            Debug.Log(audio.volume);
        }
           
    }

    public void VolumeDown()
    {
        if (audio.volume >= 0.0f)
        {
            audio.volume -= 0.2f;
            Debug.Log(audio.volume);
        }
    }
}

