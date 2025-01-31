﻿using Infrastructure.AssetManagement;
using Services;

namespace Windows
{
    public class VictoryScreen : WindowBase
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
            //FirebaseAnalyticsManager.instance.LogLevelComplete(UnityEngine.PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey));
        }
    }
}