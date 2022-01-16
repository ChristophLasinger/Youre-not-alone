using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlattform : MonoBehaviour
{
    private GameObject bigCube;
    private GameObject mediumCube;
    private GameObject smallCube;

    private Vector3 plattformPosition;
    private bool cubePuzzleSolved = false;
    public GameObject keyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bigCube = GameObject.Find("BigCube");
        mediumCube = GameObject.Find("MediumCube");
        smallCube = GameObject.Find("SmallCube");

        plattformPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bigCubePosition = bigCube.transform.localPosition;
        Vector3 mediumCubePosition = mediumCube.transform.localPosition;
        Vector3 smallCubePosition = smallCube.transform.localPosition;

        // check if all cubes are standing on the plattform
        if (bigCubePosition.y == plattformPosition.y + 1.5 &&
            mediumCubePosition.y == plattformPosition.y + 1.25 &&
            smallCubePosition.y == plattformPosition.y + 1)
        {
            // check if puzzle is solved (cubes are ordered by size)
            if ((bigCubePosition.x > mediumCubePosition.x && mediumCubePosition.x > smallCubePosition.x) ||
            (smallCubePosition.x > mediumCubePosition.x && mediumCubePosition.x > bigCubePosition.x))
            {
                if (cubePuzzleSolved == false)
                {
                    // spawn key
                    GameObject key = Instantiate(keyPrefab);
                    key.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);  // downsize key because by default it's way too big
                    key.transform.localEulerAngles = new Vector3(key.transform.localEulerAngles.x, key.transform.localEulerAngles.y + 250, key.transform.localEulerAngles.z);   // rotate key
                    key.transform.localPosition = new Vector3(0f, 0f, 4.15f);   //spawn key next to plattform
                }
                cubePuzzleSolved = true;
            }
        }
    }
}
