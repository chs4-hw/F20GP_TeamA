using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerChase : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Physics2D.queriesStartInColliders = false;


        RaycastHit2D hitPlayerL = Physics2D.Raycast(transform.position, Vector2.left, 50.0f);
        if (hitPlayerL.collider != null)
        {
            if (hitPlayerL.collider.gameObject.tag == "Player")
            {
                rb.AddForce(new Vector3(-30.0f, 0.0f, 0.0f), ForceMode2D.Force);
            }
        }
        RaycastHit2D hitPlayerR = Physics2D.Raycast(transform.position, Vector2.right, 50.0f);
        if (hitPlayerR.collider != null)
        {
            if (hitPlayerR.collider.gameObject.tag == "Player")
            {
                rb.AddForce(new Vector3(30.0f, 0.0f, 0.0f), ForceMode2D.Force);
            }
        }

        RaycastHit2D stomped = Physics2D.Raycast(transform.position, Vector2.up, 3.0f);
        if (stomped.collider != null)
        {
            Destroy(gameObject);
            Debug.Log(stomped.collider);
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
