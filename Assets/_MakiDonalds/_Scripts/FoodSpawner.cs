using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject food;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
            Instantiate(food,other.transform);
        //food.transform.parent = other.transform; 
    }
}
