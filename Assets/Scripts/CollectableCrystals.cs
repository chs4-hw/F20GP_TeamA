using UnityEngine;

public class CollectableCrystals : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private int value;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player") {
            Debug.Log($"{name} collected.");

            score.AddCrystals(value);
            Destroy(gameObject);
        }
    }
}
