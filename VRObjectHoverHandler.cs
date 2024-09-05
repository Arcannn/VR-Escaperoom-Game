using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRObjectHoverHandler : MonoBehaviour
{
    public GameObject textObject;
    private IXRHoverInteractable interactable;
// when the players raycasting hovers over the npc, the text should show.
    private void OnEnable()
    {
        interactable = GetComponent<IXRHoverInteractable>();
        interactable.hoverEntered.AddListener(ShowText);
        interactable.hoverExited.AddListener(HideText);
    }

    private void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(ShowText);
        interactable.hoverExited.RemoveListener(HideText);
    }
// hovering over - showing text.
    private void ShowText(HoverEnterEventArgs args)
    {
        textObject.SetActive(true);
    }
// not hovering over, text goes false.
    private void HideText(HoverExitEventArgs args)
    {
        textObject.SetActive(false);
    }

}
