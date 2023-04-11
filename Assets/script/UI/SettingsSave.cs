using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsSave : MonoBehaviour
{
    public float sens, music;
    public FullScreenMode fullscreen;

    public void StartV()
    {
        music = PlayerPrefs.GetFloat("music");
        sens = PlayerPrefs.GetFloat("sens");

        print(sens);
        print(music);

        GameObject.Find("AudioSet").GetComponent<Slider>().value = music;
        GameObject.Find("Sens").GetComponent<Slider>().value = sens;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.Find("Sens").GetComponent<Slider>().value = sens;
            GameObject.Find("AudioSet").GetComponent<Slider>().value = music;

            GameObject.Find("Player").GetComponent<Movement>().sens = sens;
            GameObject.Find("Audio").GetComponent<AudioSource>().volume = music;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.Find("Sens").GetComponent<Slider>().value = sens;
            GameObject.Find("AudioSet").GetComponent<Slider>().value = music;

            GameObject.Find("Player").GetComponent<Movement>().sens = sens;
            GameObject.Find("Audio").GetComponent<AudioSource>().volume = music;
        }
            
        SettingSave("music", music);
        SettingSave("sens", sens);

        Screen.fullScreenMode = fullscreen;
    }

    public void SettingSave(string keyName, float set)
    {
        PlayerPrefs.SetFloat(keyName, set);
        PlayerPrefs.Save();

        print(PlayerPrefs.GetFloat("music"));
        print(PlayerPrefs.GetFloat("sens"));
    }
}
