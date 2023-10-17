using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScale : MonoBehaviour
{
    private float scaleFactor = 1.05f;
    private Vector3 initialScale; // Store the initial scale for resetting

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        transform.localScale *= scaleFactor;
    }

    private void OnMouseUp()
    {
        // Change the scale of the object when clicked
        transform.localScale = initialScale;
    }
}
