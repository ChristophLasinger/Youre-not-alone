using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool inventoryOpen = false;
    public GameObject inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryOpen)
            {
                inventoryUI.SetActive(false);
                inventoryOpen = false;
            }
            else
            {
                inventoryUI.SetActive(true);
                inventoryOpen = true;
                InventoryManager.Instance.ListItems();
            }
        }
    }
}
