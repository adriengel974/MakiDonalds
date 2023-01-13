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

    XRGrabInteractable _Interactable;

    private void Awake()
    {
        _Blueprint.SetActive(false);

        _Interactable = _originalPrefab.GetComponent<XRGrabInteractable>();

        _Interactable.selectEntered.AddListener(OrderIsGrabbed);
        _Interactable.selectExited.AddListener(OrderIsNotGrabbed);
    }

    private void OnDisable()
    {
        _Interactable.selectEntered.RemoveAllListeners();
        _Interactable.selectExited.RemoveAllListeners();
    }

    public void OrderIsGrabbed(SelectEnterEventArgs args)
    {
        _Blueprint.SetActive(true);
    }

    void OrderIsNotGrabbed(SelectExitEventArgs args)
    {
        _Blueprint.SetActive(false);

        _Interactable.transform.position = transform.position;
        _Interactable.transform.rotation = transform.rotation;
    }
}
