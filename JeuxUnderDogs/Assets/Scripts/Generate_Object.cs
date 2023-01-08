using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generate_Object : MonoBehaviour
{
    internal static void createsObject(TileMapVisualizer tileMapVisualizer)
    {
        int nombreObjet = Random.Range(75, 200);
        for (int i = 0; i < nombreObjet; i++)
        {
            Vector2Int position = new Vector2Int();
            position.x = Random.Range(-20, 120);
            position.y = Random.Range(-20, 120);
            tileMapVisualizer.paintObjectCase(position);
        }
    }
}
