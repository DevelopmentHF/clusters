using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGenerator : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite;
    private System.Random rng = new System.Random();
    private List<List<Color>> palettes = new List<List<Color>>();

    private void Awake()
    {   
        List<Color> arctic = new List<Color>
        {
            new Color(39f / 255f, 31f / 255f, 54f / 255f),
            new Color(32f / 255f, 78f / 255f, 241f / 255f),
            new Color(40f / 255f, 176f / 255f, 243f / 255f),
            new Color(251f / 255f, 251f / 255f, 251f / 255f)
        };

        List<Color> vapor = new List<Color>
        {
            new Color(45f / 255f, 38f / 255f, 239f / 255f),
            new Color(255f / 255f, 93f / 255f, 239f / 255f),
            new Color(135f / 255f, 70f / 255f, 253f / 255f),
            new Color(8f / 255f, 142f / 255f, 253f / 255f),
            new Color(2f / 255f, 165f / 255f, 205f / 255f)
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
        palettes.Add(vapor);
        palettes.Add(crimson);
    }

    // Start is called before the first frame update
    void Start()
    {
        // pick one of our predefined palettes. Would love to have this also randomised at some point.
        List<Color> rngPalette = palettes[rng.Next(palettes.Count)];
        
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = GenerateNewColor(rngPalette);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Colour changes passively over time
        
        
    }

    private Color GenerateNewColor(List<Color> palette)
    {
        return palette[rng.Next(palette.Count)];
    }
}
