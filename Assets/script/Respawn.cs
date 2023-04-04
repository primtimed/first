using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject spawn, player;

    public KeyCode spawnKey;

    private void Start()
    {
        spawn = GameObject.Find("spawnloc");
        player = GameObject.Find("Player"); 
    }

    private void Update()
    {
         if(Input.GetKeyDown(spawnKey))
        {
            player.transform.position = spawn.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = spawn.transform.position;
    }
}
