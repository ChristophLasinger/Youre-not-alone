using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.Spawning;

public class PlayerActions : NetworkBehaviour
{
    [SerializeField]
    private Transform rightHandSlot;
    [SerializeField]
    private GameObject equipItem;
    [SerializeField]
    private bool canEquip;

    private Transform playerCamera;
    private GameObject _equippedItem;

    private void Start()
    {
        playerCamera = transform.Find("Main Camera");
        _equippedItem = null;
    }

    [ServerRpc]
    private void EquipServerRpc(ulong netID)
    {
        Debug.Log("Client wants to equip!");
        GameObject gameObject = Instantiate(equipItem);
        gameObject.GetComponent<NetworkObject>().SpawnWithOwnership(netID);
        ulong itemNedID = gameObject.GetComponent<NetworkObject>().NetworkObjectId;

        EquipClientRpc(itemNedID);
    }

    [ClientRpc]
    private void EquipClientRpc(ulong itemNetID)
    {
        NetworkObject networkObject = NetworkSpawnManager.SpawnedObjects[itemNetID];

        _equippedItem = networkObject.gameObject;
        Rigidbody rigidbody = _equippedItem.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
        _equippedItem.transform.position = rightHandSlot.position;
        _equippedItem.transform.SetParent(rightHandSlot);
        Debug.Log("Client has equipped an item!");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (equipItem != null && _equippedItem == null && canEquip)
                    EquipServerRpc(NetworkManager.Singleton.LocalClientId);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Attempting to pickup an Item!");
                TryPickup();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Attempting to drop Item!");
                Drop();
            }
        }
    }

    private void Drop()
    {
        if(_equippedItem != null)
        {
            DropServerRpc();
        }
        else
        {
            Debug.Log("Drop failed!");
        }
    }

    [ServerRpc]
    private void DropServerRpc()
    {
        _equippedItem.GetComponent<NetworkObject>().RemoveOwnership();
        DropClientRpc();
    }

    [ClientRpc]
    private void DropClientRpc()
    {
        Rigidbody rigidbody = _equippedItem.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        _equippedItem.transform.SetParent(null);
        _equippedItem = null;
        canEquip = false;
        Debug.Log("An item was dropped!");
    }

    [ServerRpc]
    private void PickupServerRpc(ulong itemNedID)
    {
        NetworkObject networkObject = NetworkSpawnManager.SpawnedObjects[itemNedID];
        Debug.Log($"{networkObject} was picked up!");
        NetworkManager.Destroy(networkObject.gameObject);
    }

    private void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.GetComponent<Item>() != null)
            {
                canEquip = true;
                PickupServerRpc(hit.transform.GetComponent<NetworkObject>().NetworkObjectId);
            }
        }
    }

}
