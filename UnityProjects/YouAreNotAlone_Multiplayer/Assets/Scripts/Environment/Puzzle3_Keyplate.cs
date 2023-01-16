using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Keyplate : MonoBehaviour
{
    public Puzzle3_Keyplate Keyplate;
    public bool IsPressed = false;
    public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}
