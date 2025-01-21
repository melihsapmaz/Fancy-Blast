using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    // Grid Object
    [SerializeField] private Grid grid;
    
    private const int CellSize = 100;
    
    private static GameManager gameManager;
    
    
    // Board dimensions
    private int rowCount;
    private int columnCount;
    
    private void Start()
    {
        gameManager = GameManager.Instance;
        CreateBoard();
    }
    
    // Method to create the board
    public void CreateBoard()
    {
        // Get the game parameters from the GameManager
        rowCount = gameManager.RowCount;
        columnCount = gameManager.ColumnCount;
        
        // Loop through the rows and columns to create the board
        for (var row = 0; row < rowCount; row++)
        {
            for (var column = 0; column < columnCount; column++)
            {
                var tile = Instantiate(tilePrefab, grid.transform, true);
                tile.SetPosition(row, column, grid);
                tile.InitializeTile(row, column);
            }
        }
        
        
        
    }
    
}
