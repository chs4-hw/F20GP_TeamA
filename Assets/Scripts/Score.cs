using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text lblScore;
    private int totalCrystals = 0;

    public void AddCrystals(int amount) {
        totalCrystals += amount;
        lblScore.text = totalCrystals.ToString();
    }
}
