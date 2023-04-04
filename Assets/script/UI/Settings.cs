using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private mouseLock mouse;
    private Movement movement;

    private GameObject UI;

    private void Start()
    {
        UI = GameObject.Find("Settings");

        mouse = GameObject.Find("keep").GetComponent<mouseLock>();
        movement = GameObject.Find("Player").GetComponent<Movement>();

        UI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (UI.activeInHierarchy == false)
            {
                UI.SetActive(true);
                mouse.isLocked = false;
                movement.enabled = false;
            }

            else if (UI.activeInHierarchy == true)
            {
                UI.SetActive(false);
                mouse.isLocked = true;
                movement.enabled = true;
            }
        }
    }
}
