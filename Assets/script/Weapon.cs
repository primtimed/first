using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private slot weapon;

    private GameObject loc;

    private void Start()
    {
        weapon = GameObject.Find("Slot weapon").GetComponent<slot>();
        loc = GameObject.Find("hand");
    }

    private void Update()
    {
        if (weapon != null)
        {
            //weapon.itemInSlot.prefapable
        }
    }
}
