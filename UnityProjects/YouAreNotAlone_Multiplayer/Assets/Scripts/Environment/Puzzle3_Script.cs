using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Script : MonoBehaviour
{
    [SerializeField]
    private Transform gameTransform;
    [SerializeField]
    private Transform piecePrefab;
    public Keyplate keyplateUp;
    public Keyplate keyplateDown;
    public Keyplate keyplateLeft;
    public Keyplate keyplateRight;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;

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
    }

    // Update is called once per frame
    void Update()
    {
        //swap
    }
}
