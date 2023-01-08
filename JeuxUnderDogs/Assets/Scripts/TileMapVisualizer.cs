using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap BuildingTileMap;
    [SerializeField]
    private TileBase[] BuildingTile;
    [SerializeField]
    private Tilemap Wallmap;
    [SerializeField]
    private TileBase[] wallTile;
    [SerializeField]
    private Tilemap ObstacleMap;
    [SerializeField]
    private TileBase[] objectTiles;

    public void paintBuildingCase(IEnumerable<Vector2Int> buildingPositions)
    {
        paintTiles(buildingPositions, BuildingTileMap, BuildingTile);
    }
    public void paintObjectCase(Vector2Int position)
    {
        PaintSingleTile(ObstacleMap, objectTiles[Random.Range(0,objectTiles.Length)], position);
    }

    internal void PaintSingleWall(Vector2Int position)
    {
        PaintSingleTile(Wallmap, wallTile[Random.Range(0,wallTile.Length)], position);
    }

    private void paintTiles(IEnumerable<Vector2Int> buildingPositions, Tilemap buildingTileMap, TileBase[] buildingTile)
    {
        foreach (var position in buildingPositions)
        {
            PaintSingleTile(buildingTileMap, buildingTile[Random.Range(0,buildingTile.Length)], position);
        }
    }

    private void PaintSingleTile(Tilemap buildingTileMap, TileBase tileBase, Vector2Int position)
    {
        var tilePosition = buildingTileMap.WorldToCell((Vector3Int)position);
        buildingTileMap.SetTile(tilePosition, tileBase);
    }
}
