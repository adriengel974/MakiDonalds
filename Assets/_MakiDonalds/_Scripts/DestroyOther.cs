using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "MalletGrab" ||
           other.gameObject.tag != "mallet"     ||
           other.gameObject.tag != "Order")
        Destroy(other.gameObject);
    }
}
