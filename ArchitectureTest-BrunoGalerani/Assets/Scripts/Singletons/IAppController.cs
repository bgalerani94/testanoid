using Data;

namespace Singletons
{
    public interface IAppController
    {
        GameData GameData { get; }
        int CurrentLevel { get; }
        bool IsMobile();
        void OnLevelCompleted();
        void ResetGame();
    }
}