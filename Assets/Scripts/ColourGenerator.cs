using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColourGenerator : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite;
    private System.Random rng = new System.Random();
    private List<List<Color>> palettes = new List<List<Color>>();
    private static List<Color> palette = null;
    private Camera camera;

    private void Awake()
    {   
        List<Color> arctic = new List<Color>
        {
            new Color(39f / 255f, 31f / 255f, 54f / 255f),
            new Color(32f / 255f, 78f / 255f, 241f / 255f),
            new Color(40f / 255f, 176f / 255f, 243f / 255f),
            new Color(251f / 255f, 251f / 255f, 251f / 255f)
        };

        List<Color> crimson = new List<Color>
        {
            new Color(93f / 255f, 0f, 4f / 255f),
            new Color(158f / 255f, 0f, 8f / 255f),
            new Color(195f / 255f, 0f, 10f / 255f),
            new Color(223f / 255f, 1f / 255f, 13f / 255f),
            new Color(235f / 255f, 0f, 11f / 255f)
        };
        

        // Add the palette to your list of palettes
        palettes.Add(arctic);
        palettes.Add(crimson);
    }

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    // Start is called before the first frame update
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        camera = Camera.main;
        
        // pick one of our predefined palettes. Would love to have this also randomised at some point.
        if (palette == null)
        {
            palette = palettes[rng.Next(palettes.Count)];
        }
        
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = GenerateNewColor(palette);
        camera.backgroundColor = palette[0];
    }
    
    private void OnSceneUnloaded(Scene scene)
    {
        // Perform actions when the scene is unloaded
        // Save data or perform cleanup, if necessary
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private Color GenerateNewColor(List<Color> rngPalette)
    {
        return rngPalette[rng.Next(1, rngPalette.Count)];
    }
}
