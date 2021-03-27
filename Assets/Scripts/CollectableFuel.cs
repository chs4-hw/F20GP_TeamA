using UnityEngine;

public class CollectableFuel : MonoBehaviour
{
    [SerializeField] private JetpackFuel jetpackFuel;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player") {
            Debug.Log($"{name} collected.");

            jetpackFuel.AddFuel(100);
            Destroy(gameObject);
        }
    }
}
