using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject touchPanel;

    public void ReloadScene()
    {
        Time.timeScale = 1;
        if (touchPanel.active == false)
            touchPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
