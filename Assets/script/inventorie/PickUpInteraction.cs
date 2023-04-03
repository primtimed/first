using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpInteraction : MonoBehaviour
{
    [SerializeField] LayerMask itemlayer, weapon;

    public KeyCode pickup, drop;

    private GameObject cam;
    private InventorieSystem inventorieSystem;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        inventorieSystem = GameObject.Find("keep").GetComponent<InventorieSystem>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10, itemlayer))
        {
            if (Input.GetKeyDown(pickup))
            {
                print(hit.transform.name);
                inventorieSystem.PickUpItem(hit.transform.GetComponent<ItemPickup>());
            }
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10, weapon))
        {
            if (Input.GetKeyDown(pickup))
            {
                print(hit.transform.name);
                inventorieSystem.weaponV(hit.transform.GetComponent<ItemPickup>());
            }
        }

    }
}
