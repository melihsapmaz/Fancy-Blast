using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    // Tile properties
    public int Row { get; set; }
    public int Column { get; set; }
    private TileColor Color { get; set; }
    private Group Group { get; set; }
    private IconsDB iconsDB;
    
    // Icon sprite
    public Sprite Icon { get; set; }

    private void Awake()
    {
        iconsDB = IconsDB.Instance;
    }
    
    // Method to set the tile color randomly
    public void InitializeTile(int row, int column)
    {
        Row = row;
        Column = column;
        Color = (TileColor)Random.Range(1, GameManager.Instance.NumberOfColors + 1);
        Group = Group.Default;
    }
    
    // Method to set the tile icon
    public void SetIcon()
    {
        Icon = iconsDB.GetIcon(Color, Group);
    }

    public void SetPosition(int row, int column, Grid grid)
    {
        Row = row;
        Column = column;
        // Set the position of the tile
        transform.position = grid.GetCellCenterWorld(new Vector3Int(column, row, 0));
    }
    
}