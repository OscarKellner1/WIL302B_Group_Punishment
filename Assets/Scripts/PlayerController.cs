using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;           //Disable gravity
        rb.freezeRotation = true;       //Prevent spinning
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Force Y to always be 0
        rb.velocity = new Vector2(moveX * moveSpeed, 0f);
    }


    //player interaction logic
    
}