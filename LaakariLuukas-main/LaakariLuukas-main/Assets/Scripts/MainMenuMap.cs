using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMap : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        anim.SetTrigger("LvlDone");
    }

}
