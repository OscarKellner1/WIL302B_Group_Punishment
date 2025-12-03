using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{

    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Switching Scenes");

        if(other.tag == "Player")
        {
            //player entered change level
            print("Moving to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
