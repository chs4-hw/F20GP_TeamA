using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;
    private float playerMove;
    //private bool jump;

    private Rigidbody2D rb;

    private bool isFaceingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundMask;

    // Animation
    public Animator animator;

    // MaybeDouble Jump
    //private int jumps;
    //public int NumOfJumps;


    // Start is called before the first frame update
    void Start()
    {
        // Double Jump      
        //jumps = NumOfJumps;

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Option 1 (Jump)
        if (isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        //// Option 2 (Double jump +)

        //if (isGrounded == true)
        //{
        //    jumps = NumOfJumps;
        //}

        //if (Input.GetMouseButtonDown(0) && jumps > 0)
        //{
        //    rb.velocity = Vector2.up * jumpForce;
        //    jumps--;
        //}
        //else if (Input.GetMouseButtonDown(0) && jumps == 0 && isGrounded)
        //{
        //    rb.velocity = Vector2.up * jumpForce;
        //}

        // Debug.Log(isGrounded);

    }

    void FixedUpdate()
    {
        // Is Player on ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);

        moveInput = Input.GetAxis("Horizontal");
        playerMove = moveInput * speed;
        rb.velocity = new Vector2(playerMove, rb.velocity.y);

        // Animation
        if (isGrounded)
        {
            animator.SetFloat("Move", Mathf.Abs(playerMove));
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
        
        // Faceing Direction
        if (isFaceingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (isFaceingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    // Change Player faceing direction when moving
    void Flip()
    {
        isFaceingRight = !isFaceingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

