using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesScore : MonoBehaviour
{

    private int startCrystals;
    private int x;
    private int totalRemaning;
    private GUIStyle guiStyle = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        startCrystals = GameObject.FindGameObjectsWithTag("Crystal").Length;
        Debug.Log("awdawdawd" + startCrystals);
    }

    // Update is called once per frame
    void Update()
    {
        int currentCrystals = GameObject.FindGameObjectsWithTag("Crystal").Length;
        x = startCrystals - currentCrystals;
        totalRemaning = startCrystals - x;
        //Debug.Log(x);
    }

    void OnGUI()
    {
        guiStyle.fontSize = 20;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 400, 20), "Crystals Collected: " + x, guiStyle);
        GUI.Label(new Rect(10, 30, 400, 20), "Total Crystals in Level: " + totalRemaning, guiStyle);
    }
}
