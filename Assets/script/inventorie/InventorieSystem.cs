using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorieSystem : MonoBehaviour
{
    public slot[] slots = new slot[8];
    public slot weapon1, weapon2;
    public GameObject InventorieUI, mouse, hand;
    private Movement player;

    private mouseLock mouseL;

    public KeyCode inv;

    private int i;

    public LayerMask layer;

    private void Start()
    {
        InventorieUI.SetActive(false);

        mouseL = GameObject.Find("keep").GetComponent<mouseLock>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        hand = GameObject.Find("hand");
    }


    private void Update()
    {
        if (!InventorieUI.activeInHierarchy && Input.GetKeyDown(inv))
        {
            InventorieUI.SetActive(true);
            player.enabled = false;
            mouseL.isLocked = false;
        }

        else if (InventorieUI.activeInHierarchy && Input.GetKeyDown(inv) || Input.GetKeyDown(KeyCode.Escape))
        {
            InventorieUI.SetActive(false);
            player.enabled = true;
            mouseL.isLocked = true;


            if (mouse.GetComponent<slot>().amountInSlot != 0)
            {
                if (mouse.GetComponent<slot>().itemInSlot.type == Item.Types.weapon)
                {
                    if (weapon1.itemInSlot == null)
                    {
                        weapon1.itemInSlot = mouse.GetComponent<slot>().itemInSlot;
                        weapon1.amountInSlot = mouse.GetComponent<slot>().amountInSlot;

                        mouse.GetComponent<slot>().itemInSlot = null;
                        mouse.GetComponent<slot>().amountInSlot = 0;
                    }

                    else if (weapon2.itemInSlot == null)
                    {
                        weapon2.itemInSlot = mouse.GetComponent<slot>().itemInSlot;
                        weapon2.amountInSlot = mouse.GetComponent<slot>().amountInSlot;

                        mouse.GetComponent<slot>().itemInSlot = null;
                        mouse.GetComponent<slot>().amountInSlot = 0;
                    }
                }

                else
                {
                    restore(mouse.GetComponent<slot>());
                    mouse.GetComponent<slot>().itemInSlot = null;
                    mouse.GetComponent<slot>().amountInSlot = 0;
                }
            }
        }
    }

    public void PickUpItem(ItemPickup obj)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemInSlot != null && slots[i].itemInSlot.itemId == obj.ItemStats.itemId && slots[i].amountInSlot != slots[i].itemInSlot.maxStack)
            {
                if (!WillHitMaxStack(i, obj.amount))
                {
                    slots[i].amountInSlot += obj.amount;

                    if (obj.infinitAmmo == false)
                    {
                        Destroy(obj.gameObject);
                    }
                    return;
                }

                else
                {
                    int result = NeededToFill(i);
                    obj.amount = RemainingAmount(i, obj.amount);
                    slots[i].amountInSlot += result;
                    PickUpItem(obj);

                    if (obj.infinitAmmo == false)
                    {
                        Destroy(obj.gameObject);
                    }
                    return;
                }
            }

            else if (slots[i].itemInSlot == null)
            {
                slots[i].itemInSlot = obj.ItemStats;
                slots[i].amountInSlot += obj.amount;

                if (obj.infinitAmmo == false)
                {
                    Destroy(obj.gameObject);
                }
                return;
            }
        }
    }    
    
    public void restore(slot obj)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemInSlot != null && slots[i].itemInSlot.itemId == obj.itemInSlot.itemId && slots[i].amountInSlot != slots[i].itemInSlot.maxStack)
            {
                if (!WillHitMaxStack(i, obj.amountInSlot))
                {
                    slots[i].amountInSlot += obj.amountInSlot;
                    return;
                }

                else
                {
                    int result = NeededToFill(i);
                    obj.amountInSlot = RemainingAmount(i, obj.amountInSlot);
                    slots[i].amountInSlot += result;
                    restore(obj);
                    return;
                }
            }

            else if (slots[i].itemInSlot == null)
            {
                slots[i].itemInSlot = obj.itemInSlot;
                slots[i].amountInSlot += obj.amountInSlot;
                return;
            }
        }
    }

    bool WillHitMaxStack(int index, int amount)
    {

        if (slots[index].itemInSlot.maxStack < slots[index].amountInSlot + amount)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    int NeededToFill(int index)
    {
        return (slots[index].itemInSlot.maxStack - slots[index].amountInSlot);
    }
    int RemainingAmount(int index, int amount)
    {
        return (slots[index].amountInSlot + amount - slots[index].itemInSlot.maxStack);
    }

    public void weaponV(ItemPickup obj)
    {
        print(obj.ItemStats.itemId);

        if (weapon1.itemInSlot == null)
        {
            weapon1.itemInSlot = obj.ItemStats;
            weapon1.amountInSlot = obj.amount;
            Destroy(obj.gameObject);
        }

        else if (weapon2.itemInSlot == null)
        {
            weapon2.itemInSlot = obj.ItemStats;
            weapon2.amountInSlot = obj.amount;
            Destroy(obj.gameObject);
        }
    }
}
