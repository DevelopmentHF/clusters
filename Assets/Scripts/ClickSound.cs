using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private CircleCollider2D collider;
    [SerializeField] [Range(-0.2f, 0.2f)] private float pitchModifier = 0;
    private void Start()
    {
        float worldScale = transform.lossyScale.x;
        float radius = collider.radius;
        
        // set the pitch based on the size of the circle
        audioSource.pitch = 1 - (worldScale * radius) + pitchModifier;  // bigger circles should sound deeper, hence the 1 - ()
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        audioSource.Play();
    }
}
