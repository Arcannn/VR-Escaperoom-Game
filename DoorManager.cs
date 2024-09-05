using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door;
    // the door should open by a distance per book. 1 book = 1/3 distance. 3 books = 3/3 distance (door fully open).
    public float openDistancePerBook = 1.0f / 3.0f;
    public float openSpeed = 1.0f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private int booksPlaced = 0;

    private void Start()
    {
        initialPosition = door.transform.localPosition;
    }

    public void PlaceBook()
    {
        booksPlaced++;
        targetPosition = initialPosition + new Vector3(0, openDistancePerBook * booksPlaced, 0);
        StartCoroutine(MoveDoor(door.transform.localPosition, targetPosition, openSpeed));
    }
// moves a door smoothly from one position to another at a specified speed
    private IEnumerator MoveDoor(Vector3 startPos, Vector3 endPos, float speed)
    {
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * speed;
            door.transform.localPosition = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}
