using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    public GameObject TutorialPanel;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void HidePanel()
    {
        Time.timeScale = 1;
        TutorialPanel.SetActive(false);
    }
}
