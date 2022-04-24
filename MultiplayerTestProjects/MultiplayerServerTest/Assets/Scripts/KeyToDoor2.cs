using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToDoor2 : MonoBehaviour
{

    public Component doorcolliderhere;
    public GameObject keygone;

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            keygone.SetActive(false);
            doorcolliderhere.GetComponent<BoxCollider>().enabled = true;      
        }    
    }
}
