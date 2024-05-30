using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class ItemDropper : MonoBehaviour
{
    public float flightSpeed = 20f;
    public float waypointReachedDistance = 0.1f;
    public DetectionZone attackDetectionZone;
    public List<Transform> waypoints;
    public GameObject pickup;
    public float dropTime = 2f;
    public float timeSinceDrop = 0f;

    Rigidbody2D rb;

    Transform nextWaypoint;
    int waypointNum = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoints[waypointNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Flight();
        if(timeSinceDrop > dropTime)
        {
            DropItem();
            timeSinceDrop = 0f;
        }
        timeSinceDrop += Time.deltaTime;
    }

    private void Flight()
    {
        // fly to next waypoint
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        // check if waypoint reached
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;
        UpdateDirection();
        // switch to other waypoints?
        if(distance <= waypointReachedDistance)
        {
            // switch to next
            waypointNum++;

            if(waypointNum >= waypoints.Count)
            {
                // loop waypoint
                waypointNum = 0;
            }

            nextWaypoint = waypoints[waypointNum];
        }
    }

    private void UpdateDirection()
    {
        Vector3 locScale = transform.localScale;
        
        if(transform.localScale.x > 0)
        {
            if(rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
        else
        {
            if(rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
    }

    private void DropItem()
    {
        GameObject dropItem = Instantiate(pickup, transform.position, transform.rotation);
        dropItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        dropItem.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        dropItem.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        Destroy(dropItem, 10);
    }
}
