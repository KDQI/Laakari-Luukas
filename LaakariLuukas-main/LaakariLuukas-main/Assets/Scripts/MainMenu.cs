using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    //public Text[] times; //Viittaukset tekstikenttiin, joissa parhaat ajat n‰ytet‰‰n menussa

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        GameData data = SaveSystem.LoadGame(); //Ladataan tallennetut tiedot (jos on) muuttujaan data
        if (data != null)
        {
            LevelCompletionManager.SetCompletedLevels(data.completedLevels);
        }else
        {
            LevelCompletionManager.ClearCompletedLevels();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}