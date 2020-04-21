﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseScript : MonoBehaviour
{
    AudioSource audioSource;
    public static Vector3 position;
    public static bool noiseOn = false;
    public static Vector3 squeekyPos;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
        audioSource.Play();
        noiseOn = true;
            squeekyPos = this.transform.position;
        }
    }
}
