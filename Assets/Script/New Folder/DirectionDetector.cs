using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionDetector : MonoBehaviour
{
    [SerializeField] private Text detectorTextPX;
    [SerializeField] private Text detectorTextNX;
    [SerializeField] private Text detectorTextPY;
    [SerializeField] private Text detectorTextNY;
    private Transform[] tiles;

    private void Start()
    {
        // get all the tiles on the board
        GameObject board = GameObject.Find("Board"); // replace "Board" with the name of your board object
        tiles = new Transform[board.transform.childCount * 10]; // create an array with space for all the BCs
        int tileIndex = 0;
        for (int i = 0; i < board.transform.childCount; i++)
        {
            Transform child = board.transform.GetChild(i);
            if (child.CompareTag("BR"))
            {
                // get all the BCs for this row
                for (int j = 0; j < child.childCount; j++)
                {
                    Transform bc = child.GetChild(j);
                    if (bc.CompareTag("BC"))
                    {
                        // add the BC transform to the array
                        tiles[tileIndex] = bc;
                        tileIndex++;
                    }
                }
            }
        }
    }

    private void Update()
    {
        // Detect the number of tiles in each direction
        int countPX = 0;
        int countNX = 0;
        int countPY = 0;
        int countNY = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (transform.position.x < tiles[i].position.x && Mathf.Abs(transform.position.y - tiles[i].position.y) < 0.1f)
                {
                    countPX++;
                }
                if (transform.position.x > tiles[i].position.x && Mathf.Abs(transform.position.y - tiles[i].position.y) < 0.1f)
                {
                    countNX++;
                }
                if (transform.position.y < tiles[i].position.y && Mathf.Abs(transform.position.x - tiles[i].position.x) < 0.1f)
                {
                    countPY++;
                }
                if (transform.position.y > tiles[i].position.y && Mathf.Abs(transform.position.x - tiles[i].position.x) < 0.1f)
                {
                    countNY++;
                }
            }
        }

        // Update the detector texts
        detectorTextPX.text = countPX.ToString();
        detectorTextNX.text = countNX.ToString();
        detectorTextPY.text = countPY.ToString();
        detectorTextNY.text = countNY.ToString();

    }
}