using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPalette : MonoBehaviour
{
    private System.Random rng = new System.Random();
    private List<List<Color>> palettes = new List<List<Color>>();
    public List<Color> palette;

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

        palette = GeneratePalette();
    }

    private List<Color> GeneratePalette()
    {
        return palettes[rng.Next(palettes.Count)];
    }
}
