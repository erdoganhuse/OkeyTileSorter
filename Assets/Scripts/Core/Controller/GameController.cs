using DeveGames.CoroutineSystem;
using DeveGames.SceneManager;
using DG.Tweening;
using Signals;
using UnityEngine;
using Utilities.Constants;
using Zenject;

namespace Core.Controller
{
    public class GameController : IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly ZenjectSceneManager _sceneManager;

        public GameController(
            SignalBus signalBus,
            ZenjectSceneManager sceneManager)
        {
            _signalBus = signalBus;
            _sceneManager = sceneManager;
        }
        
        ~GameController(){}
        
        public void Initialize()
        {
            Application.targetFrameRate = 60;
            Input.multiTouchEnabled = false;
            Time.timeScale = 1f;
            DOTween.timeScale =  1f / Time.timeScale;
            
            StartGame();
        }

        private void StartGame()
        {
            _sceneManager.LoadSceneAsync(SceneNames.Game, () =>
            {
                _sceneManager.SetActiveScene(SceneNames.Game);
                
                CoroutineManager.DoAfterFixedUpdate(() =>
                {
                    _signalBus.TryFire<GameStartedSignal>();
                });
            });
        }
    }
}
