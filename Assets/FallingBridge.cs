using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridge : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    Damageable damageable;
    Vector3 startingPosition;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
        Vector3 startingPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(!damageable.IsAlive)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 2f;
        }
        if(Mathf.Abs(transform.position.x - startingPosition.x) > 0)
        {
            transform.position = new Vector3(startingPosition.x, transform.position.y, transform.position.z);
        }
        
    }
}
