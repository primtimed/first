using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class BridgeBorder : MonoBehaviour
{
    private TextMeshProUGUI ui;

    public string text;

    private void Start()
    {
       ui = GameObject.Find("TextMiddelScreen").GetComponent<TextMeshProUGUI>(); 
    }

    private async void OnCollisionEnter(Collision collision)
    {
        ui.text = text;

        await Task.Delay(5000);

        ui.text = null;
    }
}
