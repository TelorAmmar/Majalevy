using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossSummonAttack : MonoBehaviour
{
    public GameObject spike;
    public GameObject player;
    public GameObject groundSummon;
    public GameObject flyingSummon;
    public List<Transform> waypoints;
    public float spikeCooldown = 3f;
    public float groundSummonCooldown = 8f;
    public float flyingSummonCooldown = 10f;
    float spikeTimeElapsed = 0f;
    float groundTimeElapsed = 0f;
    float flyingTimeElapsed = 0f;

    public bool _hasTarget = false;

    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spikeTimeElapsed < spikeCooldown)
        {
            spikeTimeElapsed += Time.deltaTime;
        }
        if(HasTarget && spikeTimeElapsed >= spikeCooldown)
        {
            SpikeAttack(SummonPosition());
            spikeTimeElapsed = 0;
        }
        if(groundTimeElapsed < groundSummonCooldown)
        {
            groundTimeElapsed += Time.deltaTime;
        }
        if(HasTarget && groundTimeElapsed >= groundSummonCooldown)
        {
            SummonGroundEnemy(SummonPosition());
            groundTimeElapsed = 0;
        }
        if(flyingTimeElapsed < flyingSummonCooldown)
        {
            flyingTimeElapsed += Time.deltaTime;
        }
        if(HasTarget && flyingTimeElapsed >= flyingSummonCooldown)
        {
            SummonFlyingEnemy();
            flyingTimeElapsed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HasTarget = true;
            player = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HasTarget = false;
            player = null;
        }
    }

    Vector3 SummonPosition()
    {
        Vector3 dropPoint = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
        return dropPoint;
    }

    public void SpikeAttack(Vector3 dropPoint)
    {
        GameObject newSpike = Instantiate(spike, dropPoint, spike.transform.rotation);
    }

    public void SummonGroundEnemy(Vector3 dropPoint)
    {
        GameObject newGroundSummon = Instantiate(groundSummon, dropPoint, groundSummon.transform.rotation);
        newGroundSummon.GetComponent<Damageable>().MaxHealth = 10;
        newGroundSummon.GetComponent<Damageable>().Health = 10;
    }

    public void SummonFlyingEnemy()
    {
        GameObject newFlyingSummon = Instantiate(flyingSummon, waypoints[0].position, flyingSummon.transform.rotation);
        newFlyingSummon.GetComponent<FlyingEnemy>().waypoints = waypoints;
        newFlyingSummon.GetComponent<FlyingEnemy>().flightSpeed = 10;
        newFlyingSummon.GetComponent<Damageable>().MaxHealth = 2;
        newFlyingSummon.GetComponent<Damageable>().Health = 2;
    }
}
