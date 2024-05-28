using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBossArena : MonoBehaviour
{
    public GameObject Arena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Arena != null && !Arena.activeInHierarchy && tag == "EnableArena")
        {
            Arena.SetActive(true);
        }
        else if(tag == "DisableArena")
        {
            Arena.SetActive(false);
        }
    }
}
