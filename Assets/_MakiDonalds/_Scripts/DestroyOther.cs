using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MalletGrab" ||
           other.gameObject.tag == "Mallet"     ||
           other.gameObject.tag == "Order" ||
           other.gameObject.tag == "Hand" ||
           other.gameObject.tag == "MainCamera")
        {
            Debug.Log("Can't destroy this object: " + other.gameObject.tag);
        } else
        {
            Debug.Log("Destroy this object: " + other.gameObject.tag);
            Destroy(other.gameObject);
        }
        
    }
}