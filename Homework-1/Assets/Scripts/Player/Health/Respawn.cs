using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    // Static event that will be triggered when player respawns
    public static int counter = 0;
    public UnityEvent OnPlayerRespawn;
    
    [SerializeField] GameObject respawnPoint;
    [SerializeField] LayerMask respawnLayer;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(((1 << col.gameObject.layer) & respawnLayer.value) != 0)
        {
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint.transform.position;
        counter++;
        Debug.Log("Player respawned " + counter + " times.");
            
        // Invoke the respawn event instead of directly calling HealthManager
        OnPlayerRespawn?.Invoke();
    }
    
}
