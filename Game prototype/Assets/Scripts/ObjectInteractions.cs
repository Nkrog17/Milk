using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectInteractions : MonoBehaviour
{

    public ParticleSystem ps;
    public AudioSource audioSource;
    public bool Activated = false;

    private GameObject winScript;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyTrigger();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

       if (!Activated){
        ps.Play();
    }


    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
       
        ps.Stop();
    }

    private void KeyTrigger()
    {
        audioSource.Play();
        if (!Activated){
        	audioSource.Play();
        	Activated = true;
        	Debug.Log("Activated");

        	winScript = GameObject.FindGameObjectWithTag("winscript");
        	winScript.GetComponent<WinScript>().interactionCounter += 1;
        }
    }
}