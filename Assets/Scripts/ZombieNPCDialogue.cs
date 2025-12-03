using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieNPCDialogue : MonoBehaviour
{
    //bool InteractionsZ = false;
    public string[] lines;
    public TextMeshProUGUI textComponent;
    public GameObject GhostUI;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TalkDialogue()
    {
        GhostUI.GetComponent<DialogueManager>().index = 0;
        foreach (char c in lines[GhostUI.GetComponent<DialogueManager>().index].ToCharArray())
        {
            textComponent.text += c;
            if (GhostUI.GetComponent<DialogueManager>().index < lines.Length - 1)
            {
                GhostUI.GetComponent<DialogueManager>().index++;
                //InteractionsZ = true;
            }
        }
    }
}
