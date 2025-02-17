using System.Numerics;

namespace CoffeeShop.Utile;

public static class UtileMouse
{
    
    /// <summary>
    /// Checks if the mouse is within the specified rectangular area.
    /// </summary>
    /// <param name="mousePosition">Reference to the top-left mouse position of the rectangle.</param>
    /// <param name="size">Reference to the size of the rectangle.</param>
    /// <returns>True if the mouse is within the rectangle, otherwise false.</returns>
    public static bool CheckMouseInRectangle(ref Vector2 mousePosition,ref Vector2 rectanglePosition, ref Vector2 size)
    {
        return mousePosition.X > rectanglePosition.X
               && mousePosition.X < rectanglePosition.X + size.X
               && mousePosition.Y > rectanglePosition.Y
               && mousePosition.Y < rectanglePosition.Y + size.Y;
    }
    
}