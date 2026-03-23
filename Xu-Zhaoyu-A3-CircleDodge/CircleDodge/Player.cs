using System.Numerics;

namespace MohawkGame2D;

public class Player
{
    public Vector2 Position;
    public float Radius;
    public float Speed;

    public Player(float x, float y, float radius, float speed)
    {
        Position = new Vector2(x, y);
        Radius = radius;
        Speed = speed;
    }

    public void Update()
    {
        Vector2 move =
            Input.GetAxis2(KeyboardInput.A, KeyboardInput.D, KeyboardInput.W, KeyboardInput.S) +
            Input.GetAxis2(KeyboardInput.Left, KeyboardInput.Right, KeyboardInput.Up, KeyboardInput.Down);

        Position += move * Speed;

        if (Position.X < Radius) Position.X = Radius;
        if (Position.X > Window.Width - Radius) Position.X = Window.Width - Radius;
        if (Position.Y < Radius) Position.Y = Radius;
        if (Position.Y > 560 - Radius) Position.Y = 560 - Radius;
    }

    public void DrawSelf()
    {
        Draw.FillColor = Color.Blue;
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
        Draw.Circle(Position, Radius);
    }
}