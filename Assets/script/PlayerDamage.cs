using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Player").GetComponent<PlayerAI>().weapon != null)
        {
            GetComponent<Collider>().enabled = true;
        }

        else 
        { 
            GetComponent<Collider>().enabled = false;
        }
    }

    private async void OnTriggerStay(Collider other)
    {
        GameObject.Find("Player").GetComponent<PlayerAI>().swing = true;

        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<EnemyAI>().hp -= 1;
        }

        await Task.Delay(2500);

        GameObject.Find("Player").GetComponent<PlayerAI>().swing = false;
    }
}
