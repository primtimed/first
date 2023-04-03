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

    private void Start()
    {
        have = GameObject.Find("have").GetComponent<TextMeshProUGUI>();
        need = GameObject.Find("need").GetComponent<TextMeshProUGUI>();
        activeQuest = GameObject.Find("Active quest").GetComponentInChildren<TextMeshProUGUI>();

        inv = GameObject.Find("keep").GetComponent<InventorieSystem>();
    }

    public void Update()
    {
        if (quest != null)
        {
            activeQuest.text = quest.textNPC[quest.questslide];

            for (i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].itemInSlot != null && inv.slots[i].itemInSlot.itemId == quest.itemId)
                {
                    amount = inv.slots[i].amountInSlot;
                }

                have.text = amount.ToString();
                need.text = quest.amount.ToString();

                return;
            }
        }

        else
        {
            have.text = null;
            need.text = null;
            activeQuest.text = null;
        } 
    }

    public void delete()
    {
        inv.slots[i].amountInSlot -= quest.amount;
    }
}
