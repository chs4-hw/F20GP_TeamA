using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{

    public GameObject Character;
    public float myX;
    public float myY;
    // Start is called before the first frame update
    void Start()
    {
        myX = transform.position.x;                                                                        
        myY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Character.transform.position.x;                                                       
        float y = Character.transform.position.y;

        if ((x <= myX + 2.0f && x >= myX - 2.0f) && (y <= myY + 4.0f && y >= myY - 4.0f))
        {
            //Debug.Log("were touching ooo00oo0o");
            Destroy(gameObject);
        }
        //else {
            //Debug.Log("come closer");
        //}
    }


    }
