using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle2OpenDoor : MonoBehaviour
{
    public Puzzle2Keyplate correctKeyplate;
    public Puzzle2Keyplate[] incorrectKeyplate;
    public GameObject door;
    public TMP_Text question;
    public TMP_Text answer;
    public TMP_Text[] questions;
    public TMP_Text[] answers;
    private int random;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, questions.Length);
        while(random == 0)
        {
            random = Random.Range(0, questions.Length);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(correctKeyplate.triggered) 
            Destroy(door);
        foreach (var keyplate in incorrectKeyplate)
        {
            if(keyplate.triggered)
            {
                int oldRandom = random;
                question.text = questions[random].text;
                answer.text = answers[random].text;
                Debug.Log(random + 1);
                random = Random.Range(0, questions.Length);
                while (oldRandom == random)
                {
                    random = Random.Range(0, questions.Length);
                }
                keyplate.triggered = false;
            }
        }
    }
}
