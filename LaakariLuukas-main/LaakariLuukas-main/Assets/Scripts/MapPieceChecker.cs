using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPieceChecker : MonoBehaviour
{
    public static MapPieceChecker instance;
    [SerializeField] private GameObject[] mapPieces;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject jumpButton;
    Transform chosenPiece;

    private void Start()
    {
        instance = this;
    }

    public void CheckIfOnePieceRemaining()
    {
        int amountActive = 0;
        foreach(GameObject g in mapPieces)
        {
            if(g.activeSelf)
            {
                amountActive++;
                chosenPiece = g.transform;
            }
        }

        if(amountActive == 1)
        {
            joystick.SetActive(false);
            jumpButton.SetActive(false);
            joystick.GetComponent<Joystick>().ResetJoystick();
            StartCoroutine(MainCamera.instance.MoveToTarget(chosenPiece.transform.position, 2));
        }

    }
}
