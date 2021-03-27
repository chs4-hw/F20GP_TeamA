using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public JetpackFuel jetpackFuel;
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool usingJetpack = false;

    private const string isJumping = "isJumping";
    private const string moveSpeed = "Move";

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat(moveSpeed, Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool(isJumping, true);
        }

        if(Input.GetKey(KeyCode.Mouse1)) {
            if(jetpackFuel.fuel > 0) {
                usingJetpack = true;
                animator.SetBool(isJumping, true);
            }
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, usingJetpack);
        jump = false;
        usingJetpack = false;
    }

    public void OnLanding() {
        animator.SetBool(isJumping, false);
    }
}
