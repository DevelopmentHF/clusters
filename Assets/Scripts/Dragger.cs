using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragger : MonoBehaviour
{

    private Camera cam;
    private Vector3 offset;
    private bool isDragging = false;
    [SerializeField] private Collider2D collider2d;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (isDragging)
        {
            collider2d.isTrigger = true;
        }
        else
        {
            collider2d.isTrigger = false;
        }
        
        #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                isDragging = true;
                
            }
            else
            {
                isDragging = false;
            }
        #endif
        
        #if UNITY_ANDROID
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
        #endif
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Circle"))
        {
            Debug.Log("Currently overlapping");
        }
    }
    
    void OnMouseDrag()
    {
        #if UNITY_EDITOR
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 objPosition = cam.ScreenToWorldPoint(mousePosition);
        
            transform.position = objPosition;
        #endif
    }
}
