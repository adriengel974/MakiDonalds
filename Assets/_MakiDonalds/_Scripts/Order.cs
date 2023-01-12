using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Order : MonoBehaviour
{
    [SerializeField]
    GameObject _order;

    [SerializeField]
    GameObject _orderBlueprint;

    [SerializeField]
    int _orderRecipe = 0;

    XRGrabInteractable _orderInteractable;

    public int OrderID = 0;

    public int GetOrderRecipe()
    {
        return _orderRecipe;
    }

    private void Awake()
    {
        _orderBlueprint.SetActive(false);

        _orderInteractable = _order.GetComponent<XRGrabInteractable>();

        _orderInteractable.selectEntered.AddListener(OrderIsGrabbed);
        _orderInteractable.selectExited.AddListener(OrderIsNotGrabbed);
    }

    private void OnDisable()
    {
        _orderInteractable.selectEntered.RemoveAllListeners();
        _orderInteractable.selectExited.RemoveAllListeners();
    }

    public void OrderIsGrabbed(SelectEnterEventArgs args)
    {
        _orderBlueprint.SetActive(true);
    }

    void OrderIsNotGrabbed(SelectExitEventArgs args)
    {
        _orderBlueprint.SetActive(false);

        _orderInteractable.transform.position = transform.position;
        _orderInteractable.transform.rotation = transform.rotation;
    }
}
