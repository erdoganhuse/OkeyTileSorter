using Core.Data;
using Core.Data.Board;
using Core.Data.Settings;
using Core.View;
using Signals;
using UnityEngine;
using Utilities.Constants;
using Zenject;

namespace Core.Controller
{
    public class BoardController
    {
        public Tile OkeyTile { get; private set; }
        public Hand CurrentHand { get; private set; }
                
        private readonly SignalBus _signalBus;
        private readonly HandView.Pool _handPool;
        private readonly Transform _container;
        
        private Deck _gameDeck;

        private HandView _currentHandView;
        
        public BoardController(
            SignalBus signalBus,
            HandView.Pool handPool,
            [Inject(Id = BindingIds.BoardContainer)] Transform boardContainer)
        {
            _signalBus = signalBus;
            _handPool = handPool;
            _container = boardContainer;
        }

        ~BoardController()
        {
            Clear();
        }

        public void Initialize()
        {
            _gameDeck = Deck.CreateFullDeck();

            OkeyTile = _gameDeck.GetRandom();            
            CurrentHand = CreateHand();

            _currentHandView = _handPool.Spawn();
            _currentHandView.transform.SetParent(_container);
            _currentHandView.Setup(CurrentHand);
            _currentHandView.PlayDistributeAnimation();
            
            _signalBus.TryFire(new BoardCreatedSignal(OkeyTile));
        }
        
        public void Clear()
        {
            _gameDeck.Clear();
            CurrentHand.Clear();
            
            _currentHandView.Clear();
;           _handPool.Despawn(_currentHandView);
            
            _signalBus.TryFire(new BoardClearedSignal());
        }
        
        public Hand CreateHand()
        {
            Hand hand = new Hand();

            for (int i = 0; i < GameSettings.TileCountInHand; i++)
            {
                Tile tile = _gameDeck.PopRandom();
                hand.Add(tile);
            }

            _signalBus.TryFire(new HandCreatedSignal(hand));
            
            return hand;
        }
    }
}