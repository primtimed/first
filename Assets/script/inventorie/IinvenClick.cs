using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IinvenClick : MonoBehaviour
{
    public slot mouse;

    private slot test;

    private int toFill;

    private void Start()
    {
        mouse = GameObject.Find("Mouse").GetComponent<slot>();
    }
    public void click()
    {
        if (transform.GetComponent<slot>().itemInSlot != null)
        {
            if (mouse.itemInSlot == null)
            {
                    test = transform.GetComponent<slot>();

                    mouse.amountInSlot = test.amountInSlot;
                    mouse.itemInSlot = test.itemInSlot;

                    test.amountInSlot = 0;
                    test.itemInSlot = null;

                    print("test1");
            }

            else if (transform.GetComponent<slot>().itemInSlot == mouse.itemInSlot)
            {
                print("test2");

                if (transform.GetComponent<slot>().itemInSlot.maxStack > transform.GetComponent<slot>().amountInSlot + mouse.amountInSlot)
                {
                    transform.GetComponent<slot>().amountInSlot += mouse.amountInSlot;

                    mouse.itemInSlot = null;
                    mouse.amountInSlot = 0;

                    print("test2.1");
                }
                    

                else
                {
                    toFill = transform.GetComponent<slot>().itemInSlot.maxStack - transform.GetComponent<slot>().amountInSlot;
                    mouse.amountInSlot -= toFill;
                    transform.GetComponent<slot>().amountInSlot += toFill;
                }
            }
        }

        else
        {
            transform.GetComponent<slot>().itemInSlot = mouse.itemInSlot;
            transform.GetComponent<slot>().amountInSlot = mouse.amountInSlot;

            mouse.itemInSlot = null;
            mouse.amountInSlot = 0;

            print("test3");
        }
    }
}
