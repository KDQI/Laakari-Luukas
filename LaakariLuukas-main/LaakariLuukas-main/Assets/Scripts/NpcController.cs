using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcController : MonoBehaviour
{
    public GameObject dialog;
    public GameObject dialogSprite;
  
    public void ShowDialog()
    {
        dialog.SetActive(true);
    }

    public void ShowDialogSprite()
    {
        dialogSprite.SetActive(true);
    }

    public void HideDialogSprite()
    {
        dialogSprite.SetActive(false);
    }

    public void DisableDialog()
    {
        dialog.SetActive(false);
    }

    public bool IsDialogCompleted()
    {
        return dialog.GetComponent<Flowchart>().GetBooleanVariable("DialogStop");
    }

    public IEnumerator SetDialogStopToFalse()
    {
        yield return new WaitForSeconds(1f);
        dialog.GetComponent<Flowchart>().SetBooleanVariable("DialogStop", false);
    }

}
