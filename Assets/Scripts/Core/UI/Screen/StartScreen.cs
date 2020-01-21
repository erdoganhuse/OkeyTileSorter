using Core.Controller;
using DeveGames.PopupSystem.Scripts;
using DeveGames.PopupSystem.Scripts.AnimationStrategy;
using UnityEngine;
using Utilities.Constants;
using Zenject;

namespace Core.UI.Screen
{
    [RequireComponent(typeof(ZenAutoInjecter))]
    public class StartScreen : Popup<StartScreen>
    {
        private PopupManager _gamePopupManager;
        private BoardController _boardController;
        
        [Inject]
        private void Construct(
            [Inject(Id = BindingIds.GamePopupManager)] PopupManager gamePopupManager, 
            BoardController boardController)
        {
            _gamePopupManager = gamePopupManager;
            _boardController = boardController;
        }
        
        private void Awake() => SetAnimationStrategy(new SubtleAnimationStrategy());

        #region UI Event Listeners

        public void OnStartButtonClicked()
        {
            Close();
            CloseListener(() =>
            {
                _gamePopupManager.Open<InGameScreen>();

                _boardController.Initialize();
            });
        }
        
        #endregion
    }
}