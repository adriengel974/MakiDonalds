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
            GameObject go = Instantiate(dish, transform.position, other.transform.rotation);
            go.transform.localScale *= 2;
        }
    }
}
