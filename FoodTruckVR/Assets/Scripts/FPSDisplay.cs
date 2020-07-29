using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private float currentFPS = 0;

    public float hudRefreshRate = 1f;
    private float timer;

    public GameObject textMeshObject;


    public void updateFPSText(string newText)
    {
        textMeshObject.GetComponent<TextMesh>().text = newText; //update the in-world text
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime > timer) //only updates the text after the refresh time
        {
            currentFPS = (int)(1f / Time.unscaledDeltaTime); //current fps number

            updateFPSText("FPS:" + currentFPS.ToString()); //new fps text

            timer = Time.unscaledTime + hudRefreshRate; //resets the refresh timer
        }
    }
}
