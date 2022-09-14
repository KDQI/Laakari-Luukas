using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettingsManager : MonoBehaviour
{
    [SerializeField]
    private Image volumeButton, musicButton;
    [SerializeField]
    private Sprite volumeOnSprite, volumeOffSprite, musicOnSprite, musicOffSprite;
    public bool isVolumeOn, isMusicOn;
    public static GameSettingsManager instance;

    private void Start()
    {
        instance = this;
        if(AudioManager.instance.isSoundMuted)
        {
            volumeButton.sprite = volumeOffSprite;
            isVolumeOn = false;
        }else
        {
            volumeButton.sprite = volumeOnSprite;
            isVolumeOn = true;
        }

        if(AudioManager.instance.isMusicMuted)
        {
            musicButton.sprite = musicOffSprite;
            isMusicOn = false;
        }else
        {
            musicButton.sprite = musicOnSprite;
            isMusicOn = true;
        }
    }

    public void SwitchVolume()
    {
        isVolumeOn = !isVolumeOn;
        if(isVolumeOn)
        {
            volumeButton.sprite = volumeOnSprite;
            AudioManager.instance.isSoundMuted = false;
        } else
        {
            volumeButton.sprite = volumeOffSprite;
            AudioManager.instance.isSoundMuted = true;
        }
    }

    public void SwitchMusic()
    {
        
        isMusicOn = !isMusicOn;
        if (isMusicOn)
        {          
            musicButton.sprite = musicOnSprite;
            AudioManager.instance.isMusicMuted = false;
            AudioManager.instance.Play("bgm");
            Debug.Log("SOITA BANJOA");
        }
        else
        {                     
            musicButton.sprite = musicOffSprite;
            AudioManager.instance.isMusicMuted = true;
            AudioManager.instance.StopPlay("bgm");
        }
        instance = this;
    }

    public void DeleteSaveFile()
    {
        SaveSystem.DeleteSaveFile();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
