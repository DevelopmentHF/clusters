using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragger : MonoBehaviour
{

    private Camera cam;
    private Vector3 offset;
    public bool isDragging = false;
    [SerializeField] private Collider2D collider2d;
    private GameObject[] circles;
    public static int movesMade = 0;

    private void Start()
    {
        cam = Camera.main;
        circles = GameObject.FindGameObjectsWithTag("Circle");
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
                            ResetClusters();
                            offset = transform.position - objPosition;
                            isDragging = true;
                            movesMade++;
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
                        ResetClusters();
                        break;
                }
            }
        #endif
        Debug.Log("moves made: " + movesMade);
    }

    void ResetClusters()
    {
        circles = GameObject.FindGameObjectsWithTag("Circle");
        int i = 0;

        foreach (GameObject circle in circles)
        {
            // Create a new parent for the current circle with a unique name
            float uniqueTime = Time.realtimeSinceStartup;
            GameObject newParent = new GameObject("CircleCluster" + uniqueTime + "_" + i++);
            newParent.tag = "Cluster";
            circle.transform.parent = newParent.transform;
        }
    }
    
    void OnMouseDrag()
    {
        #if UNITY_EDITOR
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 objPosition = cam.ScreenToWorldPoint(mousePosition);
            if (!isDragging)
            {
                movesMade++;
                ResetClusters();
            }
            isDragging = true;
            transform.position = objPosition;
        #endif
    }

    void OnMouseUp()
    {
        isDragging = false;
        ResetClusters();
    }
}
