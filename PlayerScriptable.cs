using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScriptable : TileBase
{

    


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // RefreshTile determines which Tiles in the vicinity are updated when this Tile is added to the Tilemap
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }
    //GetTileData determines what the Tile looks like on the Tilemap.
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
    }

    public override bool StartUp(Vector3Int location, ITilemap tilemap, GameObject go)
    {
        return base.StartUp(location,tilemap,go);
    }
}
