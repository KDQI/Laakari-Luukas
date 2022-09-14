using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [HideInInspector]
    public float[] bestTimes = new float[5];
    public int levelId;
    bool timerCanMove;
    float timer;
    public Text timerText;

    public bool objective;

    public GameObject uIcanvas;
    public GameObject levelOverCanvas;
    public TextMeshProUGUI thisRunsTime;
    public TextMeshProUGUI bestTime;

    public FixedJoystick fJoyStick;

    void Start()
    {
        GameData data = SaveSystem.LoadGame(); //Ladataan tallennetut tiedot (jos on) muuttujaan data
        if(data != null)
        {
            bestTimes = data.bestTimes; //Asetetaan parhaat ajat muuttujaan tallennettuihin parhaisiin aikoihin
        }
        timerCanMove = true;


    }

    void Update()
    {
        timerText.text = timer.ToString("F2");
        if (timerCanMove == true)
        {
            timer += Time.deltaTime;
        }
        CheckIfMissionComplete();


    }

    void CheckIfMissionComplete()
    {
        if (objective == true)
        {
            if(bestTimes[levelId] > timer || bestTimes[levelId] == 0f)
            {
                bestTimes[levelId] = timer;
            }
            timerCanMove = false;
            GameData data = SaveSystem.LoadGame();
            fJoyStick.ResetJoystick();
            if(timer >= 60)
            {
                thisRunsTime.text = "Nykyinen aika " + (timer / 60).ToString("F0") + " Minuuttia ja " + (timer % 60).ToString("F0") + " Sekuntia";
            } else
            {
                thisRunsTime.text = "Nykyinen aika 0 Minuuttia ja " + (timer % 60).ToString("F0") + " Sekuntia";
            }
            LevelCompletionManager.SetLevelCompleted(levelId);
            SaveSystem.SaveGame(this);
            if(data.bestTimes[levelId] >= 60)
            {
                bestTime.text = "Paras aika " + (data.bestTimes[levelId] / 60).ToString("F0") + " Minuuttia ja " + (data.bestTimes[levelId] % 60).ToString("F0") + " Sekuntia";
            }else
            {
                bestTime.text = "Paras aika 0 Minuuttia ja " + (data.bestTimes[levelId] % 60).ToString("F0") + " Sekuntia";
            }
            
            uIcanvas.SetActive(false);
            levelOverCanvas.SetActive(true);
        }
    }
}
