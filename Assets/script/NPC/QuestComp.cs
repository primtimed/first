using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class QuestComp : MonoBehaviour
{
    public InventorieSystem inv;

    public quests quest;

    public int amount;

    private int i;

    private TextMeshProUGUI activeQuest, have, need;

    private GameObject panel;

    public bool questComplead;

    private RaycastHit hit;

    private void Start()
    {
        panel = GameObject.Find("QuestPanel");
        have = GameObject.Find("have").GetComponent<TextMeshProUGUI>();
        need = GameObject.Find("need").GetComponent<TextMeshProUGUI>();
        activeQuest = GameObject.Find("Active quest").GetComponentInChildren<TextMeshProUGUI>();

        inv = GameObject.Find("keep").GetComponent<InventorieSystem>();
    }

    public void Update()
    {
        if (quest != null)
        {
            if (Physics.Raycast(GameObject.Find("Main Camera").transform.position, GameObject.Find("Main Camera").transform.forward, out hit, 2) && Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.tag == "King")
                {
                    questComplead = true;
                }
            }
        }

        if (questComplead == true)
        {
            if (Physics.Raycast(GameObject.Find("Main Camera").transform.position, GameObject.Find("Main Camera").transform.forward, out hit, 2) && Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.tag == "End")
                {
                    print("complead");
                }
            }
        }

        if (quest != null && questComplead == false)
        {
            activeQuest.text = quest.textNPC[quest.questslide];

            panel.SetActive(true);

            for (i = 0; i < inv.slots.Length;)
            {
                i++;

                if (inv.slots[i].itemInSlot != null && inv.slots[i].itemInSlot.itemId == quest.itemId)
                {
                    amount = inv.slots[i].amountInSlot;
                }

                //have.text = amount.ToString();
                //need.text = quest.amount.ToString();

                return;
            }
        }

        else if (quest == null && questComplead == false)
        {
            panel.SetActive(false);
            have.text = null;
            need.text = null;
            activeQuest.text = null;
        } 

        if (questComplead == true)
        {
            quest = null;

            activeQuest.text = "repear the boat and escape with the king";
        }
    }

    public void delete()
    {
        inv.slots[i].amountInSlot -= quest.amount;
    }
}
