using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VipuScript : MonoBehaviour
{
    public static VipuScript instance;
    public GameObject questionCanvas;

    // Kutsuu animaattorin
    public Animator anim;

    public Transform gatePos;
    public float secondsUntilGateOpen;

    public Joystick joystick;
    public GameObject jumpButton;

    public GameObject wrongText;

    private void Start()
    {
        instance = this;
        questionCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ShowQuestion();
            AudioManager.instance.Play("Vipu");
        }
    }

    void ShowQuestion()
    {
        jumpButton.SetActive(false);
        questionCanvas.SetActive(true);
        joystick.gameObject.SetActive(false);
        joystick.ResetJoystick();
    }


    // T‰t‰ funktiota kutsutaan kun pelaaja painaa oikeata vastaus nappulaa kysymyksen aikana.
    public void RightAnswer()
    {
        questionCanvas.SetActive(false);
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        AudioManager.instance.Play("RA");
        StartCoroutine(MainCamera.instance.MoveToTarget(gatePos.transform.position, 2));
        StartCoroutine(OpenGateAfterSeconds());
    }

    // T‰t‰ funktiota kutsutaan kun pelaaja painaa v‰‰r‰‰ vastaus nappulaa kysymyksen aikana.
    public void WrongAsnwer()
    {
        SetDefaults();
        wrongText.SetActive(true);
        AudioManager.instance.Play("WA");
    }

    public void SetDefaults()
    {
        questionCanvas.SetActive(false);
        jumpButton.SetActive(true);
        joystick.gameObject.SetActive(true);
        joystick.FixJoystick();
    }

    private IEnumerator OpenGateAfterSeconds()
    {
        yield return new WaitForSeconds(secondsUntilGateOpen);
        anim.SetTrigger("Gate");
        AudioManager.instance.Play("Portti");
      
    }
}


