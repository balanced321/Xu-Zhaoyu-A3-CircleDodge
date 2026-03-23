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

    public void DrawSelf()
    {
        Draw.FillColor = Color.Blue;
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
        Draw.Circle(Position, Radius);
    }
}