using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SnakeClone
{
    public class GameControl : IObserver, IUpdateFrame, ISpawnPink
    {
        public static int Measure { get { return 20; } }
        private Vector playgroundDimension = new Vector(40, 30);
        private bool gameIsPaused;
        private IGUIClient guiClient;
        private Snake snake;
        private Apple apple;
        private PinkApple pinkApple;
        private Score score;
        private Highscore highscore;
        private ColorThemes colorThemes;
        private PlayTimer playTimer;
        private Collision collision;

        public GameControl(IGUIClient guiClient)
        {
            this.guiClient = guiClient;
            score = new Score();
            score.AddObserver(this);
            
            playTimer = new PlayTimer(this, this);
            playTimer.AddObserver(this);

            gameIsPaused = true;
            colorThemes = new ColorThemes();

            highscore = new Highscore();
        }

        public void UpdateFrame()
        {
            snake.Move();
            var collideWith = collision.CheckCollision();

            if (collideWith == CollisionTyp.Obstacle)
            {
                guiClient.SetVisibilityOfResume(false);
                playTimer.Pause();

                if (highscore.ReachedMinimumPoints(score.Points))
                    highscore.ShowNewEntryDialog(score.Points);
                
                    guiClient.ShowGameOver();
            }
            else if(collideWith == CollisionTyp.Apple)
            {
                apple.ReplaceApple();
                score.AddPoints(10);
                snake.Grow();
            }
            else if(collideWith == CollisionTyp.PinkApple)
            {
                pinkApple.HideApple();
                playTimer.ActivateBoost();
                score.AddPoints(10 * snake.Count);
            }
        }

        public void NewGame(IRenderer renderer)
        {
            playTimer.Reset();
            renderer.ClearScreen();
            DirectionControl.ResetDirection();
            score.ResetScore();

            new FieldBorder(renderer, (int)playgroundDimension.X, (int)playgroundDimension.Y);

            var snakeStartPoint = new Vector(playgroundDimension.X / 2 * Measure, playgroundDimension.Y / 2 * Measure);
            snake = new Snake(snakeStartPoint, renderer);

            apple = new Apple(ColorThemes.Apple);
            renderer.RenderObject(apple.GetShape());

            pinkApple = new PinkApple(ColorThemes.PinkApple);
            renderer.RenderObject(pinkApple.GetShape());

            collision = new Collision(snake, apple, pinkApple, playgroundDimension);

            apple.SetCollision(collision);
            apple.ReplaceApple();

            pinkApple.SetCollision(collision);
            pinkApple.HideApple();

            ResumeGame();
            guiClient.SetVisibilityOfResume(true);
        }

        public void PauseGame()
        {
            playTimer.Pause();
            gameIsPaused = true;
        }

        public void ResumeGame()
        {
            playTimer.Start();
            gameIsPaused = false;
        }

        public bool GameIsRunning()
        {
            return !gameIsPaused;
        }

        public void Update()
        {
            guiClient.UpdatePoints(score.Points);
            guiClient.UpdateTime(playTimer.GetCurrentPlaytime());
        }

        public List<HighscoreEntry> GetHighscoreForGUI()
        {
            return highscore.GetHighscoreList();
        }

        public void SpawnPinkApple()
        {
            pinkApple.ReplaceApple();
        }
    }
}
