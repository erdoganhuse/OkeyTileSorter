using System;
using Signals;
using UnityEngine;
using Zenject;

namespace Core.UI.View
{
    public class SplashScreenView : MonoBehaviour
    {
        private SignalBus _signalBus;

        private Canvas _canvas;
        private Canvas Canvas
        {
            get
            {
                if (_canvas == null) _canvas = GetComponent<Canvas>();
                return _canvas;
            }
        }
        
        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.Subscribe<GameStartedSignal>(OnGameStarted);
        }
        
        private void OnDestroy()
        {
            _signalBus.TryUnsubscribe<GameStartedSignal>(OnGameStarted);
        }

        private void Show()
        {
            Canvas.enabled = true;  
        }
        
        private void Hide()
        {
            Canvas.enabled = false;
        }

        #region Signal Listeners

        private void OnGameStarted()
        {
            Hide();
        }

        #endregion
    }
}