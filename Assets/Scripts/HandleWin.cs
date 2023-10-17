using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandleWin : MonoBehaviour
{
    private GameObject[] clusters;

    private bool hasWon = false;
    // Start is called before the first frame update
    void Start()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");
    }

    // Update is called once per frame
    void Update()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");
        
        // we have joined them all together
        if (clusters.Length == 1 && !hasWon)
        {
            GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
            foreach (GameObject circle in circles)
            {
                SpriteRenderer spriteRenderer = circle.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.black;
            }

            hasWon = true;
        }
    }
}
