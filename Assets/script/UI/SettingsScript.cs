using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private mouseLock mouse;
    private Movement movement;

    public GameObject UI;

    private void Start()
    {
        UI = GameObject.Find("Settings");
        UI.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            mouse = GameObject.Find("keep").GetComponent<mouseLock>();
            movement = GameObject.Find("Player").GetComponent<Movement>();
        }

        else
        {
            GameObject.Find("keep").GetComponent<mouseLock>().isLocked = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (UI.activeInHierarchy == false)
            {
                print("SettingsUI");

                UI.SetActive(true);

                Time.timeScale = 0;

                GameObject.Find("AudioSet").GetComponent<Slider>().value = GameObject.Find("Settings").GetComponent<SettingsSave>().music;
                GameObject.Find("Sens").GetComponent<Slider>().value = GameObject.Find("Settings").GetComponent<SettingsSave>().sens;
                Screen.fullScreenMode = GameObject.Find("Settings").GetComponent<SettingsSave>().fullscreen;

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    mouse.isLocked = false;
                    movement.enabled = false;
                }
            }

            else if (UI.activeInHierarchy == true)
            {
                UI.SetActive(false);

                Time.timeScale = 1;

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    mouse.isLocked = true;
                    movement.enabled = true;
                }
            }
        }
    }
}
