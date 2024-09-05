using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDinputManager : MonoBehaviour
{
  [SerializeField] GameObject VRRig;
  [SerializeField] GameObject FPSRig;

    // Start is called before the first frame update
    void Start()
    {
        if(XRSettings.isDeviceActive || XRSettings.loadedDeviceName == "OpenXR Display")
        {
          Debug.Log("VR rig active using device: " + XRSettings.loadedDeviceName);
          FPSRig.SetActive(false);

        }
        else
        {
          Debug.Log("using FPS rig");
          VRRig.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
