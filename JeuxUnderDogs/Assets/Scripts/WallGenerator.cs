using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions,TileMapVisualizer tileMapVisualizer, GameObject door)
    {
        int counter = 0;
         
        var basicWallPositions = (HashSet<Vector2Int>)FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionList);
        int porte = Random.Range(0,basicWallPositions.Count);
        foreach (var position in basicWallPositions)
        {
            if (counter != porte)
            {
                tileMapVisualizer.PaintSingleWall(position);
            }
            else
            {
                AddDoors.createDoor(position,Direction2D.cardinalDirectionList,floorPositions,door);
            }
            counter++;
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> cardinalDirectionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in cardinalDirectionList)
            {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition) == false)
                {
                    wallPositions.Add(neighbourPosition);
                }
            }
        }
        return wallPositions;
    }
}
