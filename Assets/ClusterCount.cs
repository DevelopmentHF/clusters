using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClusterCount : MonoBehaviour
{
    private GameObject[] clusters;
    [SerializeField] TMP_Text textMeshPro;
     
    // Start is called before the first frame update
    void Start()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");
    }

    // Update is called once per frame
    void Update()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");

        textMeshPro.text = "Clusters = " + clusters.Length;
    }
}
