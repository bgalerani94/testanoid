using System;
using System.Collections;
using Array2DEditor;
using Level;
using Singletons;
using UnityEngine;

namespace Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        [Header("Assignments")] [SerializeField]
        private BallController ball;

        [SerializeField] private PlayerController player;
        [SerializeField] private BrickCreator brickCreator;
        [SerializeField] private Death death;
        [SerializeField] private GameCanvas gameCanvas;
        [SerializeField] private LevelLoader levelLoader;

        private GameController _gameController;

        private void Start()
        {
            _gameController = new GameController(SingletonComponent<AppController>.Instance,
                SingletonComponent<Transition>.Instance,
                levelLoader.LevelsAmount);

            _gameController.Bind(this);

            death.OnDeath += _gameController.OnDeath;
        }

        private void OnDestroy()
        {
            _gameController.Unbind();
        }

        private void Update()
        {
            #region Debug

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _gameController.OnDebugResetPressed();
            }

            #endregion
        }

        public void AnimateAndStartGame()
        {
            StartCoroutine(StartGame());
        }

        public void RequestLoadLevel(int levelIndex)
        {
            levelLoader.LoadLevelAsync(levelIndex, _gameController.OnLevelLoaded,
                _gameController.OnLevelFailure);
        }

        public void SetLives(uint lives)
        {
            gameCanvas.SetLives(lives);
        }

        public void SetScore(uint score)
        {
            gameCanvas.SetScore(score);
        }

        public void CreateBricks(Array2DBool levelGrid, Action onBrickDestroyed)
        {
            brickCreator.CreateBricks(levelGrid, onBrickDestroyed);
        }

        public void ShowBall(bool show)
        {
            ball.Show(show);
        }

        public void ResetAllPositions()
        {
            player.ResetPosition();
            ball.ResetPosition();
        }

        public void StartBallMovement()
        {
            ball.PerformInitialKick();
        }

        private IEnumerator StartGame()
        {
            yield return gameCanvas.PlayCountdown();
            _gameController.OnCountdownEnded();
        }
    }
}