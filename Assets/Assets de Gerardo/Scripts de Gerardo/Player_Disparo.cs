using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Disparo : MonoBehaviour
{
    Player_Orientacion orientacion;

    [Header("Bomba Ratón")]
    [SerializeField] GameObject bombaRaton;
    [SerializeField] float RatonVel;
    public int ratonCount;

    [Header("Verificar cuando dispara")]
    public bool isShooting;
    public float unshootingTime;
    public float passedTime;

    private void Start()
    {
        orientacion = GetComponent<Player_Orientacion>();
        
    }
    private void Update()
    {

        shootingBoolDelay();

        ShootControllerVoid();
        
    }

    void shootingBoolDelay()
    {
        if (isShooting && passedTime < unshootingTime)
        {
            passedTime += Time.deltaTime;
        }

        if (passedTime >= unshootingTime)
        {
            isShooting = false;
        }
    }

    void ShootControllerVoid()
    {
        

        BombaRatonVoid();
    }


    


    


    void BombaRatonVoid()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (ratonCount > 0)
            {
                GameObject bomba = Instantiate(bombaRaton, transform.position, transform.rotation);
                ratonCount--;
                Rigidbody2D bombaRb = bomba.GetComponent<Rigidbody2D>();
                orientacion.direccion.Normalize();
                bombaRb.velocity = new Vector2(orientacion.direccion.x, orientacion.direccion.y) * RatonVel * Time.fixedDeltaTime * 10;
            }
        }
    }


    


    /////////////////////////////////////////////////
    //VOIDS AUXILIARES PARA EL DISPARO PRINCIPAL
   


    
    /////////////////////////////////////////////////
}
