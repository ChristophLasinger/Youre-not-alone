using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Script : MonoBehaviour
{
    [SerializeField]
    private Transform gameTransform;
    [SerializeField]
    private Transform piecePrefab;
    public Puzzle3_Keyplate keyplateUp;
    public Puzzle3_Keyplate keyplateDown;
    public Puzzle3_Keyplate keyplateLeft;
    public Puzzle3_Keyplate keyplateRight;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;
    private bool shuffling = false;

    private void CreateGamePieces(float gapThickness)
    {
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                piece.localPosition = new Vector3(-1 + (2 * width * col) + width, +1 - (2 * width * row) - width, 0);
                
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                
                piece.name = $"{(row * size) + col}";

                if((row == size - 1) && (col == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                } else
                {
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    //0/1...1/1...0/0...1/0
                    uv[0] = new Vector2((width * col) + gap, 1 - (width * (row + 1)) -gap);
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));

                    mesh.uv= uv;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);
        shuffling = true;
        StartCoroutine(WaitShuffle(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if(keyplateUp.triggered && size <= emptyLocation)
        {
            Swap(emptyLocation - size);
            CheckCompletion();
        }
        else if(keyplateDown.triggered && emptyLocation <= (size * size - size))
        {
            Swap(emptyLocation + size);
            CheckCompletion();
        }
        else if(keyplateLeft.triggered && emptyLocation % size != 0)
        {
            Swap(emptyLocation - 1);
            CheckCompletion();
        }
        else if(keyplateRight.triggered && emptyLocation % size != size - 1)
        {
            Swap(emptyLocation + 1);
            CheckCompletion();
        }
    }
    private void Swap(int piece)
    {
        Debug.Log(piece);
        Debug.Log(emptyLocation);
        (pieces[emptyLocation], pieces[piece]) = (pieces[piece], pieces[emptyLocation]);
        (pieces[emptyLocation].localPosition, pieces[piece].localPosition) = (pieces[piece].localPosition, pieces[emptyLocation].localPosition);
        emptyLocation = piece;
        Debug.Log("swapped");
    }
    private bool CheckCompletion()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        return true;
    }
    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shuffle();
        shuffling= false;
    }
    private void Shuffle()
    {
        int count = 0;
        int last = 0;
        while(count < (size * size * size))
        {
            int rnd = Random.Range(0, size * size);

            if(rnd == last)
            {
                continue;
            }
            Swap(rnd);
            count++;
        }
    }
}
