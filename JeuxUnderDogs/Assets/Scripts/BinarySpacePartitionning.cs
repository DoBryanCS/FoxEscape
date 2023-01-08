using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySpacePartitionning : MonoBehaviour
{
    [SerializeField]
    private int minBuildingWidth = 4, minBuildingHeight = 4;
    [SerializeField]
    private int cityWidth = 20, cityHeight = 20;
    [SerializeField]
    [Range(0, 10)]
    private int spacing = 1;
    [SerializeField]
    private Vector2Int startPosition = Vector2Int.zero;
    [SerializeField]
    private TileMapVisualizer tileMapVisualizer;
    [SerializeField]
    private GameObject[] possiblesObjects;
    [SerializeField]
    private Grid Grid;
    [SerializeField]
    private GameObject[] roofPrefabs;
    [SerializeField]
    private GameObject door;
    

    public void Awake()
    {
        RunProceduralGeneration();
    }

    public void RunProceduralGeneration()
    {
        CreatesBuildings();
    }

    private void CreatesBuildings()
    {
        var BuildingsList = ProceduralGeneration.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition, new Vector3Int(cityWidth, cityHeight, 0)), minBuildingWidth, minBuildingHeight);
        HashSet<Vector2Int> BuildingCase = new HashSet<Vector2Int>();
        Generate_Object.createsObject(tileMapVisualizer);
        foreach (var building in BuildingsList)
        {
            BuildingCase = CreateSimpleBuilding(building);
            tileMapVisualizer.paintBuildingCase(BuildingCase);
            WallGenerator.CreateWalls(BuildingCase, tileMapVisualizer,door);
            PlaceObjects.place(building,BuildingCase,possiblesObjects,Grid);
            RoofGenerator.CreateRoofs(building,roofPrefabs,spacing);
        }
    }

    private HashSet<Vector2Int> CreateSimpleBuilding(BoundsInt building)
    {
        HashSet<Vector2Int> BuildingCase = new HashSet<Vector2Int>();
        for (int col = spacing; col < building.size.x - spacing; col++)
            {
                for (int row = spacing; row < building.size.y - spacing; row++)
                {
                    Vector2Int position = (Vector2Int)building.min + new Vector2Int(col, row);
                    BuildingCase.Add(position);
                }
        }
        
        return BuildingCase;
    }
}
