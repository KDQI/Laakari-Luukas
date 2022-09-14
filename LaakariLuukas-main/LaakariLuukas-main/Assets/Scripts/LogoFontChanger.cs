using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoFontChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject logo;
    [SerializeField]
    private float minSize, maxSize, lerpSpeed;
    private float scaledSize;
    private bool isIncreasingSize;

    private void Start()
    {
        isIncreasingSize = true;
        scaledSize = 1;
    }

    private void Update()
    {
        if(scaledSize >= maxSize)
        {
            isIncreasingSize = false;
        } else if(scaledSize <= minSize)
        {
            isIncreasingSize = true;
        }

        if(isIncreasingSize)
        {
            ScaleUpLogo();
        }
        if(!isIncreasingSize)
        {
            ShrinkLogo();
        }
        logo.transform.localScale = new Vector2(scaledSize, scaledSize);
    }


    void ScaleUpLogo()
    {
        scaledSize += Time.deltaTime * lerpSpeed;
    }

    void ShrinkLogo()
    {
        scaledSize -= Time.deltaTime * lerpSpeed;
    }

}
