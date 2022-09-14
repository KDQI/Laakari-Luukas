using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData //Luokka, jossa kaikki tiedot mitä halutaan tallentaa säilytetään
{
    public float[] bestTimes;
    public bool[] completedLevels;


    public GameData(TimerScript ts) //Otetaan syötteenä TimerScript
    {
        bestTimes = ts.bestTimes; //Lisätään syötetyn TimerScriptin parhaat ajat tämän luokan muuttujaan talletusta varten
        completedLevels = LevelCompletionManager.levelsCompleted;
    }
}
