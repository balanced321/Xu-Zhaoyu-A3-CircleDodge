using System.Numerics;

namespace MohawkGame2D;

public class StarCollectible
{
    // Stores the collectible's current position
    public Vector2 Position;

    // Radius controls the collectible size
    public float Radius;

    // Constructor sets the collectible's starting values
    public StarCollectible(float x, float y, float radius)
    {
        Position = new Vector2(x, y);
        Radius = radius;
    }

    // Move the collectible to a new random location
    public void Respawn()
    {
        // Choose a random X position within the screen
        Position.X = Random.Integer((int)Radius + 20, Window.Width - (int)Radius - 20);

        // Choose a random Y position in the main play area
        Position.Y = Random.Integer(80, 500);
    }

    // Draw the collectible
    public void DrawSelf()
    {
        Draw.FillColor = Color.Yellow;
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;

        // Main collectible body
        Draw.Circle(Position, Radius);

        // Decorative cross lines to make it stand out more
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
        Draw.Line(Position.X - Radius - 4, Position.Y, Position.X + Radius + 4, Position.Y);
        Draw.Line(Position.X, Position.Y - Radius - 4, Position.X, Position.Y + Radius + 4);
    }
}