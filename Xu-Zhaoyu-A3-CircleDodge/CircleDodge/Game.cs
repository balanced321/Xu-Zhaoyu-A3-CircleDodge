using System;
using System.Numerics;

namespace MohawkGame2D;

public class Game
{
    Player player;
    FallingEnemy[] enemies;

    public void Setup()
    {
        Window.SetSize(800, 600);
        Window.SetTitle("Circle Dodge");
        Window.TargetFPS = 60;
        Window.CentreWindow();

        player = new Player(400, 520, 20, 5f);

        enemies = new FallingEnemy[10];
        for (int i = 0; i < enemies.Length; i++)
        {
            float x = 60 + i * 70;
            float y = -40 - i * 60;
            float radius = 18;
            float speed = 2f + i * 0.2f;

            enemies[i] = new FallingEnemy(x, y, radius, speed);
        }
    }

    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        player.Update();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Update();
        }

        DrawBackground();
        player.DrawSelf();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].DrawSelf();
        }
    }

    void DrawBackground()
    {
        Draw.LineColor = Color.DarkGray;
        Draw.LineSize = 4;
        Draw.Line(0, 560, 800, 560);
    }
}