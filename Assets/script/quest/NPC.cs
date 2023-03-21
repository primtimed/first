using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private mouseLock mouse;

    public quests quests;
    public NPCTalk conversasion;

    private GameObject player;
    private TextMeshProUGUI textMeshPro, activeQuest;
    public GameObject npcCam, yesorno;

    public int questSlide;
    private int slide, quest;

    private float timer;

    private static bool questAccept;

    public NPCtype type;

    public enum NPCtype
    {
        main,
        side
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        mouse = GameObject.Find("keep").GetComponent<mouseLock>();
        activeQuest = GameObject.Find("Active quest").GetComponentInChildren<TextMeshProUGUI>();

        slide = 0;
        quest = Random.Range(0, 2);

        if (type  == NPCtype.main)
        {
            conversasion.conversasion[1] = quests.main[quest];
        }

        if (type == NPCtype.side)
        {
            conversasion.conversasion[1] = quests.side[quest];
        }
    }

    public async void Update()
    {
        timer += Time.deltaTime;

        textMeshPro.text = conversasion.conversasion[slide].ToString();

        if (Vector3.Distance(player.transform.position, transform.position) < 5 && timer > 5 && questAccept == false)
        {
            player.SetActive(false);
            npcCam.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space) && yesorno.activeSelf == false)
            {
                slide ++;
            }
        }
                                                                          
        else
        {
            player.SetActive(true);
            npcCam.SetActive(false);

            yesorno.SetActive(false);

            if (questAccept != true)
            {
                textMeshPro.text = null;
            }
        }

        if (slide == questSlide)
        {
            yesorno.SetActive(true);
            mouse.isLocked = false;
        }

        if (activeQuest == true)
        {
            await Task.Delay(3000);

            slide = questSlide + 1;
        }
    }

    public void Yes()
    {
        player.SetActive(true);
        npcCam.SetActive(false);
        yesorno.SetActive(false);

        activeQuest.text = conversasion.conversasion[1];

        mouse.isLocked = true;
        questAccept = true;

        slide = 2;
        timer = 0;
    }

    public void no()
    {
        player.SetActive(true);
        npcCam.SetActive(false);
        yesorno.SetActive(false);
        mouse.isLocked = true;

        slide = 0;
        timer = 0;
    }
}
