using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeadMenu : MonoBehaviour
{

    public GameObject deadMenuUI;
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;


    public void Endgame()
    {
        deadMenuUI.SetActive(true);
    }

    
    public void LoadMenu(int sceneIndex)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);
            slider.value = progress;
            progressText.text = "Loading..." + progress * 100f + "%";

            yield return null;
        }
    }
}
