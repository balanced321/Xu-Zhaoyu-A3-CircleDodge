using System;
using System.Numerics;

namespace MohawkGame2D;

public class Game
{
    // Main game objects
    Player player;
    FallingEnemy[] enemies;
    StarCollectible star;

    // Game state variables
    bool gameOver;
    bool gameWin;
    int score;
    int targetScore = 5; // Number of stars needed to win

    // Setup runs once at the start of the game
    public void Setup()
    {
        // Set up the window properties
        Window.SetSize(800, 600);
        Window.SetTitle("Circle Dodge");
        Window.TargetFPS = 60;
        Window.CentreWindow();

        // Create all game objects and reset variables
        ResetGame();
    }

    // Update runs every frame
    public void Update()
    {
        // Clear the screen each frame before drawing the new frame
        Window.ClearBackground(Color.OffWhite);

        // Only update movement/collision if the game is still active
        if (!gameOver && !gameWin)
        {
            UpdateGame();
        }
        else
        {
            // If the game has ended, allow the player to restart with SPACE
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                ResetGame();
            }
        }

        // Draw everything after updating logic
        DrawBackground();
        DrawGame();
        DrawUI();
    }

    // ResetGame creates a fresh game state
    void ResetGame()
    {
        // Create the player near the bottom center of the screen
        player = new Player(400, 520, 20, 5f);

        // Create an array of 10 enemy objects
        enemies = new FallingEnemy[10];
        for (int i = 0; i < enemies.Length; i++)
        {
            // Spread enemies across the screen and stagger their starting heights
            float x = 60 + i * 70;
            float y = -40 - i * 60;
            float radius = 18;
            float speed = 2f + i * 0.2f;

            enemies[i] = new FallingEnemy(x, y, radius, speed);
        }

        // Create the collectible star and place it at a random position
        star = new StarCollectible(400, 200, 12);
        star.Respawn();

        // Reset game status values
        score = 0;
        gameOver = false;
        gameWin = false;
    }

    // Update all active game logic
    void UpdateGame()
    {
        // Update player movement from keyboard input
        player.Update();

        // Update each enemy and check if it hits the player
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Update();

            // If the player touches any enemy, the player loses
            if (player.CollidesWith(enemies[i].Position, enemies[i].Radius))
            {
                gameOver = true;
            }
        }

        // Check if the player touches the collectible star
        if (player.CollidesWith(star.Position, star.Radius))
        {
            // Increase score and move the star somewhere else
            score++;
            star.Respawn();

            // If the player reaches the target score, they win
            if (score >= targetScore)
            {
                gameWin = true;
            }
        }
    }

    // Draw all main gameplay objects
    void DrawGame()
    {
        player.DrawSelf();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].DrawSelf();
        }

        star.DrawSelf();
    }

    // Draw score, instructions, and win/lose messages
    void DrawUI()
    {
        Text.Color = Color.Black;
        Text.Size = 24;
        Text.Draw("Score: " + score, 20, 20);
        Text.Draw("Goal: " + targetScore, 20, 50);

        Text.Size = 18;
        Text.Draw("Move with arrow keys or WASD", 20, 82);

        // Show lose message
        if (gameOver)
        {
            Text.Color = Color.Red;
            Text.Size = 40;
            Text.Draw("GAME OVER", 270, 250);

            Text.Color = Color.Black;
            Text.Size = 22;
            Text.Draw("Press SPACE to restart", 285, 300);
        }

        // Show win message
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

    // Draw simple background decoration
    void DrawBackground()
    {
        // Draw cloud-like shapes in the sky
        Draw.FillColor = new Color(220, 235, 255);
        Draw.LineColor = new Color(220, 235, 255);
        Draw.LineSize = 1;
        Draw.Ellipse(130, 90, 110, 50);
        Draw.Ellipse(210, 110, 120, 55);
        Draw.Ellipse(300, 85, 100, 45);

        // Draw a ground line near the bottom of the screen
        Draw.LineColor = Color.DarkGray;
        Draw.LineSize = 4;
        Draw.Line(0, 560, 800, 560);

        // Draw simple ground decorations
        Draw.FillColor = Color.LightGray;
        Draw.LineColor = Color.Gray;
        Draw.LineSize = 2;
        Draw.Ellipse(120, 580, 180, 20);
        Draw.Ellipse(400, 580, 240, 20);
        Draw.Ellipse(690, 580, 160, 20);
    }
}