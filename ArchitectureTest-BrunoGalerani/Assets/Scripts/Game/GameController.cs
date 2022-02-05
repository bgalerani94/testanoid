using Level;
using Singletons;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// This class is responsible for all the business logic for the game scene.
    /// </summary>
    public class GameController
    {
        private readonly int _levelsAmount;

        private IAppController _appController;
        private ITransition _transition;
        private IGameView _view;

        private uint _currentBricks;

        public GameController(IAppController appController, ITransition transition,
            int levelsAmount)
        {
            _appController = appController;
            _transition = transition;
            _levelsAmount = levelsAmount;
        }

        public void Bind(IGameView view)
        {
            _view = view;
            _view.RequestLoadLevel(_appController.CurrentLevel);
            _view.SetScore(_appController.GameData.Score);
            _view.SetLives(_appController.GameData.Lives);
        }

        public void Unbind()
        {
            _appController = null;
            _transition = null;
            _view = null;
        }

        public void OnCountdownEnded()
        {
            _view.StartBallMovement();
        }

        public void OnLevelLoaded(LevelScriptableObject level)
        {
            _view.AnimateAndStartGame();
            _view.CreateBricks(level.levelGrid, OnBrickDestroyed);
            _currentBricks = level.GetBricksCount();
        }

        public void OnLevelFailure()
        {
            Debug.LogError("There was a problem while loading the level. Going back to main scene");
            _transition.LoadScene("Main");
        }

        public void OnDeath()
        {
            _appController.GameData.Lives--;
            _view.SetLives(_appController.GameData.Lives);

            if (_appController.GameData.Lives > 0)
            {
                ResetPositions();
                _view.AnimateAndStartGame();
            }
            else
            {
                _view.ShowBall(false);
                _appController.OnGameReset();
                // Transition.Instance.LoadScene("Lose");
                Transition.Instance.LoadScene("Main");
            }
        }

        private void OnBrickDestroyed()
        {
            _currentBricks--;
            _appController.GameData.Score++;
            _view.SetScore(_appController.GameData.Score);
            if (_currentBricks <= 0)
            {
                _view.ShowBall(false);
                _appController.OnLevelCompleted();
                if (_appController.CurrentLevel >= _levelsAmount)
                {
                    _appController.OnGameReset();
                    // Transition.Instance.LoadScene("Win");
                    Transition.Instance.LoadScene("Main");
                }
                else
                {
                    Transition.Instance.LoadScene("GamePlay");
                }
            }
        }

        private void ResetPositions()
        {
            _view.ResetAllPositions();
            _view.ShowBall(true);
        }
    }
}