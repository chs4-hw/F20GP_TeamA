using UnityEngine;
using UnityEngine.UI;

public class JetpackFuel : MonoBehaviour
{
    public Slider slider;

    public int Fuel { get; private set; }
    private int maxFuel = 500;
    private bool jetpacking = false;

    void Start() {
        Fuel = 100;
        slider.maxValue = maxFuel;
        slider.value = Fuel;
    }

    void Update() {
        slider.value = Fuel;
        if(Input.GetKey(KeyCode.Mouse1)) {
            jetpacking = true;
        }
    }

    void FixedUpdate() {
        if(jetpacking) {
            if(Fuel > 0) {
                Fuel--;
            }
            jetpacking = false;
        }
    }

    public void AddFuel(int amount) {
        Fuel += amount;
        if(Fuel > maxFuel) {
            Fuel = maxFuel;
        }
    }

}