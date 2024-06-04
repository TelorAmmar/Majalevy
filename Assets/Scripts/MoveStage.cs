using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MoveStage : MonoBehaviour
{
    public GameObject panel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (panel != null)
            {
                panel.SetActive(true);
            };
        }
    }
}
