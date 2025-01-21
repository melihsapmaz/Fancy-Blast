using UnityEngine;

[CreateAssetMenu(fileName = "IconsDB", menuName = "Scriptable Objects/IconsDB")]

// Scriptable object to store the icon sprites
// 0th index is for default group, 1st index is for group A, 2nd index is for group B, and 3rd index is for group C
public class IconsDB : ScriptableObject
{
    // Icon sprites, each color has a sprite for each group
    public Sprite[] redIcons;
    public Sprite[] blueIcons;
    public Sprite[] greenIcons;
    public Sprite[] yellowIcons;
    public Sprite[] purpleIcons;
    public Sprite[] pinkIcons;
    
    // Singleton instance
    private static IconsDB instance;
    
    // Singleton pattern read-only property to get the instance of the IconsDB
    public static IconsDB Instance
    {
        get { return
                // If the instance is not set, returns the right side of the assignment, otherwise returns the instance
                instance ??= UnityEngine.Resources.Load<IconsDB>("IconsDB");
        }
    }
    
    // Method to get the icon sprite for a specific color and group
    public Sprite GetIcon(TileColor color, Group group)
    {
        // Get the index of the icon sprite based on the group
        int index = (int)group;
        
        // Get the icon sprite based on the color
        return color switch
        {
            TileColor.Red => redIcons[index],
            TileColor.Blue => blueIcons[index],
            TileColor.Green => greenIcons[index],
            TileColor.Yellow => yellowIcons[index],
            TileColor.Purple => purpleIcons[index],
            TileColor.Pink => pinkIcons[index],
            _ => null
        };
    }
    
    
    
}