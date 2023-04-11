using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private async void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Player").GetComponent<PlayerAI>().weapon != null == GameObject.Find("Player").GetComponent<PlayerAI>().swing == false)
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<Animator>().enabled = true;

            GameObject.Find("Player").GetComponent<PlayerAI>().swing = true;

            await Task.Delay(333);

            GameObject.Find("Player").GetComponent<PlayerAI>().swing = false;
        }

        else if (GameObject.Find("Player").GetComponent<PlayerAI>().swing == false)
        { 
            GetComponent<Collider>().enabled = false;
            GetComponent<Animator>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<EnemyAI>().hp -= 1;
        }
    }
}
