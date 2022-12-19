using UnityEngine;

public class Puzzle2Keyplate : MonoBehaviour
{
    public Puzzle2Keyplate Keyplate;
    public bool IsPressed = false;
    public bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {

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