using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


    private float startDelay = 1f;
    private Text mainText;
    private GameObject mainCanvas;
    private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        mainCanvas = GameObject.Find("MainCanvas");
        mainText = GameObject.Find("MainText").GetComponent<Text>();

        if (instance == null)
        {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    public void InitGame()
    {

        mainCanvas.SetActive(true);
        Invoke("HideMainCanvas", startDelay);
    }

    private void HideMainCanvas()
    {
        mainCanvas.SetActive(false);
    }

    public void GameOver()
    {
        mainText.text = "Game Over";
        mainCanvas.SetActive(true);
        enabled = false;
    }
}

