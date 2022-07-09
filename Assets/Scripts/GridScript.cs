using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridScript : MonoBehaviour //based on TileData.cs
{
    [SerializeField] private GameModel gameModel;
    [SerializeField] private TileBase newTile;
    [SerializeField] private Tilemap tilemap;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private HashSet<Vector3Int> occupiedCells;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
    private void Start()
    {
        occupiedCells = new HashSet<Vector3Int>();
    }

    public void spawnTower(Vector2 mousePosition, WarriorEntity object_prefab)
    {
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        if (!occupiedCells.Contains(gridPosition))
        {
            Vector3 position = tilemap.GetCellCenterWorld(gridPosition);
            Instantiate(object_prefab, position, Quaternion.identity,gameModel.WarriorsContainer);
            occupiedCells.Add(gridPosition);
        }
    }
}
