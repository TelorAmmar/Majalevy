using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenOnly : MonoBehaviour
{
    public GameObject PanelOpen;

    public void OpenPanelOnly()
    {
        if (PanelOpen != null)
        {
            PanelOpen.SetActive(true);
        }
    }

}
