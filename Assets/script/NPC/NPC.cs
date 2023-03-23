using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private mouseLock mouse;

    public  quests[] quests;
    public QuestComp compl;

    private GameObject player;
    private TextMeshProUGUI textMeshPro;
    public GameObject npcCam, yesorno;

    public int slide, quest;

    private float timer;

    public static bool questAccept;

    private void Start()
    {
        player = GameObject.Find("Player");
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        mouse = GameObject.Find("keep").GetComponent<mouseLock>();

        slide = 0;

        questAccept = false;
    }

    public async void Update()
    {
        timer += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) < 5 && timer > 5 && questAccept == false)
        {
            player.SetActive(false);
            npcCam.SetActive(true);

            textMeshPro.text = quests[quest].textNPC[slide];

            if (yesorno.activeSelf == false && slide < quests[quest].questslide && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                slide ++;
            }

            if (slide == quests[quest].questslide)
            {
                yesorno.SetActive(true);
                mouse.isLocked = false;
            }
        }

        else if (Vector3.Distance(player.transform.position, transform.position) < 5 && questAccept == true)
        {
            if (compl.amount >= compl.quest.amount)
            {
                look();
            }

            else if (timer > 5)
            {
                slide = quests[quest].questslide + 3;
                textMeshPro.text = quests[quest].textNPC[slide];

                await Task.Delay(2000);

                textMeshPro.text = null;
            }
        }

        else
        {
            player.SetActive(true);
            npcCam.SetActive(false);

            yesorno.SetActive(false);
        }
    }

    public async void Yes()
    {
        player.SetActive(true);
        npcCam.SetActive(false);
        yesorno.SetActive(false);

        mouse.isLocked = true;

        timer = 0;
        slide = quests[quest].questslide + 1;

        textMeshPro.text = quests[quest].textNPC[slide];

        await Task.Delay(2000);

        questAccept = true;
        compl.quest = quests[quest];
                                                            
        textMeshPro.text = null;                    
    }
                                                        
    public async void no()
    {
        player.SetActive(true);
        npcCam.SetActive(false);
        yesorno.SetActive(false);

        mouse.isLocked = true;

        timer = 0;
        slide = quests[quest].questslide + 2;

        textMeshPro.text = quests[quest].textNPC[slide];

        await Task.Delay(2000);

        questAccept = false;

        textMeshPro.text = null;

        slide = 0;
    }

    public async void look()
    {
        compl.delete();

        compl.amount = 0;

        slide = quests[quest].questslide + 4;
        textMeshPro.text = quests[quest].textNPC[slide];

        await Task.Delay(3000);

        compl.quest = null;
        questAccept = false;
    }
}
