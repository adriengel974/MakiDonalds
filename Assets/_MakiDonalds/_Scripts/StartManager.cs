using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    GameObject[] foods;
    public bool gameStartStatus;

    private void Awake()
    {
        gameStartStatus = false;
        foods = GameObject.FindGameObjectsWithTag("Food");
        for(int i = 0; i < foods.Length; i++)
        {
            foods[i].SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mallet" && !gameStartStatus)
        {
            transform.GetChild(0).gameObject.SetActive(false);
           
            GetComponent<AudioSource>().Play(0); 
            
            GetComponentInParent<Animator>().SetBool("Hit",true);


            for (int i = 0; i < foods.Length; i++)
            {
                foods[i].SetActive(true);
            }

            gameStartStatus = true;
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
