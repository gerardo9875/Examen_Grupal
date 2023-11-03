using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    Player_Movement mov;
    Player_Disparo shoot;

    [SerializeField] public int maxLife;
    public int currentlife;

    [NonSerialized] public bool canRecieveDamage = true;
    private void Awake()
    {
        mov = GetComponent<Player_Movement>();
        shoot = GetComponentInChildren<Player_Disparo>();
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
