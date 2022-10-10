using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private RaycastHit hit;

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        //{
        //    Pickup();
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            Pickup();
        }
    }
}
