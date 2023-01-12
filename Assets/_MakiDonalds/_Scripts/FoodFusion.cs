using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFusion : MonoBehaviour
{
    [SerializeField]
    GameObject[] foodResult;

    int receipeValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seaweed")
        {
            receipeValue += 8;
            Destroy(other.gameObject);

            GameObject go = Instantiate(foodResult[0], transform.position, transform.rotation);
            go.GetComponent<FoodValue>().foodValue = receipeValue;

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Egg")
        {
            receipeValue += 2;
            Destroy(other.gameObject);

            GameObject go = Instantiate(foodResult[1], transform.position, transform.rotation);
            go.GetComponent<FoodValue>().foodValue = receipeValue;

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Fish")
        {
            receipeValue += 4;
            Destroy(other.gameObject);

            GameObject go = Instantiate(foodResult[2], transform.position, transform.rotation);
            go.GetComponent<FoodValue>().foodValue = receipeValue;

            Destroy(gameObject);
        }
    }

    public int GetReceipeValue()
    {
        return receipeValue;
    }
}
