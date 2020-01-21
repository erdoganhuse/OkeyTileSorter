using Core.UI.Screen;
using DeveGames.PopupSystem.Scripts;
using Signals;
using Utilities.Constants;
using Zenject;

namespace Core.Controller
{
    public class UiController
    {
        private readonly SignalBus _signalBus;
        private readonly PopupManager _gamePopupManager;
        
        public UiController(
            SignalBus signalBus,
            [Inject(Id = BindingIds.GamePopupManager)] PopupManager gamePopupManager)
        {
            _signalBus = signalBus;
            _gamePopupManager = gamePopupManager;
            
            _signalBus.Subscribe<GameStartedSignal>(OnGameStarted);
        }
        
        ~UiController()
        {
            _signalBus.TryUnsubscribe<GameStartedSignal>(OnGameStarted);
        }
        
        #region Signal Listners

        private void OnGameStarted()
        {
            _gamePopupManager.Open<StartScreen>();
        }

        #endregion
    }
}