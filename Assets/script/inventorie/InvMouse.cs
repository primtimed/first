using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InvMouse : MonoBehaviour
{
    public Vector3 mousePosition;

    public GameObject mouse, test2, player, spawnedObject;

    private Vector3 v3;
    private RaycastHit hit;

    private void Start()
    {
        mousePosition.z = -50;
    }

    private void Update()
    {
        mousePosition.x = Input.mousePosition.x;
        mousePosition.y = Input.mousePosition.y;

        mouse.transform.position = mousePosition;

        if(mouse.GetComponent<slot>().itemInSlot != null)
        {
            test2.SetActive(true);
        }

        else
        {
            test2.SetActive(false);
        }

        if (mouse.GetComponent<slot>().itemInSlot && Input.GetKeyDown(KeyCode.Q))
        {
            spawnedObject = Instantiate(mouse.GetComponent<slot>().itemInSlot.prefap, player.transform.position, player.transform.rotation);

            spawnedObject.GetComponent<ItemPickup>().amount = mouse.GetComponent<slot>().amountInSlot;

            mouse.GetComponent<slot>().amountInSlot = 0;
            mouse.GetComponent<slot>().itemInSlot = null;
        }

        Debug.DrawRay(mouse.transform.position, transform.forward * 100, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100) && Input.GetKeyDown(KeyCode.Q))
        {
            print(hit.transform.name);
        }
    }
}
