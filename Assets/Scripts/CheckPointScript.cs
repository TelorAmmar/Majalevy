using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnCollider;
    private RespawnScript respawn;

    void Awake()
    {
        respawn = respawnCollider.GetComponent<RespawnScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == player.name)
        {
            respawn.respawnPoint = this.gameObject;
        }
    }
}
