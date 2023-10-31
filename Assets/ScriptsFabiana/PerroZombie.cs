using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroZombie : MonoBehaviour
{
    public int life;
    public Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        rb2d.velocity=direction*speed;
    }
}
