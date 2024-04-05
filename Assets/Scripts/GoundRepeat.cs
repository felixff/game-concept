using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject groundPrefab;
    public float groundWidth;

    void Update()
    {
        if (transform.position.x <= -groundWidth)
        {
            Vector3 newPos = new Vector3(transform.position.x + groundWidth * 2, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}