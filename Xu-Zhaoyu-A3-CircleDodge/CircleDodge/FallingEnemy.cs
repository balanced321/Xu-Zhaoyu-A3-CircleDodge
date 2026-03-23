using System.Numerics;

namespace MohawkGame2D;

public class FallingEnemy
{
    public Vector2 Position;
    public float Radius;
    public float Speed;

    public FallingEnemy(float x, float y, float radius, float speed)
    {
        Position = new Vector2(x, y);
        Radius = radius;
        Speed = speed;
    }

    public void Update()
    {
        Position.Y += Speed;

        if (Position.Y - Radius > 600)
        {
            Position.X = Random.Integer((int)Radius, Window.Width - (int)Radius);
            Position.Y = -Radius;
        }
    }

    public void DrawSelf()
    {
        Draw.FillColor = Color.Red;
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
        Draw.Circle(Position, Radius);
    }
}