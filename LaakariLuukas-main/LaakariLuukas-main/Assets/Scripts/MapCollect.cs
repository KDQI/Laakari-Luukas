using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCollect : MonoBehaviour
{

    // T‰m‰ funktio katsoo kun pelaaja osuu kartanpalaseen ja lis‰‰ aikaisemmin viitatut MapData scriptin mapCount floattiin yhden.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("MapCollect");
            MapData.instance.mapCount++;
            this.gameObject.SetActive(false);
            MapPieceChecker.instance.CheckIfOnePieceRemaining();
        }
    }
}
