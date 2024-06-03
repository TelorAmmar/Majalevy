using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaRemove : MonoBehaviour
{
    public List<GameObject> objectsToRemove;
    Damageable damageable;

    // Start is called before the first frame update
    void Start()
    {
        damageable = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!damageable.IsAlive)
        {
            for(int i=0; i<objectsToRemove.Count; i++)
            {
                Destroy(objectsToRemove[i]);
            }
        }
    }
}
