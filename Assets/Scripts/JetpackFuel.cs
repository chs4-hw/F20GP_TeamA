using UnityEngine;
using UnityEngine.UI;

public class JetpackFuel : MonoBehaviour
{
    public Slider slider;
    public int fuel = 100;

    private int maxFuel = 500;
    private bool jetpacking = false;

    void Start() {
        slider.maxValue = maxFuel;
        slider.value = fuel;
    }

    void Update() {
        if(Input.GetKey(KeyCode.Mouse1)) {
            jetpacking = true;
        }
    }

    void FixedUpdate() {
        if(jetpacking) {
            if(fuel > 0) {
                fuel--;
                slider.value = fuel;
            }
            jetpacking = false;
        }
    }

}