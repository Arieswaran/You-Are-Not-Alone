using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] private float moveInput;

    [SerializeField] public Animator animator;
   

    private bool facingRight = true;
    private Rigidbody2D rb;
  
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    [SerializeField] private PlayerTurn playerTurn;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(playerTurn != PlayerTurnController.instance.getCurrentTurn()){
            return;
        }

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity =new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    { 
         animator.SetFloat("speed", Mathf.Abs(speed));
        
        if(playerTurn != PlayerTurnController.instance.getCurrentTurn()){
            rb.velocity = Vector2.down * jumpForce; // made a quick fix for player still floating or moving while switching the player
            return;
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
        }
  
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public PlayerTurn GetPlayerTurn(){
        return playerTurn;
    }

    public void SetPlayerTurn(PlayerTurn turn){
        playerTurn = turn;
    }
     [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;


    public void OnLanding()
    {
     animator.SetBool("isJumping",false);
    }
}