using System.Numerics;

namespace MohawkGame2D;

public class StarCollectible
{
    public Vector2 Position;
    public float Radius;

    public StarCollectible(float x, float y, float radius)
    {
        Position = new Vector2(x, y);
        Radius = radius;
    }

    public void Respawn()
    {
        Position.X = Random.Integer((int)Radius + 20, Window.Width - (int)Radius - 20);
        Position.Y = Random.Integer(80, 500);
    }

    public void DrawSelf()
    {
        Draw.FillColor = Color.Yellow;
        Draw.LineColor = Color.Black;
        Draw.LineSize = 2;
        Draw.Circle(Position, Radius);
    }
}