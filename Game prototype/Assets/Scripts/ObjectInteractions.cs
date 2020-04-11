using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectInteractions : MonoBehaviour
{

    public ParticleSystem ps;
    public AudioSource audioSource;

    //Kun nødvendig, hvis objekt skal skifte materiale
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
            if (g_GameObject){
            	g_GameObject.GetComponent<Renderer>().material = m_Material;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

       if (!Activated){
        ps.Play();
    }


    }
    private void OnTriggerExit(Collider other)
    {       
        ps.Stop();
        //audioSource.Stop();
        if (g_GameObject){
        	g_GameObject.GetComponent<Renderer>().material = m_Material2;
        }
    }

    private void KeyTrigger()
    {
    	if (!Activated){
        //NPC running to object
        startInvestigate = true;
        objectPosition = this.transform.position;
        	audioSource.Play();
        	Activated = true;
        	Debug.Log("Activated");

        	winScript = GameObject.FindGameObjectWithTag("winscript");
        	winScript.GetComponent<WinScript>().interactionCounter += 1;


        }
    }
}