using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public float groundWidth = 10f; // Width of the ground piece
    public Transform playerTransform;
    public float groundYPosition = -5.1f;
    private float spawnX = 0.0f;
    private float lastPlayerX;

    void Start()
    {
        lastPlayerX = playerTransform.position.x;
        InstantiateGroundAtPlayer();
        ManageGround();
    }

    void Update()
    {
        if (Mathf.Abs(playerTransform.position.x - lastPlayerX) > groundWidth / 2)
        {
            lastPlayerX = playerTransform.position.x;
            ManageGround();
        }
    }

    void ManageGround()
    {
        // Instantiate new ground if the player has moved significantly
        if (playerTransform.position.x > spawnX)
        {
            Instantiate(groundPrefab, new Vector3(spawnX + groundWidth, groundYPosition, 0), Quaternion.identity);
            spawnX += groundWidth;
        }
        else if (playerTransform.position.x < spawnX - groundWidth)
        {
            Instantiate(groundPrefab, new Vector3(spawnX - groundWidth * 2, groundYPosition, 0), Quaternion.identity);
            spawnX -= groundWidth;
        }

        // Here you can add logic to destroy or deactivate old ground pieces
        // if they are too far from the player to save memory.
    }

    void InstantiateGroundAtPlayer()
    {
        float playerX = playerTransform.position.x;
        // Assuming a fixed y-position for the ground; adjust this based on your game's design
         // Example y-position; adjust this according to your game's needs

        // Calculate the nearest ground spawn position based on the player's current position
        float nearestSpawnX = Mathf.Round(playerX / groundWidth) * groundWidth;
        for (float i = nearestSpawnX - groundWidth * 2; i <= nearestSpawnX + groundWidth * 2; i += groundWidth)
        {
            Instantiate(groundPrefab, new Vector3(i, groundYPosition, 0), Quaternion.identity);
        }
        spawnX = nearestSpawnX;
    }
}