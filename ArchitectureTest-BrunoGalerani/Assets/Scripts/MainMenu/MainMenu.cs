using Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleLabel;
        [SerializeField] private Button playButton;

        private void Start()
        {
            titleLabel.text = Application.productName;
            playButton.onClick.AddListener(() =>
                SingletonComponent<Transition>.Instance.LoadScene(Constants.GameScene));
        }
    }
}