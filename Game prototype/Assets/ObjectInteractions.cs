using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractions : MonoBehaviour


{
    
    public ParticleSystem ps;
    public AudioSource audioSource;

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
       
        ps.Play();

        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
       
        ps.Stop();

    }

    private void KeyTrigger()
    {
        audioSource.Play();
    }
}
