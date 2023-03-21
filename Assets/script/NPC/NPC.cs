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
    public int slide, quest;

    private float timer;

    private void Start()
    {
        player = GameObject.Find("Player");
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        mouse = GameObject.Find("keep").GetComponent<mouseLock>();
        activeQuest = GameObject.Find("Active quest").GetComponentInChildren<TextMeshProUGUI>();

        slide = 0;
        quest = Random.Range(0, 2);
    }

    public async void Update()
    {
        timer += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) < 5 && timer > 5 && quests.questAccept == false)
        {
            player.SetActive(false);
            npcCam.SetActive(true);

            textMeshPro.text = conversasion.conversasion[slide];

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

            if (quests.questAccept == false && timer < 1)
            { 
                textMeshPro.text = null;
            }
        }

        if (slide == questSlide && quests.questAccept == false)
        {
            textMeshPro.text = quests.quest[quest];
            yesorno.SetActive(true);
            mouse.isLocked = false;
        }

        if (quests.questAccept == true)
        {
            await Task.Delay(5000);

            textMeshPro.text = null;
        }
    }

    public void Yes()
    {
        player.SetActive(true);
        npcCam.SetActive(false);
        yesorno.SetActive(false);

        mouse.isLocked = true;

        timer = 0;
        slide = 2;

        textMeshPro.text = conversasion.conversasion[slide];

        quests.questAccept = true;
    }

    public async void no()
    {
        player.SetActive(true);
        npcCam.SetActive(false);
        yesorno.SetActive(false);

        mouse.isLocked = true;

        slide = 3;

        textMeshPro.text = conversasion.conversasion[slide];

        await Task.Delay(5000);

        slide = 0;
        timer = 0;
    }
}
