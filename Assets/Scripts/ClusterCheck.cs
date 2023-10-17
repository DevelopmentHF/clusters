using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterCheck : MonoBehaviour
{
    private GameObject[] circles;
    private const float Threshold = 0.15f;
    private bool inCluster;
    private Dragger draggerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find all GameObjects with the "Circle" tag
        circles = GameObject.FindGameObjectsWithTag("Circle");
        draggerScript = GetComponent<Dragger>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // assign to a cluster
        if (draggerScript.isDragging) return;

        inCluster = false;
        
        // for the current game object, add it to it's nearest cluster.
        // if the gameObject is no longer touching anything, make it's own cluster
        for (int i = 0; i < circles.Length; i++)
        {
            if (circles[i] == gameObject) continue;
            
            // Calculate distance between circle centers
            float distance = Vector3.Distance(circles[i].transform.position, transform.position);

            // Calculate combined radius for both circles
            float combinedRadius = GetWorldSpaceRadius(circles[i]) + GetWorldSpaceRadius(gameObject);

            if (distance < combinedRadius + Threshold)
            {
                // The edges are now within the threshold of each other
                // Add the second circle to the cluster of the first
                inCluster = true;
                circles[i].transform.parent = transform.parent;
                break;
            }
        }
        if (!inCluster)
        {
            Debug.Log("not in cluster");
            GameObject newParent = new GameObject("CircleCluster" + Time.deltaTime);    // unique name
            newParent.tag = "Cluster";
            transform.parent = newParent.transform;
        }

        CheckTouchingClusters();

        RemoveEmptyClusters();
    }

    void CheckTouchingClusters()
    {
        // for the current game object, add it to it's nearest cluster.
        // if the gameObject is no longer touching anything, make it's own cluster
        for (int i = 0; i < circles.Length; i++)
        {
            if (circles[i] == gameObject) continue;
            
            // Calculate distance between circle centers
            float distance = Vector3.Distance(circles[i].transform.position, transform.position);

            // Calculate combined radius for both circles
            float combinedRadius = GetWorldSpaceRadius(circles[i]) + GetWorldSpaceRadius(gameObject);

            if (distance < combinedRadius + Threshold)
            {   
                // touching a cluster that isn't its own
                if (transform.parent != circles[i].transform.parent)
                {
                    JoinCluster(transform.parent, circles[i].transform.parent);
                }
            }
        }
    }

    void JoinCluster(Transform cluster1, Transform cluster2)
    {
        foreach (Transform obj in cluster2)
        {
            obj.parent = cluster1;
        }
    }
    
    void RemoveEmptyClusters()
    {
        // Find all GameObjects with the "Cluster" tag
        GameObject[] clusterObjects = GameObject.FindGameObjectsWithTag("Cluster");

        foreach (var clusterObject in clusterObjects)
        {
            // Check if the cluster has no children
            if (clusterObject.transform.childCount == 0)
            {
                // Destroy the empty cluster
                Destroy(clusterObject);
            }
        }
    }
    
    float GetWorldSpaceRadius(GameObject circleObject)
    {
        CircleCollider2D circleCollider = circleObject.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            Vector3 scale = circleObject.transform.lossyScale;
            return circleCollider.radius * Mathf.Max(scale.x, scale.y);
        }
        return 0.0f; // Handle if the GameObject doesn't have a CircleCollider2D
    }
}
