using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBossArena : MonoBehaviour
{
    public GameObject Arena;
    public GameObject Boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Arena != null && !Arena.activeInHierarchy && tag == "EnableArena")
        {
            Arena.SetActive(true);
            Boss.SetActive(true);
            Destroy(gameObject);
        }
        else if(tag == "DisableArena")
        {
            Arena.SetActive(false);
        }
    }
}
