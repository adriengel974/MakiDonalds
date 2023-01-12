using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateFood : MonoBehaviour
{

    GameObject receipe;
    GameObject order;

    int receipeValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Receipe")
        {
            receipeValue = other.gameObject.GetComponent<FoodValue>().foodValue;
            receipe = other.gameObject;
        }

        if(other.gameObject.tag == "Order")
        {
            order = other.gameObject;
            int orderValue = other.gameObject.GetComponentInParent<Order>().GetOrderRecipe();

            if (orderValue == receipeValue)
            {
                Destroy(receipe);
                other.gameObject.GetComponentInParent<Order>().DespawnOrder();
            }
        }
    }
}
