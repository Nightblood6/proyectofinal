using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeigth;
    

    private Vector3 moveDirection;
    private Vector3 velocity;
    

    private Animator animator;
    private CharacterController controller;

    


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }

    public void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, ground);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        } 

        if (isGrounded)
        {
            float moveZ = Input.GetAxis("Horizontal");

            moveDirection = new Vector3(0, 0, moveZ);
          
           
            if (moveDirection != Vector3.zero) 
            {
                Run();
            }
            
            if (moveDirection == Vector3.zero) 
            {
                Idle();
            }
            
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Jump();
                  
            }
        }
            controller.Move(moveDirection * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);   
    }


    private void Run() 
    {
        
        moveDirection *= walkSpeed;

        if (Input.GetAxis("Horizontal") == 1 && !facingRight) 
        {
            
            animator.SetFloat("Speed", 1);
            Flip();
            //this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);  
        }

        if (Input.GetAxis("Horizontal") == -1 && facingRight) 
        {

            animator.SetFloat("Speed", 1);
            Flip();
            //this.gameObject.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }  
    }

    private void Flip() 
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void Idle() 
    {
        
        animator.SetFloat("Speed",0);
    }

    private void Jump() 
    {
        velocity.y = Mathf.Sqrt(jumpHeigth * -2 * gravity);
    }

}
