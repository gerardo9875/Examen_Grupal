using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    Player_Movement mov;
    public GameObject playerbullet;

    [SerializeField] public int maxLife;
    public int currentlife;

    private void Awake()
    {
        mov = GetComponent<Player_Movement>();
    }

    private void Start()
    {
        currentlife = maxLife;
    }
    private void Update()
    {
        if (currentlife <= 0)
        {
            mov.canMove = false;

            Rigidbody2D rgb = GetComponent<Rigidbody2D>();
            rgb.velocity = Vector3.zero;

        }
        shoot();
    }

    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(playerbullet);
            obj.transform.position = transform.position;
            obj.GetComponent<PlayerBullet>().direction= Vector2.left;
        }

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("PerroZombie"))
    //    {
    //        currentlife -= 1;
    //        if (currentlife <= 0)
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}
  
}
