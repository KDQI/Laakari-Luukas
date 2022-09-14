using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionManager : MonoBehaviour
{

    // Allaolevat public muutujat ovat molemmat taulukkoja sen huomaa [] merkeistä. Taulukko aina alkaa luvusta 0.
    public GameObject[] mapParts = new GameObject[5];
    public static bool[] levelsCompleted = new bool[5];

    private void Update()
    {
        // Kutsuu RevealMaps funktion
        RevealMaps();   
    }

    public static void SetLevelCompleted(int lvl)
    {
        if(lvl < 4)
        {
            levelsCompleted[lvl] = true;
        } else
        {
            Debug.LogError("Invalid level ID given");
        }
    }

    public static void SetCompletedLevels(bool[] lvls)
    {
        levelsCompleted = lvls;
    }

    public static void ClearCompletedLevels()
    {
        for(int i = 0; i < levelsCompleted.Length; i++)
        {
            levelsCompleted[i] = false;
        }
    }

    void RevealMaps()
    {
        // Avaa ykköskarttanpalan JOS ensimmäinen leveli on valmis
        if (levelsCompleted[0])
        {
            mapParts[0].SetActive(true);
        }
        // Avaa kakkoskartanpalan JOS toinen leveli on valmis
        if (levelsCompleted[1])
        {
            mapParts[1].SetActive(true);
        }
        // Avaa kolmoskartanpalan JOS kolmas leveli on valmis
        if (levelsCompleted[2])
        {
            mapParts[2].SetActive(true);
        }
        // Avaa neloskartanpalan JOS neljäs leveli on valmis
        if (levelsCompleted[3])
        {
            mapParts[3].SetActive(true);
        }
        // Avaa vitoskartanpalan JOS viides leveli on valmis
        if (levelsCompleted[4])
        {
            mapParts[4].SetActive(true);
        }
    }
}
