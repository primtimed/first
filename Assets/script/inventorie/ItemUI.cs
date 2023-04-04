using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    private TextMeshProUGUI ui;
    private Canvas canvas;

    private ItemPickup item;

    private GameObject player;

    public float distence;

    private void Start()
    {
        player = GameObject.Find("Player");

        ui = GetComponentInChildren<TextMeshProUGUI>();
        canvas = GetComponentInChildren<Canvas>();

        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        //ui.text = GetComponentInParent<ItemPickup>().ItemStats.nameItem;
        ui.text = "E to Pickup";
    }

    private void Update()
    {
        distence = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distence < 5)
        {
            ui.gameObject.SetActive(true);
            transform.LookAt (player.transform.position);
        }

        else
        {
            ui.gameObject.SetActive(false);
        }
    }
}
