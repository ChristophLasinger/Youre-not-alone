using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4 : MonoBehaviour
{
    public GameObject letterA;
    public GameObject matchingLetterA;
    public GameObject letterB;
    public GameObject matchingLetterB;
    public GameObject letterC;
    public GameObject matchingLetterC;

    public Transform playerCamera;
    private float timeRemaining = 3;
    private bool timerRunning = false;
    private bool pressedLetterA;
    private bool pressedMatchingLetterA;
    private bool pressedLetterB;
    private bool pressedMatchingLetterB;
    private bool pressedLetterC;
    private bool pressedMatchingLetterC;
    // Start is called before the first frame update
    void Start()
    {
        //playerCamera = transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
        if(pressedLetterA && pressedMatchingLetterA)
        {
            Debug.Log("matching letter found");
        }
        if (pressedLetterB && pressedMatchingLetterB)
        {
            Debug.Log("matching letter found");
        }
        if (pressedLetterC && pressedMatchingLetterC)
        {
            Debug.Log("matching letter found");
        }
        if(pressedLetterA && pressedLetterB && pressedLetterC && pressedMatchingLetterA && pressedMatchingLetterB && pressedMatchingLetterC)
        {
            Debug.Log("Puzzle Complete");
        }
    }
    private void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.GetComponent<Item>() == letterA || hit.transform.GetComponent<Item>() == matchingLetterA)
            {
                timerRunning = true;
                if(hit.transform.GetComponent<Item>() == letterA)
                {
                    pressedLetterA = true;
                }
                if(hit.transform.GetComponent<Item>() == matchingLetterA)
                {
                    pressedMatchingLetterA = true;
                }
                if (timeRemaining > 0 && timerRunning)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Time ran out");
                    pressedLetterA = false;
                    pressedMatchingLetterA = false;
                    timeRemaining = 3;
                    timerRunning = false;
                }
            }
            else if(hit.transform.GetComponent<Item>() == letterB || hit.transform.GetComponent<Item>() == matchingLetterB)
            {
                timerRunning = true;
                if (hit.transform.GetComponent<Item>() == letterB)
                {
                    pressedLetterB = true;
                }
                if (hit.transform.GetComponent<Item>() == matchingLetterB)
                {
                    pressedMatchingLetterB = true;
                }
                if (timeRemaining > 0 && timerRunning)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Time ran out");
                    pressedLetterB = false;
                    pressedMatchingLetterB = false;
                    timeRemaining = 3;
                    timerRunning = false;
                }
            }
            else if (hit.transform.GetComponent<Item>() == letterC || hit.transform.GetComponent<Item>() == matchingLetterC)
            {
                timerRunning = true;
                if (hit.transform.GetComponent<Item>() == letterC)
                {
                    pressedLetterC = true;
                }
                if (hit.transform.GetComponent<Item>() == matchingLetterC)
                {
                    pressedMatchingLetterC = true;
                }
                if (timeRemaining > 0 && timerRunning)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Time ran out");
                    pressedLetterC = false;
                    pressedMatchingLetterC = false;
                    timeRemaining = 3;
                    timerRunning = false;
                }
            }
        }
        else
        {
            Debug.Log("No object hit");
        }
    }
}
