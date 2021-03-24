using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Transform playerTransform;
    public int divisor = 250;

    Material bgMaterial;
    Vector2 newOffset;

    void Awake() {
        bgMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update() {
        newOffset = new Vector2((float)playerTransform.position.x / divisor, 0f);
        bgMaterial.mainTextureOffset = newOffset;
    }
}
