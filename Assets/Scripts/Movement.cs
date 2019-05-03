using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Movement : MonoBehaviour
{
    Vector3 direction;
    private float speed;

    private void Start()
    {
        speed = Random.Range(0.03f, 0.05f);
        direction = (new Vector3(8, 5) - transform.position).normalized;

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position += speed * direction;
        transform.position = position;
    }
}
