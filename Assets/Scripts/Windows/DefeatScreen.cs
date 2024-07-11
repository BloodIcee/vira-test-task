using Infrastructure.AssetManagement;
using Services;

namespace Windows
{
    public class DefeatScreen : WindowBase
    {
        private IResetGameService _resetGameService;

        public void InitDefeatScreen(IResetGameService resetGameService)
        {
            _resetGameService = resetGameService;
            
            CloseButton.onClick.AddListener(ResetButtonAction);
        }

        private void ResetButtonAction()
        {
            _resetGameService.ResetGame();
            //FirebaseAnalyticsManager.instance.LogLevelFail(UnityEngine.PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey));
        }

    }
}