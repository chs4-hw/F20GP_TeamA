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
        float x = playerTransform.position.x / divisor;
        float y = playerTransform.position.y / divisor;
        newOffset = new Vector2(x,y);
        //newOffset = new Vector2((float)playerTransform.position.x / divisor, 0f);
        bgMaterial.mainTextureOffset = newOffset;
    }
}
