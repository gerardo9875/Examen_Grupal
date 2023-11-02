using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PerroZombi_movement : MonoBehaviour
{
    Vector2 Enemypos;

    public GameObject player;
    bool seguir;
    public int vel;

    private float timer;
    private float maxTimer;

    Player_Life life;

    private void Start()
    {
        timer = maxTimer;
        life = GetComponent<Player_Life>();
    }

    private void Update()
    {
        if (seguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemypos, vel * Time.deltaTime);    
        }

        if (Vector2.Distance(transform.position, Enemypos) > 12f)
        {
            seguir = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")) 
        {
            Enemypos = player.transform.position;
            seguir = true;
        }

    }

    

}
