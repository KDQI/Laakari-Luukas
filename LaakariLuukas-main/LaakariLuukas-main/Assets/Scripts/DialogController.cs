using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    private bool isDialogButtonPressed, isCollidingWithNPC;
    [SerializeField]private GameObject joystick, pauseButton;
    [SerializeField] private DialogButton dialogButton;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("NPC"))
        {
            isCollidingWithNPC = true;
            dialogButton.SwapActive();
            col.gameObject.GetComponent<NpcController>().ShowDialogSprite();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            if (isDialogButtonPressed)
            {
                collision.GetComponent<NpcController>().ShowDialog();
                HideComponents();
                isDialogButtonPressed = false;
            }
            if(collision.GetComponent<NpcController>().IsDialogCompleted())
            {
                Debug.Log("Should show joystick");
                ShowComponents();
                collision.GetComponent<NpcController>().DisableDialog();
            }
        }
    }

    public void StartDialog()
    {
        if (isCollidingWithNPC && !isDialogButtonPressed)
        {
            joystick.GetComponent<Joystick>().ResetJoystick();
            isDialogButtonPressed = true;
            StartCoroutine(StopDialogAfterWait());
        }
    }

    private IEnumerator StopDialogAfterWait()
    {
        yield return new WaitForSeconds(0.1f);
        StopDialog();
    }

    public void StopDialog()
    {
        isDialogButtonPressed = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            isCollidingWithNPC = false;
            dialogButton.SwapInactive();
            other.gameObject.GetComponent<NpcController>().HideDialogSprite();
            StopDialog();
            StartCoroutine(other.GetComponent<NpcController>().SetDialogStopToFalse());
        }
    }

    public void HideComponents()
    {
        joystick.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void ShowComponents()
    {
        joystick.SetActive(true);
        pauseButton.SetActive(true);
    }
}
