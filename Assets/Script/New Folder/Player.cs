using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private float tileSize = 1f;

    private Vector3Int currentTile;
    private bool enterToggle = false;

    void Start()
    {
        currentTile = tilemap.WorldToCell(transform.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enterToggle)
            {
                Move(new Vector3Int(0, -1, 0)); // move up
            }
            else
            {
                Move(new Vector3Int(1, 0, 0)); // move right
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            enterToggle = !enterToggle; // toggle direction
        }
    }
    private void Move(Vector3Int direction)
{
    Vector3Int targetTile = currentTile + direction;
    
    // Check for collision with walls
    Collider2D[] colliders = Physics2D.OverlapCircleAll(tilemap.GetCellCenterWorld(targetTile), tileSize / 2);
    foreach (Collider2D collider in colliders)
    {
        if (collider.CompareTag("Wall"))
        {
            return;
        }
    }
        // Check if the target tile is behind a wall
        Vector3 start = transform.position;
        Vector3 end = tilemap.GetCellCenterWorld(targetTile);
        RaycastHit2D[] hits = Physics2D.LinecastAll(start, end);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return;
            }
        }
        // Move to the target tile if there is no wall in the way
        if (tilemap.HasTile(targetTile))
    {
        transform.position = tilemap.GetCellCenterWorld(targetTile);
        currentTile = targetTile;
    }
}

}
