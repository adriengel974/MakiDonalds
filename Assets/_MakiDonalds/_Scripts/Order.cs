using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField]
    GameObject _order;

    [SerializeField]
    GameObject _orderBlueprint;

    private void Awake()
    {
        _orderBlueprint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO move to Grabb and UnGrabb
        if(_order.transform.position != _orderBlueprint.transform.position)
            _orderBlueprint.SetActive(true);
        else
            _orderBlueprint.SetActive(false);
    }
}
