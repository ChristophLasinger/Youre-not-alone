using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4_Script : MonoBehaviour
{
    public Puzzle4_Keyplate letterA;
    public Puzzle4_Keyplate matchingLetterA;
    public Puzzle4_Keyplate letterB;
    public Puzzle4_Keyplate matchingLetterB;
    public Puzzle4_Keyplate letterC;
    public Puzzle4_Keyplate matchingLetterC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(letterA.IsPressed || matchingLetterA.IsPressed)
        {
            Debug.Log("Letter A Complete");
        }
        else if(letterB.IsPressed && matchingLetterB.IsPressed)
        {
            Debug.Log("Letter B Complete");
        }
        else if(letterC.IsPressed && matchingLetterC.IsPressed)
        {
            Debug.Log("Letter C Complete");
        }
        if(letterA.IsPressed && letterB.IsPressed && letterC.IsPressed && matchingLetterA.IsPressed && matchingLetterB.IsPressed && matchingLetterC.IsPressed)
        {
            Debug.Log("Puzzle Complete");
        }
    }
}
