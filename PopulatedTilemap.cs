using UnityEngine;
using UnityEngine.Tilemaps;

public class PopulatedTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                GameObject tempTile = Instantiate(Resources.Load<GameObject>("Objects/" + tilemap.GetSprite(pos).name), tilemap.CellToWorld(pos), Quaternion.identity,transform );
            }
        }

        tilemap.ClearAllTiles();
    }

    public Tilemap gettilemap()
    {
        return tilemap;
    }


}
