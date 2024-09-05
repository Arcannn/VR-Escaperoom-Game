using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public bool isOpen = false;
    // controls the speed at which the door rotates when opening or closing
    public float rotationSpeed = 2f;
    // where it rotates to
    public Vector3 openRotation = new Vector3(0, -90, 0);

// the intial and the target rotation of the door. fields.
    private Quaternion _closedRotation;
    private Quaternion _targetRotation;

    void Start()
    {
        _closedRotation = transform.rotation;
        _targetRotation = Quaternion.Euler(openRotation);
    }

    void Update()
    {
        if (isOpen)
        {
          // rotate the object from it's current rotation to the target rotation, else the object (door) is closed
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _closedRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
