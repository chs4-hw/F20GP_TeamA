using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerPatrol : MonoBehaviour
{
    private bool closeToWallRight = false;
    private bool closeToWallLeft = false;
    private float forward = -10.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (closeToWallRight)
        {
            forward = -10.0f;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (closeToWallLeft)
        {
            forward = 10.0f;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 2.0f);
        if (hit.collider != null)
        {
            closeToWallRight = true;
        }
        else
        {
            closeToWallRight = false;
        }
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, 2.0f);
        if (hit2.collider != null)
        {
            closeToWallLeft = true;
        }
        else
        {
            closeToWallLeft = false;
        }

        rb.AddForce(new Vector3(forward, 0.0f, 0.0f), ForceMode2D.Force);

        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 2.5f);
        if (hitUp.collider != null)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log($"{name} Triggered");
            PlayerStatus health = other.gameObject.GetComponent<PlayerStatus>();
            health.TakeHealthDamage(20);
        }
    }

}
