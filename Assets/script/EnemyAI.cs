using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public GameObject particle, drop;

    private NavMeshAgent agent;

    public float hp;

    private void Start()
    {
        player = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            agent.destination = player.transform.position;
        }

        if (hp <= 0)
        {
            Instantiate(particle, transform.position, transform.rotation);
            Instantiate(drop, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Character")
        {
            other.transform.GetComponent<PlayerAI>().hp -= 1;
        }
    }
}
