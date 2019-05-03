using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int life = 5;

    private void Die()
    {
        GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().GameOver();
    }

    private void FixedUpdate()
    {
        transform.RotateAround(new Vector3(8, 5), Vector3.forward, 20 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        this.life -= 1;
        if (life <= 0)
        {
            Die();
        } else
        {
            float colorValue = (float)life / 5;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(colorValue, colorValue, colorValue);
        }
    }

}
