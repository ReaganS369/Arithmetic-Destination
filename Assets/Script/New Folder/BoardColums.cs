using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColums : MonoBehaviour
{
    public Vector2Int coordinates { get; set; }
    public Player tile { get; set; }

    public bool empty => tile == null;
    public bool occupied => tile != null;
}
