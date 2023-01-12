using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell_interraction : MonoBehaviour
{
    [SerializeField]
    GameObject bellVolumeUp;

    [SerializeField]
    GameObject bellVolumeDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mallet")
        {
            GetComponent<AudioSource>().Play(0);

            GetComponentInParent<Animator>().SetBool("ring", true);

            if(bellVolumeDown == null && bellVolumeUp != null)
            {
                SoundManager.Instance.VolumeUp();
            } else if (bellVolumeUp == null && bellVolumeDown != null)
            {
                SoundManager.Instance.VolumeDown();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mallet")
        {
            GetComponentInParent<Animator>().SetBool("ring", false);
        }
    }

}
