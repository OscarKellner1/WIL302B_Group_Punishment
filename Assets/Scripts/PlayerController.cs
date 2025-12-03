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


        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void FixedUpdate()
    {
        // Force Y to always be 0
        rb.velocity = new Vector2(moveX * moveSpeed, 0f);
    }


    //player interaction logic
    float interactRange = 2f;

    //TODO hook in Dialogue UI------------------------------------------------------
    public GameObject dialogueUI;

    public void TryInteract()
    {
        //Find all NPCs in the scene with the "NPC" tag
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

        //detect npc in range
        foreach (GameObject npc in npcs)
        {
            float distance = Vector2.Distance(transform.position, npc.transform.position);
            if (distance <= interactRange)
            {
                // Show dialogue UI (could be replaced with NPC-specific dialogue manager)
                dialogueUI.SetActive(true);
                Debug.Log("Talking to " + npc.name);
                break; // Stop after first NPC in range
            }
        }

    }

}