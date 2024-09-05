using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class uiController : MonoBehaviour
{
  private Vector3 initScale;
  [SerializeField] private InputActionReference toggleUI;
  private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
        toggleUI.action.performed += ToggleUI;
        transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator ScaleTo(Vector3 newScale)
    {
      float progress = 0;
      while(progress <= 1)
      {
        transform.localScale = Vector3.Lerp(this.transform.localScale, newScale, progress);
        progress += Time.deltaTime * Time.timeScale;
        yield return null;
      }
      transform.localScale = newScale;

    }

    private void ToggleUI(InputAction.CallbackContext context)
    {
      if(!isActive)
      {
        StartCoroutine(ScaleTo(initScale));
        isActive = true;

      }
      else{
        StartCoroutine(ScaleTo(new Vector3(0, 0, 0)));
        isActive = false;
      }
    }
}
