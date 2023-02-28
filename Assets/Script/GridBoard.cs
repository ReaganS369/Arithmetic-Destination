using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBoard : MonoBehaviour
{
    public int[,] board = new int[10, 10];
    public GameObject playerPrefab;
    public GameObject trapPrefab;
    public GameObject destinationPrefab;

    void Start()
    {
        // Initialize the board with values of 0
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                board[row, col] = 0;
            }
        }

        // Set the value at row 3, column 4 to 1 (occupied by a trap)
        board[3, 4] = 1;

        // Set the value at row 5, column 6 to 2 (occupied by the player)
        board[5, 6] = 2;

        // Set the value at row 1, column 2 to 3 (occupied by destination)
        board[1, 2] = 3;

        // Loop through the board array and instantiate the game objects based on the integer value
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                switch (board[row, col])
                {
                    case 1:  // trap
                        Instantiate(trapPrefab, new Vector3(row, col, 0), Quaternion.identity);
                        break;
                    case 2:  // player
                        Instantiate(playerPrefab, new Vector3(row, col, 0), Quaternion.identity);
                        break;
                    case 3:  // destination
                        Instantiate(destinationPrefab, new Vector3(row, col, 0), Quaternion.identity);
                        break;
                }
            }
        }
    }
}
