using UnityEngine;

public class BoardGrid : MonoBehaviour
{
    public BoardRows[] BR { get; private set; }
    public BoardColums[] BC { get; private set; }

    public int size => BC.Length;
    public int height => BR.Length;
    public int width => size / height;
    /*
    private void Awake()
    {
        BR = GetComponentsInChildren<BoardRows>();
        BC = GetComponentsInChildren<BoardColums>();
    }
    
    public void Start()
    {
        for (int y = 0; y < BR.Length; y++)
        {
            for(int x=0; x< BR[y].BC.Length; x++)
            {
                BR[y].BC[x].coordinates = new vector2Int(x, y);
            }
        }
    }*/
}
