using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    public Keyplate key1;
    public Keyplate key2;
    public Keyplate key3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (key1.IsPressed && key2.IsPressed && key3.IsPressed)
            Destroy(gameObject);
    }
}
