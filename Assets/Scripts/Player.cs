using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text pointsText;
    private int points = 0;
    private int direction = 1;
    

    public void Die()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }

    private void FixedUpdate()
    {
        transform.RotateAround(new Vector3(8, 5), Vector3.forward, 120 * direction * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }

        pointsText.text = "Points " + points;
    }

    private void ChangeDirection()
    {
        this.direction *= -1;
    }
}
