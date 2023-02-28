using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGrid : MonoBehaviour
{
    [SerializeField] private GameObject Ground;
    [SerializeField] private GameObject GridGround;

    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;

    private Vector2 center;

    private void Awake()
    {
        
        //center = new Vector3( 0f, 0f, -1f);
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j< height; j++)
            {
                GameObject tempGround = Instantiate(Ground, new Vector2(i,j), Quaternion.identity);
                //GameObject tempGround = Instantiate (Ground);
                //tempGround.transform.position = new Vector3(x, -y,-1f);
            }
        }
        center = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -1f);
        GameObject tempGridGround = Instantiate(GridGround, center, Quaternion.identity);
        //tempGridGround.size = new Vector2(width, height);

        Camera.main.transform.position = new Vector3(center.x, center.y, -10);
    }
}
