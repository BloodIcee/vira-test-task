using System.Collections;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using Services.ObjectMover;
using Services.WindowService;
using StaticData;
using UnityEngine;

namespace Logic
{
    public class LevelPlayingTimer : MonoBehaviour
    {
        private IGameFactory _factory;
        private IStaticDataService _staticData;
        private IWindowService _windowService;
        private IObjectMover _objectMover;

        private LevelStaticData _levelData;

        [SerializeField] private Vector3 _targetVector = new Vector3(0, 4.08f, 75f);

        public static LevelPlayingTimer instance;

        private void Awake()
        {
            instance = this;

            _factory = AllServices.Container.Single<IGameFactory>();
            _staticData = AllServices.Container.Single<IStaticDataService>();
            _windowService = AllServices.Container.Single<IWindowService>();
            _objectMover = AllServices.Container.Single<IObjectMover>();

            var levelData = PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey);

            if (levelData == 0)
            {
                levelData = 1;
            }

            _levelData = _staticData.ForLevel(levelData);
        }

        public void StartLevelPlayingCoroutine()
        {
            var levelData = PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey);

            if (levelData == 0)
            {
                levelData = 1;
            }
            
            var timeToPlay = _staticData.ForLevel(levelData).timeToPlay;
            StartCoroutine(LevelTimePlaying(timeToPlay));
        }
        
        private IEnumerator LevelTimePlaying(float waitTime)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            FinishGame();
        }

        private void FinishGame()
        {
            var finishLine = _factory.CreateFinishLine(_targetVector).GetComponent<FinishLine>();
            finishLine.InitFinishLine(_windowService, _objectMover, _levelData.moneyPerWin);
        }
    }
}