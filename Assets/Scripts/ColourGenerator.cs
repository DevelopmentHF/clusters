using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColourGenerator : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] GameObject paletteObj;
    private List<Color> palette;
    private System.Random rng = new System.Random();
    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
        camera = Camera.main;
        
        // pick one of our predefined palettes. Would love to have this also randomised at some point.
        // TODO this can be better, try not to use Find
        paletteObj = GameObject.Find("Palette");
        palette = paletteObj.GetComponent<PickPalette>().palette;
        
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = GenerateNewColor(palette);
        camera.backgroundColor = palette[0];
    }
    
    private Color GenerateNewColor(List<Color> rngPalette)
    {
        return rngPalette[rng.Next(1, rngPalette.Count)];
    }
}
