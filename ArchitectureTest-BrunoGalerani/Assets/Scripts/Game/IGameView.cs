using System;
using Array2DEditor;

namespace Game
{
    // This interface was created in order to make it easier to test the game logic by mocking the view.
    public interface IGameView
    {
        void RequestLoadLevel(int levelIndex);
        void AnimateAndStartGame();
        void CreateBricks(Array2DBool levelLevelGrid, Action onBrickDestroyed);
        void SetScore(uint score);
        void SetLives(uint lives);
        void ShowBall(bool show);
        void ResetAllPositions();
        void StartBallMovement();
    }
}