using System.Numerics;

namespace MohawkGame2D;

public class FallingEnemy
{
    // Stores the enemy's current position
    public Vector2 Position;

    // Radius controls enemy size
    public float Radius;

    // Speed controls how fast the enemy falls downward
    public float Speed;

    // Constructor sets the enemy's starting values
    public FallingEnemy(float x, float y, float radius, float speed)
    {
        Position = new Vector2(x, y);
        Radius = radius;
        Speed = speed;
    }

    // Update makes the enemy fall downward
    public void Update()
    {
        // Move enemy down the screen
        Position.Y += Speed;

        // If the enemy goes off the bottom of the screen, move it back to the top
        if (Position.Y - Radius > 600)
        {
            // Give the enemy a new random X position
            Position.X = Random.Integer((int)Radius, Window.Width - (int)Radius);

            // Reset Y to just above the visible screen
            Position.Y = -Radius;
        }
    }

    // Draw the enemy as a red circle
    public void DrawSelf()
    {
        Draw.FillColor = Color.Red;
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
        Draw.Circle(Position, Radius);
    }
}