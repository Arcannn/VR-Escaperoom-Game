using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerArea : XRBaseInteractor
{
  // declaring the fields for events to happen.
  private IXRInteractable currentInteractable = null;
  public AudioSource successSound;
  public AudioSource failedSound;


  protected override void Start()
  {
    // assign the audio source for success sound on gameobject.
      successSound = GetComponent<AudioSource>();

  }

// when the collider hits the trigger, this happens...
  private void OnTriggerEnter(Collider other)
  {
    if (SetInteractable(other))
    {
      // correct sound plays.
        successSound.Play();
    }
    else
    {
      // if not the correct object, this sound plays.
        failedSound.Play();
    }
  }

  private bool SetInteractable(Collider other)
  {
    // interactable object associated with the collider
    if(TryGetInteractable(other, out IXRInteractable interactable))
    {
      // set it to the new interactable object and return true if the object is not interactable.
      if(currentInteractable == null)
      {
        currentInteractable = interactable;
        return true;
      }
    }
    return false;
  }

// clears the interaction that happened, the object goes out the trigger.
  private void OnTriggerExit(Collider other)
  {
    ClearInteractable(other);
  }

  private void ClearInteractable(Collider other)
  {
    if(TryGetInteractable(other, out IXRInteractable interactable))
    {

      if(currentInteractable == interactable)
        currentInteractable = null;
    }
  }

  private bool TryGetInteractable(Collider collider, out IXRInteractable interactable)
  {
          // null and return false if the collider is not an interactable object or does not have the "Rune" tag
      if (interactionManager.TryGetInteractableForCollider(collider, out interactable) &&
          collider.gameObject.CompareTag("Rune"))
      {
          return true;
      }

      interactable = null;
      return false;
  }

  public override void GetValidTargets(List<IXRInteractable> validTargets)
  {
    validTargets.Clear();
    validTargets.Add(currentInteractable);
  }

  public override bool CanHover(IXRHoverInteractable interactable)
  {
    return base.CanHover(interactable) && currentInteractable == interactable;
  }

  public override bool CanSelect(IXRSelectInteractable interactable)
  {
    return false;
  }

}
