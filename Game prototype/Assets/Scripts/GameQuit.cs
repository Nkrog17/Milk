using UnityEngine;
using System.Collections;


public class GameQuit: MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

