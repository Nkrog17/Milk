using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectInteractions : MonoBehaviour
{

    public ParticleSystem ps;
    public AudioSource audioSource;

    public GameObject g_GameObject;
    public Material m_Material;
    public Material m_Material2;



    public bool Activated = false;
    public static Vector3 objectPosition;
    public static bool startInvestigate = false;
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
            g_GameObject.GetComponent<Renderer>().material = m_Material;
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
        //audioSource.Stop();
        g_GameObject.GetComponent<Renderer>().material = m_Material2;
    }

    private void KeyTrigger()
    {
        //NPC running to object
        startInvestigate = true;
        objectPosition = this.transform.position;

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