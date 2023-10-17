using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HandleWin : MonoBehaviour
{
    private GameObject[] clusters;
    [SerializeField] private int numberOfMovesAllowed;
    public int numMovesUsed = 0;
    [SerializeField] TMP_Text textMeshPro;
    private bool hasWon = false;
    // Start is called before the first frame update
    void Start()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");
        textMeshPro.text = numberOfMovesAllowed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");
        numMovesUsed = Dragger.movesMade;
        
        // Lose
        if (numMovesUsed == numberOfMovesAllowed)
        {
            GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
            foreach (GameObject circle in circles)
            {
                SpriteRenderer spriteRenderer = circle.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.black;
            }
        }
        
        // Win
        if (clusters.Length == 1 && !hasWon && numMovesUsed <= numberOfMovesAllowed)
        {
            GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
            foreach (GameObject circle in circles)
            {
                SpriteRenderer spriteRenderer = circle.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.green;
            }

            hasWon = true;
        }
        
        textMeshPro.text = (numberOfMovesAllowed - numMovesUsed).ToString();
    }
}
