using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject Zombie;
    public TextMeshProUGUI textComponent;
    //public string[] lines;

    public int index;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == Zombie.GetComponent<ZombieNPCDialogue>().lines[index])
            {
                NextLine();
                textComponent.text = string.Empty;
            }
            else
            {
                textComponent.text = Zombie.GetComponent<ZombieNPCDialogue>().lines[index];
            }
        }
    }

    void NextLine()
    {
        if (index < Zombie.GetComponent<ZombieNPCDialogue>().lines.Length - 1)
        {
            textComponent.text = string.Empty;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ZDialogue()
    {
        Zombie.GetComponent<ZombieNPCDialogue>().TalkDialogue();
    }
}
