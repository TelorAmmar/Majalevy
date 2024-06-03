using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBossArena : MonoBehaviour
{
    public GameObject Arena;
    public GameObject Boss;
    public GameObject Bridge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Arena != null && !Arena.activeInHierarchy && tag == "EnableArena")
        {
            Arena.SetActive(true);
            Boss.SetActive(true);
            Destroy(gameObject);
            Bridge.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Bridge.GetComponent<Rigidbody2D>().gravityScale = 4f;
        }
        else if(tag == "DisableArena")
        {
            Arena.SetActive(false);
        }
    }
}
