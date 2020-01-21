using System.Collections.Generic;
using Core.Data.Board;
using Helper.Layout;
using UnityEngine;
using Zenject;

namespace Core.View
{
    [RequireComponent(typeof(ZenAutoInjecter))]
    [RequireComponent(typeof(WorldGridLayout))]
    public class HandView : MonoBehaviour
    {
        [SerializeField] private WorldGridLayout _gridLayout;
        
        private Hand _hand;
        private IList<TileView> _tileViews;

        private TileView.Pool _tilePool;
        
        [Inject]
        private void Construct(TileView.Pool tilePool)
        {
            _tilePool = tilePool;
        }
        
        public void Setup(Hand hand)
        {
            _hand = hand;
            _hand.OnSorted += Hand_OnSorted;
            
            _tileViews = new List<TileView>();

            Vector3 tileScale = _gridLayout.GridSize;
            
            for (int i = 0; i < _hand.Count; i++)
            {
                TileView tileView = _tilePool.Spawn();
                tileView.transform.position = _gridLayout.GetChildPosition(i);
                tileView.transform.localScale = new Vector3(tileScale.x / tileView.GetSize().x, tileScale.x / tileView.GetSize().x, 1f);
                tileView.transform.SetParent(transform);
                tileView.Setup(_hand.ElementAt(i));
                tileView.PlayAnimation(Vector2.zero, tileView.transform.position, i * 0.1f, 1f);
                
                _tileViews.Add(tileView);
            }
            
            gameObject.SetActive(true);
        }

        public void Clear()
        {
            _hand.OnSorted -= Hand_OnSorted;
            
            for (int i = 0; i < _tileViews.Count; i++)
            {
                _tilePool.Despawn(_tileViews[i]);
            }
            _tileViews.Clear();
        }
        
        public void PlayDistributeAnimation()
        {
            
        }
        
        private void Hand_OnSorted(IList<TileGroup> groups)
        {
            for (int i = 0; i < groups.Count; i++)
            {
//                groups[i].TileIds
            }
        }
        
        public class Pool : MonoMemoryPool<HandView>
        {
            public const int Size = 1;
            public const string GroupName = "Pool-HandView";
        }
    }
}