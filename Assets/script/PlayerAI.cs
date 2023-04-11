using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAI : MonoBehaviour
{
    public float hp;

    public GameObject [] hpHard;

    public GameObject handSlot, hand, weapon;
    private slot slot;

    public bool swing;

    private void Start()
    {
        hand = GameObject.Find("hand");
        slot = GameObject.Find("Slot weapon").GetComponent<slot>();
    }

    private void Update()
    {
        if (slot.itemInSlot != null)
        {
            handSlot = slot.itemInSlot.prefap;
        }

        for (int i = 0; i < 5; i++)
        {
            if (i <= hp -1)
            {
                hpHard[i].transform.GetComponent<RawImage>().enabled = true;
            }

            else
            {
                hpHard[i].transform.GetComponent<RawImage>().enabled = false;
            }
        }

        if (hp <= 0)
        {
            GameObject.Find("keep").GetComponent<ButtonVoids>().Dead();

            Destroy(gameObject);
        }

        if (handSlot != null && weapon == null)
        {
            weapon = Instantiate(handSlot.gameObject);

            weapon.transform.SetParent(hand.transform, true);
        }

        if (weapon != null)
        {
            weapon.GetComponent<Rigidbody>().useGravity = false;
            weapon.GetComponent<Collider>().isTrigger = true;
            weapon.transform.localPosition = Vector3.zero; ;
            weapon.transform.localEulerAngles = Vector3.zero;
            weapon.transform.localScale = Vector3.one;
        }
    }
}
