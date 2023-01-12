using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickToBlueprint : MonoBehaviour
{
    [SerializeField]
    GameObject _originalPrefab;

    [SerializeField]
    GameObject _Blueprint;

    XRGrabInteractable _orderInteractable;

    private void Awake()
    {
        _Blueprint.SetActive(false);

        _orderInteractable = _originalPrefab.GetComponent<XRGrabInteractable>();

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
        _Blueprint.SetActive(true);
    }

    void OrderIsNotGrabbed(SelectExitEventArgs args)
    {
        _Blueprint.SetActive(false);

        _orderInteractable.transform.position = transform.position;
        _orderInteractable.transform.rotation = transform.rotation;
    }
}
