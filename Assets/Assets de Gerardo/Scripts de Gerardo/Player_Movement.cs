
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
     public Rigidbody2D playerRb;


    [SerializeField] private float speed;
 public Vector2 moveInput;
 public bool canMove = true;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        playerRb.velocity= moveInput* speed * Time.fixedDeltaTime;

    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY);
    }

}
