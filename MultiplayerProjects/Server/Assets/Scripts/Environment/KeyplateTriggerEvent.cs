using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyplateTriggerEvent : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            isOpen = true;
            door.transform.position += new Vector3(0, 20, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        door.transform.position -= new Vector3(0, 20, 0);
        isOpen = false;
    }
}
