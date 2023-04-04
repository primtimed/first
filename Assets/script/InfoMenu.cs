using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    public KeyCode menuToggle;

    private GameObject infoMenu;

    private void Start()
    {
        infoMenu = GameObject.Find("KeyBindsInfo");
    }
    private void Update()
    {
        if (infoMenu.gameObject.activeInHierarchy == false && Input.GetKeyDown(menuToggle))
        {
            infoMenu.SetActive(true);
        }

        else if (infoMenu.gameObject.activeInHierarchy && Input.GetKeyDown(menuToggle))
        {
            infoMenu.SetActive(false);
        }
    }
}
