using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamequit : MonoBehaviour
{
    public bool exitm = false;

    // Update is called once per frame
    void Update()
    {
        if (exitm == true)
        {
            GameQuit();
        }
    }

    public void GameQuit()
    {
        Debug.Log("quit");
        Application.Quit();
        Debug.Log("quit");
    }
}

