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

    public GameObject panel, king, spawnKing;

    public bool questComplead;

    private RaycastHit hit;

    private void Start()
    {
        panel = GameObject.Find("QuestPanel");
        king = GameObject.Find("King");
        spawnKing = GameObject.Find("KingSpawn");

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
                    print("King");
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

                    GameObject.Find("keep").GetComponent<ButtonVoids>().Victory();
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
            panel.SetActive(false);
            activeQuest.text = null;
            quest = null;

            king.transform.position = spawnKing.transform.position;
        }
    }

    public void delete()
    {
        inv.slots[i].amountInSlot -= quest.amount;
    }
}
