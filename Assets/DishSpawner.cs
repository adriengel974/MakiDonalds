using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject dish;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sdfvf");
        if (other.gameObject.tag == "Dish")
        {
            Instantiate(dish, transform.position, transform.rotation);
        }
    }
}
