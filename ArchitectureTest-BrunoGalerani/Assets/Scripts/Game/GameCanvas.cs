using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Singletons;
using TMPro;
using UnityEngine;

namespace Game
{
    public class GameCanvas : MonoBehaviour
    {
        [Header("Assignments")] [SerializeField]
        private TMP_Text getReadyLabel;

        [SerializeField] private CanvasGroup startGameUIGroup;
        [SerializeField] private TMP_Text tutorialLabel;
        [SerializeField] private TMP_Text scoreLabel;
        [SerializeField] private TMP_Text livesLabel;

        [Header("Set in Editor")] [SerializeField]
        private string baseScoreText = "Score:";

        [SerializeField] private string baseLivesText = "Lives:";

        [Range(2, 5)] [Tooltip("Total time of the GetReady animation.")] [SerializeField]
        private float getReadyTime;

        [SerializeField] private List<string> getReadyTexts;
        [SerializeField] private string mobileTutorialText;
        [SerializeField] private string desktopTutorialText;


        private void Start()
        {
            SetTutorialText(AppController.Instance.IsMobile()
                ? mobileTutorialText
                : desktopTutorialText);
        }

        public void SetScore(uint score)
        {
            scoreLabel.text = $"{baseScoreText} {score}";
        }

        public void SetLives(uint lives)
        {
            livesLabel.text = $"{baseLivesText} {lives}";
        }

        private void SetTutorialText(string text)
        {
            tutorialLabel.text = text;
        }

        public IEnumerator PlayCountdown()
        {
            getReadyLabel.text = getReadyTexts.First();
            startGameUIGroup.gameObject.SetActive(true);

            var timeForEachStep = getReadyTime / getReadyTexts.Count;
            for (var i = 0; i < getReadyLabel.text.Length; i++)
            {
                getReadyLabel.text = getReadyTexts[i];
                yield return new WaitForSeconds(timeForEachStep);
            }

            startGameUIGroup.gameObject.SetActive(false);
        }
    }
}