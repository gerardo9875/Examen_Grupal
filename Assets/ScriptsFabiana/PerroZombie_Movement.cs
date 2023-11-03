using System.Collections;
using UnityEngine;

public class PerroZombi_movement : MonoBehaviour
{
    Vector2 playerPosition, patrullaDireccion;

    public GameObject player;
    bool seguir, atacar;
    public int vel;

    private float timer;
    private float maxTimer;

    Player_Life playerlife;
    public int life;



    private void Start()
    {
        timer = maxTimer;
        StartCoroutine(Patrulla());
        playerlife = GameObject.FindWithTag("Player").GetComponent<Player_Life>();
    }

    private void Update()
    {
        if (atacar) return; //si esta atacando, el resto del codigo no se ejecuta

        Vector2 target;
        if(seguir==true)target = playerPosition;
        else { target = patrullaDireccion; }

        transform.position = Vector2.MoveTowards(transform.position, target, vel * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, target) <= 1 && seguir== true)
        {
            atacar=true;
            StartCoroutine(Atacando());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bombaraton"))
        {
            life--;
            Destroy(collision.gameObject);
            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")) 
        {
            Vector3 distancia= player.transform.position - transform.position ;
            playerPosition = player.transform.position - distancia.normalized;
            seguir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(Delay());  //inicia la corrutina de seguimiento fuera del detector
        }



    }
    IEnumerator Patrulla()
    {
        while(true) //para hacer un loop de direcciones
        {
            patrullaDireccion= new Vector2 (-5,2);
            yield return new WaitForSeconds(3);
            patrullaDireccion = new Vector2(5,2);
            yield return new WaitForSeconds(3);
        }
        
    }

    IEnumerator Delay()  //Te sigue fuera del detector por 1.5 segundos luego te pierde de vista
    {
        yield return new WaitForSeconds(1.5f);
        seguir= false;
    }

    IEnumerator Atacando()
    {
        yield return new WaitForSeconds(1);
        playerlife.currentlife--;
        atacar=false;
    }
}
