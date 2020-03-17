using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseScript : MonoBehaviour
{

    AudioSource audioSource;
    public static Vector3 position;
    public static bool noiseOn = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        audioSource.Play();
        Debug.Log("Im in the trigger");
        Debug.Log(transform.position);
        position = transform.position;
        noiseOn = true;
        Debug.Log(noiseOn);
        Debug.Log(Input.mousePosition);
    }
}
