using System.Collections;
using UnityEngine;

public class PerroZombi_movement : MonoBehaviour
{
    Vector2 Enemypos, patrullaDireccion;

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
        StartCoroutine(Patrulla());
    }

    private void Update()
    {
        //if (!seguir) return; //Cuando no este siguiendo se va a detener

        Vector2 target;
        if(seguir==true)target = Enemypos;
        else { target = patrullaDireccion; }

        transform.position = Vector2.MoveTowards(transform.position, target, vel * Time.deltaTime);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")) 
        {
            Vector3 distancia= player.transform.position - transform.position ;
            Enemypos = player.transform.position - distancia.normalized;
            seguir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            seguir = false; //nombre de la variable del update
        }



    }
    IEnumerator Patrulla()
    {
        while(true) //para hacer un loop de direcciones
        {
            patrullaDireccion= new Vector2 (-5,2);
            yield return new WaitForSeconds(10);
            patrullaDireccion = new Vector2(5,2);
            yield return new WaitForSeconds(10);
        }
        
    }


}
