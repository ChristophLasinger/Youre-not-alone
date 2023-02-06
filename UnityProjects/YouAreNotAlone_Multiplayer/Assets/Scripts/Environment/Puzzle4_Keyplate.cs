using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4_Keyplate : MonoBehaviour
{
    public Puzzle4_Keyplate Keyplate;
    public bool IsPressed = false;
    //public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        IsPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsPressed = false;
    }
}
