using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject enemyPrefab;

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
        StartCoroutine(GenerateEnemy());
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

    private Vector3 RandomEnemyPosition()
    {
        float y = Random.Range(-1f, 11f);
        float x;

        if (y < -0.5 || y > 10.5)
        {
            x = Random.Range(0.5f, 15.5f);
        } else
        {
            x = Random.Range(0, 1f) < 0.5 ? -0.5f : 16.5f; 
        }

        return new Vector3(x, y);
    }

    IEnumerator GenerateEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject enemyInstance = Instantiate(enemyPrefab, RandomEnemyPosition(), Quaternion.identity);
        enemyInstance.name = "Enemy";
        StartCoroutine(GenerateEnemy());
    }
}

