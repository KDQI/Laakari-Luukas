using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour
{
    [SerializeField]
    private Sprite activeSprite, inactiveSprite;

    public void SwapActive()
    {
        this.GetComponent<Image>().sprite = activeSprite;
    }

    public void SwapInactive()
    {
        this.GetComponent<Image>().sprite = inactiveSprite;
    }
}
