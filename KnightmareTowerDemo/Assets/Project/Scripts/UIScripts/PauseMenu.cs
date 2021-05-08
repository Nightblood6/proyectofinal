using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public static bool gameisPause = false;
    public GameObject pauseMenuUI;
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameisPause)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }    
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameisPause = false;
    }

    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameisPause = true;
    }

    public void LoadMenu(int sceneIndex) 
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsync(sceneIndex));
    }

    public void Exit() 
    {
        Debug.Log("Saliendo...");
        Application.Quit();
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
