using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource walkSound;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            
                walkSound.enabled = true;
            
        }
            else
        {
                walkSound.enabled = false;
                
        }
       
        
    }
}
