using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{

    private Camera cam;
    private Vector3 offset;
    private bool isDragging = false;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Assuming only one touch for simplicity

            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10);
            Vector3 objPosition = cam.ScreenToWorldPoint(touchPosition);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D hit = Physics2D.OverlapPoint(objPosition);
                    if (hit != null && hit.gameObject == gameObject)
                    {
                        offset = transform.position - objPosition;
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        transform.position = objPosition + offset;
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
    }
    
    // void OnMouseDrag()
    // {
    //     Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
    //     Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //
    //     transform.position = objPosition;
    // }
    
}
