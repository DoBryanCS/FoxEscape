using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaceObjects:MonoBehaviour
{

    internal static void place(BoundsInt building, HashSet<Vector2Int> buildingCase, GameObject[] possiblesObjects, Grid grid)
    {
       
        
        int numberOfObject = 5*buildingCase.Count/100;
        for (int i = 0; i < numberOfObject; i++)
        {
            Vector2Int caseChoisi = new Vector2Int();
            int counter = Random.Range(0, buildingCase.Count);
            int j = 0;
            foreach (var floor in buildingCase)
            {
                if (counter == j)
                {
                    caseChoisi = floor;
                }
                j++;
            }
            Instantiate(possiblesObjects[Random.Range(0, possiblesObjects.Length)],grid.CellToWorld((Vector3Int)caseChoisi),Quaternion.identity);
        }
    }
}
