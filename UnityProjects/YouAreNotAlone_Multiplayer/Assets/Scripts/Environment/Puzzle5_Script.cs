using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5_Script : MonoBehaviour
{
    private int platesDoneB = 0;
    public Puzzle5_Keyplate[] correctKeyplatesB = new Puzzle5_Keyplate[10];
    public Puzzle5_Keyplate[] incorrectKeyplatesB = new Puzzle5_Keyplate[20];
    bool partBcomplete = false;

    private int platesDoneA = 0;
    public Puzzle5_Keyplate[] correctKeyplatesA = new Puzzle5_Keyplate[10];
    public Puzzle5_Keyplate[] incorrectKeyplatesA = new Puzzle5_Keyplate[20];
    public GameObject door;
    bool partAcomplete = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var plate in correctKeyplatesA)
        {
            plate.GetComponent<Renderer>().material.color = Color.green;
        }
        foreach (var plate in correctKeyplatesB)
        {
            plate.GetComponent<Renderer>().material.color = Color.green;
        }
        foreach (var plate in incorrectKeyplatesA)
        {
            plate.GetComponent<Renderer>().material.color = default;
        }
        foreach (var plate in incorrectKeyplatesB)
        {
            plate.GetComponent<Renderer>().material.color = default;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (platesDoneB <= 9 && correctKeyplatesB[platesDoneB].isTriggered == true)
        {
            if (platesDoneB == 9)
            {
                partBcomplete = true;
            }
            platesDoneB++;
            Debug.Log($"plates Done: {platesDoneB}");
            if (platesDoneB == 1)
            {
                foreach (var plate in correctKeyplatesB)
                {
                    plate.GetComponent<Renderer>().material.color = default;
                }
                Debug.Log("reset incorrect plates");
                foreach (var plate in incorrectKeyplatesB)
                {
                    plate.isTriggered = false;
                }
            }
        }
        foreach (var plate in incorrectKeyplatesB)
        {
            if (plate.isTriggered)
            {
                Debug.Log("incorrect plate triggered... reseting");
                ResetPuzzle();
            }
        }
        for (int i = platesDoneB; i < correctKeyplatesB.Length; i++)
        {
            if (correctKeyplatesB[i].isTriggered)
            {
                Debug.Log("trigger plates in order! ... reseting");
                ResetPuzzle();
            }
        }


        if (platesDoneA <= 9 && correctKeyplatesA[platesDoneA].isTriggered == true)
        {
            if(platesDoneA == 9)
            {
                partAcomplete = true;
            }
            platesDoneA++;
            Debug.Log($"plates Done: {platesDoneA}");
            if (platesDoneA == 1)
            {
                foreach (var plate in correctKeyplatesA)
                {
                    plate.GetComponent<Renderer>().material.color = default;
                }
                Debug.Log("reset incorrect plates");
                foreach (var plate in incorrectKeyplatesA)
                {
                    plate.isTriggered = false;
                }
            }
        }
        foreach (var plate in incorrectKeyplatesA)
        {
            if (plate.isTriggered)
            {
                Debug.Log("incorrect plate triggered... reseting");
                ResetPuzzle();
            }
        }
        for (int i = platesDoneA; i < correctKeyplatesA.Length; i++)
        {
            if (correctKeyplatesA[i].isTriggered)
            {
                Debug.Log("trigger plates in order! ... reseting");
                ResetPuzzle();
            }
        }
        if(partAcomplete && partBcomplete)
        {
            Destroy(door);
        }
    }
    private void ResetPuzzle()
    {
        platesDoneB = 0;
        foreach (var plate in correctKeyplatesB)
        {
            plate.isTriggered = false;
        }
    }
}
