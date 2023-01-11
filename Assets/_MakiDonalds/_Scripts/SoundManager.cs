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
        audio.volume = 0.5f;
    }

    public void VolumeUp()
    {
        if(audio.volume <= 1) audio.volume += 0.1f;
    }

    public void VolumeDown()
    {
        if (audio.volume >= 0) audio.volume -= 0.1f;
    }
}

