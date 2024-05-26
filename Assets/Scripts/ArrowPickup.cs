using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickup : MonoBehaviour
{
    public int arrowRestore = 5;
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ArrowPossession arrowPossession = collision.GetComponent<ArrowPossession>();

        if (arrowPossession)
        {
            bool gotArrow = arrowPossession.PickArrow(arrowRestore);

            if (gotArrow)
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }
}
