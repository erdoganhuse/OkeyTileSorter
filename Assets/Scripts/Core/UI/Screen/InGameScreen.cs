using System.Collections.Generic;
using Core.Controller;
using Core.Data.Board;
using Core.Logic.HandSortStrategy;
using DeveGames.PopupSystem.Scripts;
using DeveGames.PopupSystem.Scripts.AnimationStrategy;
using UnityEngine;
using Utilities.Constants;
using Zenject;

namespace Core.UI.Screen
{
    [RequireComponent(typeof(ZenAutoInjecter))]
    public class InGameScreen : Popup<InGameScreen>
    {
        private PopupManager _gamePopupManager;
        private BoardController _boardController;
        private HandSortingController _handSortingController;
        
        [Inject]
        private void Construct(
            [Inject(Id = BindingIds.GamePopupManager)] PopupManager gamePopupManager,
            BoardController boardController,
            HandSortingController handSortingController)
        {
            _gamePopupManager = gamePopupManager;
            _boardController = boardController;
            _handSortingController = handSortingController;
        }
        
        private void Awake() => SetAnimationStrategy(new SubtleAnimationStrategy());

        #region UI Event Listeners

        public void OnStartScreenButtonClicked()
        {
            Close();
            CloseListener(() =>
            {
                _boardController.Clear();    
                _gamePopupManager.Open<StartScreen>();
            });
        }
        
        public void OnOneTwoTreeSortButtonClicked()
        {
            IList<TileGroup> groups = new List<TileGroup>();
            _handSortingController.Sort<OneTwoThreeSorter>(_boardController.CurrentHand, ref groups);
            _boardController.CurrentHand.AssignSortedGroups(groups);
        }

        public void OnSevenSevenSevenSortButtonClicked()
        {
            IList<TileGroup> groups = new List<TileGroup>();
            _handSortingController.Sort<SevenSevenSevenSorter>(_boardController.CurrentHand, ref groups);
            _boardController.CurrentHand.AssignSortedGroups(groups);
        }

        public void OnSmartSortButtonClicked()
        {
            IList<TileGroup> groups = new List<TileGroup>();
            _handSortingController.Sort<SmartSorter>(_boardController.CurrentHand, ref groups);
            _boardController.CurrentHand.AssignSortedGroups(groups);
        }

        #endregion
    }
}