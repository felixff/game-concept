using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private float movement;
    private float moveX = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        moveX = Input.GetAxisRaw("Horizontal"); // Use GetAxisRaw for immediate response

        // Check if there is movement. If the value isn't 0, the player is pressing left or right
        animator.SetBool("isWalking", moveX != 0f);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (moveX > 0f)
        {
            transform.localScale = new Vector3(3.838f, 4.493f, 1); // Normal scale
        }
        else if (moveX < 0f)
        {
            transform.localScale = new Vector3(-3.838f, 4.493f, 1); // Flipped scale
        }
    }
}