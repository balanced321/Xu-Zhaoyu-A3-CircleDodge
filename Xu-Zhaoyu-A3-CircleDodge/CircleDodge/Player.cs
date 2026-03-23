using System.Numerics;

namespace MohawkGame2D;

public class Player
{
    // Stores the player's current position on screen
    public Vector2 Position;

    // Radius controls the player circle size
    public float Radius;

    // Speed controls how fast the player moves each frame
    public float Speed;

    // Constructor sets the player's starting values
    public Player(float x, float y, float radius, float speed)
    {
        Position = new Vector2(x, y);
        Radius = radius;
        Speed = speed;
    }

    // Update handles player movement and screen boundaries
    public void Update()
    {
        // Get movement input from WASD and arrow keys
        Vector2 move =
            Input.GetAxis2(KeyboardInput.A, KeyboardInput.D, KeyboardInput.W, KeyboardInput.S) +
            Input.GetAxis2(KeyboardInput.Left, KeyboardInput.Right, KeyboardInput.Up, KeyboardInput.Down);

        // Move the player using the input direction and speed
        Position += move * Speed;

        // Prevent the player from leaving the screen
        if (Position.X < Radius) Position.X = Radius;
        if (Position.X > Window.Width - Radius) Position.X = Window.Width - Radius;
        if (Position.Y < Radius) Position.Y = Radius;

        // Limit the player so they stay above the ground line
        if (Position.Y > 560 - Radius) Position.Y = 560 - Radius;
    }

    // Draw the player as a blue circle
    public void DrawSelf()
    {
        Draw.FillColor = Color.Blue;
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
        Draw.Circle(Position, Radius);
    }

    // Check collision between the player and another circular object
    public bool CollidesWith(Vector2 otherPosition, float otherRadius)
    {
        // Find the distance between the centers of the two circles
        Vector2 difference = Position - otherPosition;
        float distanceSquared = difference.X * difference.X + difference.Y * difference.Y;

        // Add both radii together for collision range
        float radiusTotal = Radius + otherRadius;

        // If distance is less than or equal to the combined radii, they are touching
        return distanceSquared <= radiusTotal * radiusTotal;
    }
}