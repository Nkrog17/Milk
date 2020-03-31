using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int interactionCounter = 0;
    public GameObject winImage;

    // Update is called once per frame
    void Update()
    {
        if (interactionCounter == 4){
        	winImage.SetActive(true);
        }
    }
}