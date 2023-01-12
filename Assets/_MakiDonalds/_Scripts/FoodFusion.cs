using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFusion : MonoBehaviour
{
    [SerializeField]
    GameObject[] foodResult;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seaweed")
        {

            Destroy(other.gameObject);
            Debug.Log(other.gameObject);

            Instantiate(foodResult[0], transform.position, transform.rotation);

            

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Egg")
        {
            Instantiate(foodResult[1], transform.position, transform.rotation);

            Destroy(other.gameObject);

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Fish")
        {
            Instantiate(foodResult[2], transform.position, transform.rotation);

            Destroy(other.gameObject);

            Destroy(gameObject);
        }
    }
}
