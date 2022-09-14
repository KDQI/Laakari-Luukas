using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{

    public GameObject pauseCanvas;
    public GameObject[] allTheStuff;
    public void PauseButton()
    {
        foreach(GameObject g in allTheStuff)
        {
            g.SetActive(false);
        }
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Continue()
    {
        foreach (GameObject g in allTheStuff)
        {
            g.SetActive(true);
        }
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
