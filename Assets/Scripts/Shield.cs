using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Text pointsText;
    private int points = 0;
    private int direction = 1;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        transform.RotateAround(new Vector3(8, 5), Vector3.forward, 180 * direction * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }

        pointsText.text = "Points " + points;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            points += 10;
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("RestoreLife"))
        {
            player.RestoreLife();
            Destroy(collision.gameObject);
        }
    }

    private void ChangeDirection()
    {
        this.direction *= -1;
    }
}
