using System;
using Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleLabel;
        [SerializeField] private Button playButton;

        private void Awake()
        {
            titleLabel.text = Application.productName;
            playButton.onClick.AddListener(() =>
            {
                Transition.Instance.LoadScene("GamePlay");
            });
        }
    }
}