using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData //Luokka, jossa kaikki tiedot mit� halutaan tallentaa s�ilytet��n
{
    public float[] bestTimes;
    public bool[] completedLevels;


    public GameData(TimerScript ts) //Otetaan sy�tteen� TimerScript
    {
        bestTimes = ts.bestTimes; //Lis�t��n sy�tetyn TimerScriptin parhaat ajat t�m�n luokan muuttujaan talletusta varten
        completedLevels = LevelCompletionManager.levelsCompleted;
    }
}
