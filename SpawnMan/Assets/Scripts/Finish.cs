using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    
    public GameObject canvas;
    public GameObject Camera2;
    public GameObject Camera1;
    public GameObject touchPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCharacter")
        {
            if(canvas.active == false)
            {
                canvas.SetActive(true);
                if(touchPanel.active == true)
                    touchPanel.SetActive(false);
            }
            if (Camera1.active == true)
                Camera1.SetActive(false);
            if(Camera2.active == false)
                Camera2.SetActive(true);
            Time.timeScale = 0;
        }
    }
}


