using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleWin : MonoBehaviour
{
    private GameObject[] clusters;
    [SerializeField] private int numberOfMovesAllowed;
    public int numMovesUsed = 0;
    [SerializeField] TMP_Text textMeshPro;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");
        cam = Camera.main;
        textMeshPro.text = numberOfMovesAllowed.ToString();
        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        clusters = GameObject.FindGameObjectsWithTag("Cluster");
        numMovesUsed = Dragger.movesMade;
        Debug.Log("moves made: " + numMovesUsed);
        Debug.Log("static moves made: " + Dragger.movesMade);
        // Lose
        if (numMovesUsed == numberOfMovesAllowed)
        {
            // Get the screen center
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // move button to center to stop play
            gameObject.transform.position = screenCenter;
        }
        
        // Win
        if (clusters.Length == 1 && (numMovesUsed <= numberOfMovesAllowed))
        {
            GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
            foreach (GameObject circle in circles)
            {
                SpriteRenderer spriteRenderer = circle.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.green;
            }
        }
        
        textMeshPro.text = (numberOfMovesAllowed - numMovesUsed).ToString();
    }

    public void OnClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Dragger.movesMade = 0;
    }
}
