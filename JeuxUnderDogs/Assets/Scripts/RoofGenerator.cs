using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoofGenerator : MonoBehaviour
{

    internal static void CreateRoofs(BoundsInt building,GameObject[]roofPrefabs, int spacing)
    {
        Vector3 position = new Vector3Int();
        position.x = building.center.x;
        position.y = building.center.y;
        position.z = -5f;
        GameObject myRoof = roofPrefabs[Random.Range(0, roofPrefabs.Length)];
        myRoof.transform.localScale = new Vector3(building.size.x - 2*spacing ,building.size.y - 2*spacing,0);
        Instantiate(myRoof,position,Quaternion.identity);

    }
}
