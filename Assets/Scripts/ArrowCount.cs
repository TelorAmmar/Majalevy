using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArrowCount : MonoBehaviour        
{
    [SerializeField]
    public TMP_Text arrowCountText;

    ArrowPossession arrowPossession;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("No player found in scene. Make sure it has TAG 'Player'");
        }

        arrowPossession = player.GetComponent<ArrowPossession>();
    }

    void Start()
    {        
        arrowCountText.text = "Arrow: " + arrowPossession.NumberOfArrows + " / " + arrowPossession.MaxArrow;
    }

    private void OnEnable()
    {
        arrowPossession.arrowChanged.AddListener(OnPlayerArrowChanged);
    }

    private void OnDisable()
    {
        arrowPossession.arrowChanged.RemoveListener(OnPlayerArrowChanged);
    }
    private void OnPlayerArrowChanged(int newArrow, int maxArrow)
    {        
        arrowCountText.text = "Arrow " + newArrow + " / " + maxArrow;
    }
}
