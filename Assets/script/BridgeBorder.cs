using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BridgeBorder : MonoBehaviour
{
    private GameObject ui;

    private void Start()
    {
        ui = GameObject.Find("MiddleText");

        ui.SetActive(false);
    }

    private async void OnCollisionEnter(Collision collision)
    {
        ui.SetActive(true);
        await Task.Delay(5000);
        ui.SetActive(false);
    }
}
