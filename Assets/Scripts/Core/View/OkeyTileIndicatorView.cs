using DeveGames.CoroutineSystem;
using DG.Tweening;
using Signals;
using UnityEngine;
using Zenject;

namespace Core.View
{
    public class OkeyTileIndicatorView : MonoBehaviour
    {
        [SerializeField] private float _pressDurationToToggle;
        [SerializeField] private Transform _background;
        
        private SignalBus _signalBus;
        private TileView.Pool _tilePool;

        private TileView _okeyTileView;
        private Coroutine _toggleCheckCoroutine;
        
        [Inject]
        private void Construct(
            SignalBus signalBus,
            TileView.Pool tilePool)
        {
            _signalBus = signalBus;
            _tilePool = tilePool;
        }

        private void Start()
        {
            _signalBus.Subscribe<BoardCreatedSignal>(OnBoardCreated);
            _signalBus.Subscribe<BoardClearedSignal>(OnBoardCleared);
            
            Hide();
        }
        
        private void OnDestroy()
        {
            _signalBus.TryUnsubscribe<BoardCreatedSignal>(OnBoardCreated);
            _signalBus.TryUnsubscribe<BoardClearedSignal>(OnBoardCleared);
        }
        
        private void OnMouseDown()
        {            
            _toggleCheckCoroutine = CoroutineManager.DoAfterGivenUnscaledTime(_pressDurationToToggle, () =>
            {
                _okeyTileView.transform.DOLocalRotate(_okeyTileView.transform.localEulerAngles + new Vector3(0f, 180f, 0f), 0.5f);
            });
        }

        private void OnMouseUp()
        {
            CoroutineManager.StopChildCoroutine(_toggleCheckCoroutine);   
        }

        private void Show()
        {
            gameObject.SetActive(true);
            _background.gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            _background.gameObject.SetActive(false);            
        }
        
        #region Signal Listeners

        private void OnBoardCreated(BoardCreatedSignal boardCreatedSignal)
        {
            Show();

            _okeyTileView = _tilePool.Spawn();
            _okeyTileView.transform.SetParent(transform);
            _okeyTileView.transform.localPosition = Vector3.zero;
            _okeyTileView.Setup(boardCreatedSignal.OkeyTile);
        }

        private void OnBoardCleared()
        {
            if (_okeyTileView != null)
            {
                _tilePool.Despawn(_okeyTileView);
            }
            
            Hide();
        }

        #endregion
    }
}