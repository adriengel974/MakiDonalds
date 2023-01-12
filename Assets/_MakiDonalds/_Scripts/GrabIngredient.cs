using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabIngredient : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(ObjectIsGrabbed);
        grabInteractable.selectExited.AddListener(ObjectIsNotGrabbed);

        GetComponent<Rigidbody>().isKinematic = true;

    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveAllListeners();
        grabInteractable.selectExited.RemoveAllListeners();
    }

    public void ObjectIsGrabbed(SelectEnterEventArgs args)
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

    void ObjectIsNotGrabbed(SelectExitEventArgs args)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
