using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    public GameObject arrow;
    public GameObject hitbox;
    public float fadeTime = 2.0f;
    private float elapsedTime = 0f;
    SpriteRenderer spriteRenderer;
    Color startColor;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            FadeOut();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent = collision.transform;
        hasHit = true;
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(hitbox);
        Destroy(arrow, 2f);
    }

    void FadeOut()
    {
        elapsedTime += Time.deltaTime;
        float newAlpha = startColor.a * (1 - (elapsedTime / fadeTime));
        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
    }
}
