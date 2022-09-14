using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongText : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(CloseTimer());
    }

    IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
