using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;
    public Vector2 direction;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        rb2d.velocity= direction * speed;
    }

}
