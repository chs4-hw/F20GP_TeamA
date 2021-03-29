using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject outPortal;
    public GameObject Player;
    public bool justActivated = false;

    private float playerVerticalOffset = 2.50f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //StartCoroutine(Teleport());

            if(!justActivated) {
                try {
                    outPortal.GetComponent<Teleportation>().justActivated = true;
                }
                catch {
                    // Then do nothing as 'outPortal' is just an exit point.
                }
                
                Player.transform.position = new Vector2(outPortal.transform.position.x, outPortal.transform.position.y - playerVerticalOffset);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            justActivated = false;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1f);

        Player.transform.position = new Vector2(outPortal.transform.position.x, outPortal.transform.position.y);
    }
}
