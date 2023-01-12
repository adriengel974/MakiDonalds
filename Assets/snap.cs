using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class snap : MonoBehaviour
{
    private bool grab = false;
    private bool bowl = false;
    [SerializeField] private GameObject AttachPointHand;
    [SerializeField] private GameObject AttachPointBowl;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Hand")
    //    {
    //        grab = true;
    //    }

    //    if (other.gameObject.tag == "Bowl")
    //    {
    //        bowl = true;
    //    }

    //    if (bowl = true && grab == false)
    //    {
    //        AttachPointBowl.SetActive(true);
    //        AttachPointHand.SetActive(false);

    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if (bowl = true && grab == false)
    //    {
    //        GetComponent<XRGrabInteractable>().attachTransform = AttachPointBowl.transform;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Hand")
    //    {
    //        grab = false;
    //    }
    //    if (other.gameObject.tag == "Bowl")
    //    {
    //        bowl = false;
    //    }
    //    //if (bowl == false)
    //    //{
    //    //    AttachPointBowl.SetActive(false);
    //    //    AttachPointHand.SetActive(true);
    //    //}
    //}
    XRGrabInteractable grabInteractable;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(ObjectIsGrabbed);
        grabInteractable.selectExited.AddListener(ObjectIsNotGrabbed);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveAllListeners();
        grabInteractable.selectExited.RemoveAllListeners();
    }

    public void ObjectIsGrabbed(SelectEnterEventArgs args)
    {
        grabInteractable.attachTransform = AttachPointHand.transform;
    }

    void ObjectIsNotGrabbed(SelectExitEventArgs args)
    {
        grabInteractable.attachTransform = AttachPointBowl.transform;
    }
}