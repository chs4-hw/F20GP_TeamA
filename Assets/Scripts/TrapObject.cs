using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(TilemapCollider2D))]

public class TrapObject : MonoBehaviour
{

    public int damage;
    //Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Reset()
    {
        GetComponent<TilemapCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            Debug.Log($"{name} Triggered");
            PlayerStatus health = collision.GetComponent<PlayerStatus>();
            health.TakeHealthDamage(damage);
        }
    }
}
