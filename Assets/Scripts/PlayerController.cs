using UnityEngine;
using TMPro; 

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveX;

    public GameObject Zombie;

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

    void OnTriggerEnter (Collider other)
    {
        CanInteractUI.SetActive(true);
    }

    void FixedUpdate()
    {
        // Force Y to always be 0
        rb.velocity = new Vector2(moveX * moveSpeed, 0f);
    }


    //player interaction logic
    float interactRange = 10f;

    //TODO hook in Dialogue UI------------------------------------------------------
    public GameObject GhostdialogueUI;
    public GameObject CanInteractUI;

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
                GhostdialogueUI.SetActive(true);
                if (npc.name == "Zombie")
                {
                    GhostdialogueUI.GetComponent<DialogueManager>().ZDialogue();
                }
                if (npc.name == "Lich")
                {

                }
                if (npc.name == "Witch")
                {

                }
                if (npc.name == "Merman")
                {

                }
                if (npc.name == "Vampire")
                {

                }
                if (npc.name == "Abomination")
                {

                }
                break; // Stop after first NPC in range
            }
        }

    }

}