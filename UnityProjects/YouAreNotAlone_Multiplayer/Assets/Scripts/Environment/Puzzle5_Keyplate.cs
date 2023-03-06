using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5_Keyplate : MonoBehaviour
{
    public Puzzle5_Keyplate Keyplate;
    public bool isTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
    }
}
