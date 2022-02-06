using Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace EndMenu
{
    public class EndMenu : MonoBehaviour
    {
        [Header("Assignments")] [SerializeField]
        private TMP_Text scoreLabel;

        [SerializeField] private Button playAgainButton;

        private AppController _appController;
        private Transition _transition;

        private void Start()
        {
            _appController = SingletonComponent<AppController>.Instance;
            _transition = SingletonComponent<Transition>.Instance;

            scoreLabel.text = $"Score: {_appController.GameData.Score}";

            playAgainButton.onClick.AddListener(OnPlayAgainClicked);
        }

        private void OnPlayAgainClicked()
        {
            _appController.ResetGame();
            _transition.LoadScene(Constants.GameScene);
        }
    }
}