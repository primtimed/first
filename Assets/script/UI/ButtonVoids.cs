using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonVoids : MonoBehaviour
{
    private GameObject fullScreen, DeadScreen;

    private void Start()
    {
        fullScreen = GameObject.Find("FullScreen");

        GameObject.Find("Settings").GetComponent<SettingsSave>().StartV();

        DeadScreen = GameObject.Find("Dead");

        DeadScreen.SetActive(false);
    }

    public void StartV()
    {
        SceneManager.LoadScene(sceneName: "Main");
        Time.timeScale = 1;
    }

    public void QuitV()
    {
        Application.Quit();
        Time.timeScale = 1;
    }

    public void Back()
    {
        GameObject.Find("Settings").SetActive(false);

        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.Find("keep").GetComponent<mouseLock>().isLocked = true;
            GameObject.Find("Player").GetComponent<Movement>().enabled = true;
        }
    }

    public void BackToMenuV()
    {
        SceneManager.LoadScene(sceneName: "Start Screen");
        Time.timeScale = 1;
    }

    public void Victory()
    {
        print("go");
        SceneManager.LoadScene(sceneName: "End Screen");
        Time.timeScale = 1;
    }

    public void FullScreenV()
    {
        if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            fullScreen.GetComponentInChildren<TextMeshProUGUI>().text = "FullScreen";
        }

        else if (Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            fullScreen.GetComponentInChildren<TextMeshProUGUI>().text = "Windowd";
        }

        //GameObject.Find("Settings").GetComponent<SettingsSave>().fullscreen = Screen.fullScreenMode;
    }

    public void Dead()
    {
        Time.timeScale = 0;

        DeadScreen.SetActive(true);

        GameObject.Find("keep").GetComponent<mouseLock>().isLocked = false;
        GameObject.Find("keep").GetComponent<SettingsScript>().enabled = false;
        GameObject.Find("keep").GetComponent<InventorieSystem>().enabled = false;

    }

    public void SlidersUpdate()
    {
        GameObject.Find("Settings").GetComponent<SettingsSave>().music = GameObject.Find("AudioSet").GetComponent<Slider>().value;
        GameObject.Find("Settings").GetComponent<SettingsSave>().sens = GameObject.Find("Sens").GetComponent<Slider>().value;
    }

    public void SaveData()
    {
        GameObject.Find("Settings").GetComponent<SettingsSave>().SettingSave("music", GameObject.Find("Settings").GetComponent<SettingsSave>().music);
        GameObject.Find("Settings").GetComponent<SettingsSave>().SettingSave("sens", GameObject.Find("Settings").GetComponent<SettingsSave>().sens);
    }
}
