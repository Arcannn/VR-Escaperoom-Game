using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController1 : MonoBehaviour
{
  // same comments as DoorController script. But this is position instead of rotation. The position, uses slide, and goes up.
  // script for the Birds door.
  public bool isOpen = false;
  public float slideSpeed = 2f;
  public float slideDistance = 3.0f;

  private Vector3 _closedPosition;
  private Vector3 _targetPosition;
  private Vector3 _currentVelocity;

  void Start()
  {
      _closedPosition = transform.position;
      _targetPosition = _closedPosition + new Vector3(0, slideDistance, 0);
  }

  void Update()
  {
      Vector3 targetPosition = isOpen ? _targetPosition : _closedPosition;
      transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, slideSpeed);
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
