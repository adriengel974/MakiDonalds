using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mallet")
        {
            transform.GetChild(0).gameObject.SetActive(false);
           
            GetComponent<AudioSource>().Play(0); 
            
            GetComponentInParent<Animator>().SetBool("Hit",true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mallet")
        {
            

            GetComponentInParent<Animator>().SetBool("Hit", false);

        }
    }

}