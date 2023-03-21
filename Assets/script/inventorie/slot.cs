using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public Item itemInSlot;
    public int amountInSlot;

    private RawImage Icon;
    private TextMeshProUGUI Text;

    private void Start()
    {
        Icon = GetComponentInChildren<RawImage>();
        Text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Update()
    {
        if (amountInSlot > 0)
        {
            Icon.enabled = true;
            Text.text = amountInSlot.ToString();
            Icon.texture = itemInSlot.icon;
        }

        else
        {
            itemInSlot = null;
            Text.text = string.Empty;
            Icon.texture = null;
            Icon.enabled = false;
        }
    }
}
