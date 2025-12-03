using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNPCDialogue : MonoBehaviour
{
    bool InteractionsZ = false;
    // Start is called before the first frame update
    void Start()
    {
        if (InteractionsZ == false)
        {
            Debug.Log("Hey, you over there!?");
            InteractionsZ = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
