using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateFood : MonoBehaviour
{
    public static ValidateFood Instance;

    GameObject bowl;
    GameObject receipe;
    GameObject order;

    int receipeValue;

    public int score = 0;

    private void Awake()
    {

        if (Instance == null)
            Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dish")
        {
            bowl = other.gameObject;
        }

        if(other.gameObject.tag == "Receipe")
        {
            receipeValue = other.gameObject.GetComponent<FoodValue>().foodValue;
            receipe = other.gameObject;
            Debug.Log("Recipe " + receipeValue);
        }

        if(other.gameObject.tag == "Order")
        {
            order = other.gameObject;
            int orderValue = other.gameObject.GetComponent<OrderValue>().orderValue;
            int orderId = other.gameObject.GetComponent<OrderValue>().orderId;
            Debug.Log("Order " + orderValue);   

            if (orderValue == receipeValue)
            {
                Destroy(bowl);
                Destroy(receipe);
                OrderManager.Instance.DespawnOrder(orderId);
                Destroy(order);

                score += 1;
            }
        }
    }
}
