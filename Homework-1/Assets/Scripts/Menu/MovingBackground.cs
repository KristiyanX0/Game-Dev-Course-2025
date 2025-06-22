using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    // Speed of the background movement
    public float speed = 2f;

    // X position at which the background resets
    public float resetPositionX = -10f;

    // Starting X position to reset to
    public float startPositionX = 10f;

    void Update()
    {
        // Move the background to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the background has reached the reset position
        if (transform.position.x <= resetPositionX)
        {
            // Reset the background's position
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}
