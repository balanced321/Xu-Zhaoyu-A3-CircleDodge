using System;
using System.Numerics;

namespace MohawkGame2D;

public class Game
{
    Player player;
    FallingEnemy[] enemies;
    StarCollectible star;

    bool gameOver;
    bool gameWin;
    int score;
    int targetScore = 5;

    public void Setup()
    {
        Window.SetSize(800, 600);
        Window.SetTitle("Circle Dodge");
        Window.TargetFPS = 60;
        Window.CentreWindow();

        ResetGame();
    }

    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        if (!gameOver && !gameWin)
        {
            UpdateGame();
        }
        else
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                ResetGame();
            }
        }

        DrawBackground();
        DrawGame();
        DrawUI();
    }

    void ResetGame()
    {
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

        star = new StarCollectible(400, 200, 12);
        star.Respawn();

        score = 0;
        gameOver = false;
        gameWin = false;
    }

    void UpdateGame()
    {
        player.Update();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Update();

            if (player.CollidesWith(enemies[i].Position, enemies[i].Radius))
            {
                gameOver = true;
            }
        }

        if (player.CollidesWith(star.Position, star.Radius))
        {
            score++;
            star.Respawn();

            if (score >= targetScore)
            {
                gameWin = true;
            }
        }
    }

    void DrawGame()
    {
        player.DrawSelf();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].DrawSelf();
        }

        star.DrawSelf();
    }

    void DrawUI()
    {
        Text.Color = Color.Black;
        Text.Size = 24;
        Text.Draw("Score: " + score, 20, 20);
        Text.Draw("Goal: " + targetScore, 20, 50);

        if (gameOver)
        {
            Text.Color = Color.Red;
            Text.Size = 40;
            Text.Draw("GAME OVER", 270, 250);

            Text.Color = Color.Black;
            Text.Size = 22;
            Text.Draw("Press SPACE to restart", 285, 300);
        }

        if (gameWin)
        {
            Text.Color = Color.Green;
            Text.Size = 40;
            Text.Draw("YOU WIN!", 295, 250);

            Text.Color = Color.Black;
            Text.Size = 22;
            Text.Draw("Press SPACE to restart", 285, 300);
        }
    }

    void DrawBackground()
    {
        Draw.LineColor = Color.DarkGray;
        Draw.LineSize = 4;
        Draw.Line(0, 560, 800, 560);
    }
}