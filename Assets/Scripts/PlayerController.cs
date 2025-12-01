using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    // Ladder detection
    private bool isOnLadder = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D
        float moveY = 0f; // Default: no vertical movement

        // Only allow W/S when on a ladder
        if (isOnLadder)
        {
            moveY = Input.GetAxisRaw("Vertical"); // W/S
        }

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    // Detect ladder trigger zones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
            rb.gravityScale = 0f; // Disable gravity while climbing
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
            rb.gravityScale = 1f; // Restore gravity when leaving ladder
        }
    }
}