using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f; // Player movement speed
    public float jumpForce = 10f; // Force applied when jumping
    public Transform groundCheckPos; // Checks if the player is on the ground
    public LayerMask groundDetectionLayer; // Specifies what is considered as "ground"

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Checks if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, 0.2f, groundDetectionLayer);

        Move();
        Jump();
    }

    void Move()
    {
        float movementDirection = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(movementDirection * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
