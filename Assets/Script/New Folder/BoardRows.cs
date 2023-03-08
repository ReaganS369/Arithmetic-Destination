using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRows : MonoBehaviour
{
    public BoardColums[] BC { get; private set; }

    private void Awake()
    {
        BC = GetComponentsInChildren<BoardColums>();
    }
}
