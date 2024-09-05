using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinish : MonoBehaviour
{
  // gets whatever is in the text field option. to load the scene.
    public string targetSceneName = "";
    // ensures only the player can trigger the next scene.
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
