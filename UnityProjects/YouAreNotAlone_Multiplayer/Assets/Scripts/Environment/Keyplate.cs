using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyplate : MonoBehaviour
{
    //[SerializeField]
    //GameObject door;
    //PuzzleDoor puzzleDoor;

    public Keyplate keyplate;
    public bool IsPressed = false;
    public bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            IsPressed = true;
            keyplate.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = true;
    }
}
