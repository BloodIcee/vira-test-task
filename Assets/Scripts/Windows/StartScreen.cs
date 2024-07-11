using Infrastructure.AssetManagement;
using Logic;
using Services.ObjectMover;
using TMPro;
using UnityEngine;

namespace Windows
{
    public class StartScreen : WindowBase
    {
        [SerializeField] private TextMeshProUGUI coinAmountText;
        private LevelPlayingTimer _levelTimePlayingCounter;

        public void InitStartScreen(IObjectMover objectMover)
        {
            CloseButton.onClick.AddListener(StartGameClickAction);

            coinAmountText.text = PlayerPrefs.GetInt(PlayerPrefsKeys.CoinKey).ToString();
            Time.timeScale = 0;
            
            objectMover.MoveAction(true);
            _levelTimePlayingCounter = LevelPlayingTimer.instance;
        }

        private void StartGameClickAction()
        {
            Time.timeScale = 1;
            _levelTimePlayingCounter.StartLevelPlayingCoroutine();
            //FirebaseAnalyticsManager.instance.LogLevelStart(PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey));
        }
    }
}