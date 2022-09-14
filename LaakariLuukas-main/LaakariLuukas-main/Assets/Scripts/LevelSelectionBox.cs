using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionBox : MonoBehaviour
{
    [SerializeField]
    private Sprite unlockedImage;
    [SerializeField]
    private GameObject previewImage, levelNameText;
    public string sceneToLoad;
    public int levelId;
    private bool isLevelUnlocked = false;
    [SerializeField]
    private Text bestTimeText;

    private void Start()
    {
        Debug.Log("test");
        OpenLevel();
    }

    private void Update()
    {
    }

    private void OpenLevel()
    {
        if(levelId == 0 || LevelCompletionManager.levelsCompleted[levelId - 1] == true)
        {
            GameData data = SaveSystem.LoadGame();
            if (data != null && data.bestTimes[levelId] > 0)
            {
                bestTimeText.text = data.bestTimes[levelId].ToString("F2");
            }
            this.gameObject.GetComponent<Image>().sprite = unlockedImage;
            previewImage.SetActive(true);
            levelNameText.SetActive(true);
            isLevelUnlocked = true;
        }
    }

    public void PlayLevel()
    {
        if(isLevelUnlocked)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
