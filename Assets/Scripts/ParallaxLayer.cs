using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor; // How much the background moves with the camera
    public Transform cameraTransform; // Reference to the camera transform
    private float spriteWidth; // Width of the background sprite
    private Vector3 startPosition; // Starting position of the background

    private void Awake()
    {
        // Get the width of the sprite (assumes sprite is scaled to 1, adjust if not)
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position;
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Calculate how far we've moved from the start position
        float distanceFromStart = cameraTransform.position.x * parallaxFactor;
        // Apply the movement
        transform.position = startPosition + Vector3.right * distanceFromStart;

        // Looping logic
        if (cameraTransform.position.x - transform.position.x >= spriteWidth / 2f)
        {
            // If camera is halfway past the sprite to the right, reset position
            startPosition.x += spriteWidth;
        }
        else if (cameraTransform.position.x - transform.position.x <= -spriteWidth / 2f)
        {
            // If camera is halfway past the sprite to the left, reset position
            startPosition.x -= spriteWidth;
        }
    }
}