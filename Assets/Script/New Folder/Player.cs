using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public float stepSize = 1.0f; // the distance between tiles
    public KeyCode moveButtonX = KeyCode.X; // the button for moving horizontally
    public KeyCode moveButtonY = KeyCode.Y; // the button for moving vertically

    private int currentTileIndex = 0; // the current tile index
    private Transform[] tiles; // an array of all the tiles on the board

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

        // move the player to the starting tile
        transform.position = tiles[currentTileIndex].position;
    }


    private void Update()
    {
        // move the player when the assigned button is pressed
        if (Input.GetKeyDown(moveButtonX))
        {
            // move horizontally
            Move(1, 0);
        }
        else if (Input.GetKeyDown(moveButtonY))
        {
            // move vertically
            Move(0, 1);
        }
    }

    private void Move(int x, int y)
    {
        // calculate the new tile index based on the input and the current tile index
        int newIndex = currentTileIndex + x + y * 10; // add 10 for each row

        // check if the new index is within the bounds of the array
        if (newIndex >= 0 && newIndex < tiles.Length)
        {
            // update the current tile index
            currentTileIndex = newIndex;

            // set the new tile as the player's parent
            transform.SetParent(tiles[currentTileIndex]);

            // move the player to the new tile
            transform.localPosition = Vector3.zero;
        }
    }
}
