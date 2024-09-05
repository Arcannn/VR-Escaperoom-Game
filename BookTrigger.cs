using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    public DoorManager doorManager;
    public string requiredTag;
    public AudioClip successSound;
    public AudioClip failureSound;

    private bool bookPlaced = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bookPlaced)
        {
            if (other.CompareTag(requiredTag)) // requires green,red,yellow
            {
                doorManager.PlaceBook();
                bookPlaced = true;
                audioSource.PlayOneShot(successSound); // Play the success sound
            }
            else
            {
                audioSource.PlayOneShot(failureSound); // Play the failure sound
            }
        }
    }
}
