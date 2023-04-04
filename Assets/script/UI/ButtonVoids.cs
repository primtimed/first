using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonVoids : MonoBehaviour
{
    public GameObject fullScreen;

    private void Start()
    {
        fullScreen = GameObject.Find("FullScreen");
    }


    public void StartV()
    {
        SceneManager.LoadScene(sceneName: "Main");
    }

    public void QuitV()
    {
        Application.Quit();
    }

    public void BackToMenuV()
    {
        SceneManager.LoadScene(sceneName: "Start Screen");
    }

    public void FullScreenV()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            fullScreen.GetComponentInChildren<TextMeshProUGUI>().text = "Windowed";
        }

        else if (!Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            fullScreen.GetComponentInChildren<TextMeshProUGUI>().text = "FullScreen";
        }
    }
}
