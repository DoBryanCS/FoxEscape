using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDoors : MonoBehaviour
{
    internal static void createDoor(Vector2Int position, List<Vector2Int> cardinalDirectionList, HashSet<Vector2Int> floorPositions, GameObject door)
    {
        foreach (var direction in cardinalDirectionList)
        {
            var neighboorFloor = position + direction;
            if (floorPositions.Contains(neighboorFloor) == true)
            {
                placeDoor(direction,position,door);
                break;
            }
        }
    }

    private static void placeDoor(Vector2Int direction, Vector2Int position,GameObject prefab)
    {
        if (direction.x == 1 && direction.y == 0)
        {
            var door = Instantiate(prefab, (Vector3Int)position+new Vector3(0.3f,0.5f,0f), Quaternion.Euler(0,0,90));
        }
        if (direction.x == -1 && direction.y == 0)
        {
            var door = Instantiate(prefab, (Vector3Int)position + new Vector3(0.7f, 0.5f, 0f), Quaternion.Euler(0, 0, -90));
        }
        if (direction.x == 0 && direction.y == 1)
        {
            var door = Instantiate(prefab, (Vector3Int)position + new Vector3(0.5f, 0.3f, 0f), Quaternion.Euler(0, 0, 180));
        }
        if (direction.x == 0 && direction.y == -1)
        {
            var door = Instantiate(prefab, (Vector3Int)position + new Vector3(0.5f, 0.7f, 0f), Quaternion.Euler(0, 0, 0));
        }
    }
}
