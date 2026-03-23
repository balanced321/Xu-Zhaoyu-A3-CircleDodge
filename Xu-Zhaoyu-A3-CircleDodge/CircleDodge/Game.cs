using System;
using System.Numerics;

namespace MohawkGame2D;

public class Game
{
    Player player;

    public void Setup()
    {
        Window.SetSize(800, 600);
        Window.SetTitle("Circle Dodge");
        Window.TargetFPS = 60;
        Window.CentreWindow();

        player = new Player(400, 520, 20, 5f);
    }

    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        player.Update();

        DrawBackground();
        player.DrawSelf();
    }

    void DrawBackground()
    {
        Draw.LineColor = Color.DarkGray;
        Draw.LineSize = 4;
        Draw.Line(0, 560, 800, 560);
    }
}