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

        [SerializeField] private Button linkedInButton;
        [SerializeField] private Button playAgainButton;

        private AppController _appController;
        private Transition _transition;

        private void Start()
        {
            _appController = SingletonComponent<AppController>.Instance;
            _transition = SingletonComponent<Transition>.Instance;

            scoreLabel.text = $"Score: {_appController.GameData.Score}";

            linkedInButton.onClick.AddListener(OnLinkedInClicked);
            playAgainButton.onClick.AddListener(OnPlayAgainClicked);
        }

        private static void OnLinkedInClicked()
        {
            Application.OpenURL("https://www.linkedin.com/in/brunogalerani/");
        }

        private void OnPlayAgainClicked()
        {
            _appController.ResetGame();
            _transition.LoadScene(Constants.GameScene);
        }
    }
}