using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public new Transform camera;
    public Transform grabPosition;

    private RaycastHit hit;
    private GameObject grabbedObj;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        {
            grabbedObj = hit.transform.gameObject;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            grabbedObj = null;
        }
    }

    public void FixedUpdate()
    {
        if (grabbedObj)
        {
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            rb.velocity = 10 * (grabPosition.position - grabbedObj.transform.position);
        }
    }
}
