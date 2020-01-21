using Core.Controller;
using Core.View;
using DeveGames.PopupSystem.Scripts;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;
using Utilities.Constants;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Header("UI")]
        [SerializeField] [Required] private PopupManager _gamePopupManager;

        [Header("Prefabs")]
        [SerializeField] [Required] private TileView _tilePrefab;
        [SerializeField] [Required] private HandView _handPrefab;
        
        [Header("References")]
        [SerializeField] [Required] private Transform _boardContainer;
        
        public override void InstallBindings()
        {
            InstallPools();
            InstallSignals();
            
            Container.BindInterfacesAndSelfTo<CheatCodes>().AsSingle().NonLazy();

            Container.Bind<BoardController>().AsSingle().NonLazy();
            Container.Bind<HandSortingController>().AsSingle().NonLazy();

            Container.Bind<UiController>().AsSingle().NonLazy();
            Container.BindInstance(_gamePopupManager).WithId(BindingIds.GamePopupManager).NonLazy();
            
            Container.BindInstance(_boardContainer).WithId(BindingIds.BoardContainer).NonLazy();            
        }

        private void InstallPools()
        {
            Container.BindMemoryPool<TileView, TileView.Pool>()
                .WithInitialSize(TileView.Pool.Size)
                .FromComponentInNewPrefab(_tilePrefab)
                .UnderTransformGroup(TileView.Pool.GroupName);
            
            Container.BindMemoryPool<HandView, HandView.Pool>()
                .WithInitialSize(HandView.Pool.Size)
                .FromComponentInNewPrefab(_handPrefab)
                .UnderTransformGroup(HandView.Pool.GroupName);                
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<BoardCreatedSignal>();
            Container.DeclareSignal<BoardClearedSignal>();
            Container.DeclareSignal<HandCreatedSignal>();
        }
    }
}