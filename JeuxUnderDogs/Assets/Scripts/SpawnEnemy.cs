using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    internal static void spawn(BoundsInt building, GameObject enemy)
    {
        Instantiate(enemy, building.center, Quaternion.identity);
    }
}
