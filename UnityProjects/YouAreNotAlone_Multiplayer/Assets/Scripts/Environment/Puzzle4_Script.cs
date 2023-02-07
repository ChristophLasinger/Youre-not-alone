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
    public GameObject door;

    private bool puzzleAComplete = false;
    private bool puzzleBComplete = false;
    private bool puzzleCComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(letterA.IsPressed && matchingLetterA.IsPressed)
        {
            Debug.Log("Letter A Complete");
            puzzleAComplete= true;
        }
        else if(letterB.IsPressed && matchingLetterB.IsPressed)
        {
            Debug.Log("Letter B Complete");
            puzzleBComplete = true;
        }
        else if(letterC.IsPressed && matchingLetterC.IsPressed)
        {
            Debug.Log("Letter C Complete");
            puzzleCComplete = true;
        }
        if(puzzleAComplete && puzzleBComplete && puzzleCComplete)
        {
            Destroy(door);
            Debug.Log("Puzzle Complete");
        }
    }
}
