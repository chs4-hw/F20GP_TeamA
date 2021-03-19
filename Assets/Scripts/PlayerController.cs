using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isFaceingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundMask;

    // Animation
    public Animator jump;

    // MaybeDouble Jump
    //private int jumps;
    //public int NumOfJumps;


    // Start is called before the first frame update
    void Start()
    {
        // Double Jump      
        //jumps = NumOfJumps;

        rb = GetComponent<Rigidbody2D>();

        jump = rb.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Option 1
        if (isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //jump.Play("Jump1");
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

        Debug.Log(isGrounded);

    }

    void FixedUpdate()
    {
        //// is Player on ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

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

