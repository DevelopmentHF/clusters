using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] TMP_Text textMeshPro;

    private void Start()
    {
        textMeshPro.text = "Level " + level.ToString();
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
        Dragger.movesMade = 0;
    }
}
