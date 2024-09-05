using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightSwitch : MonoBehaviour
{
  // the point lights that will be toggled on or off.
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

// referencing the object that allows interaction.
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
      // get the interaction component attached to the game object.
        grabInteractable = GetComponent<XRGrabInteractable>();
        // add listener to the activated event, which triggers when the game object is interacted with.
        grabInteractable.activated.AddListener(args => ToggleLights());
    }

    private void OnDestroy()
    {
      // remove the listener from the activated event when the gameobject is interacted with.
        grabInteractable.activated.RemoveListener(args => ToggleLights());
    }

    private void ToggleLights()
    {
      // toggles the light, when it is called.
        light1.SetActive(!light1.activeInHierarchy);
        light2.SetActive(!light2.activeInHierarchy);
        light3.SetActive(!light3.activeInHierarchy);
    }

}
