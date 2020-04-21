using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int interactionCounter = 0;
    public GameObject winImage;
    AudioSource winSound;

    // Update is called once per frame
    void Update()
    {
        if (interactionCounter == 5){
        	winImage.SetActive(true);
        	if(!winSound.isPlaying){
        		winSound.Play();
        		interactionCounter = 8;
        	}
        }
    }

    void Start(){
    	winSound = GetComponent<AudioSource>();
    }
}