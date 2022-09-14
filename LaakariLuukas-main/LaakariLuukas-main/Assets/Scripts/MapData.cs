using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapData : MonoBehaviour
{
    public Text mapCountText; 
    public float mapCount;
    private float maxMapCount = 10;
    public static MapData instance;

    public TimerScript ts;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {          
        CheckIfAllMapsCollected();       
    }

    void CheckIfAllMapsCollected()
    {
        mapCountText.text = mapCount.ToString("0") + "/10";  // T‰m‰ muuttaa MapCountTextin samaksi kun MapCount ja lis‰‰ per‰‰n x/10 tesktin selvyytt‰ varten.

        // Jos mapCount on yht‰suuri kuin maxMapCount TimeScripti.cs muuttuja objective muuttuu todeksi.
        if (mapCount == maxMapCount)
        {
            ts.objective = true;
        }
    }
}
