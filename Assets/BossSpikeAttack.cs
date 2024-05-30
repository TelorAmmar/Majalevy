using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossSpikeAttack : MonoBehaviour
{
    public GameObject spike;
    public GameObject player;
    public float spikeCooldown = 3f;
    float timeElapsed = 0f;

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
        if(timeElapsed < spikeCooldown)
        {
            timeElapsed += Time.deltaTime;
        }
        if(HasTarget && timeElapsed >= spikeCooldown)
        {
            SpikeAttack();
            timeElapsed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HasTarget = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HasTarget = false;
        }
    }

    public void SpikeAttack()
    {
        Vector3 dropPoint = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
        // if(timeElapsed == spikeCooldown)
        // {
            GameObject newSpike = Instantiate(spike, dropPoint, spike.transform.rotation);
        // }
    }
}
