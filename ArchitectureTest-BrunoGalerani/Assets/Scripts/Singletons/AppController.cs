using Data;
using UnityEngine;

namespace Singletons
{
    public class AppController : SingletonComponent<AppController>, IAppController
    {
        [SerializeField] private uint livesAmount;

        private bool _isMobile;

        public GameData GameData { get; private set; }
        public int CurrentLevel { get; private set; }

        private void Awake()
        {
            GameData = new GameData(livesAmount);
            _isMobile = Application.isMobilePlatform;
        }

        public bool IsMobile()
        {
            return _isMobile;
        }

        public void OnLevelCompleted()
        {
            CurrentLevel++;
        }

        public void OnGameReset()
        {
            GameData = new GameData(livesAmount);
            CurrentLevel = 0;
        }
    }
}