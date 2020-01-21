using Core.Data;
using Core.Data.Board;
using Core.Data.Settings;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Core.View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private TextMesh _numberText;
        [SerializeField] private SpriteRenderer _frontBg;

        public Vector2 GetSize()
        {
            return _frontBg.size * _frontBg.transform.localScale.x;
        }
        
        public void Setup(Tile tile)
        {
            _numberText.text = tile.Number.ToString();
            _numberText.color = GameSettings.TileColors[tile.Type];
            
            gameObject.SetActive(true);
        }

        public void Clear(){}
        
        public void PlayAnimation(Vector2 startPosition, Vector2 endPosition, float delay, float duration)
        {
            transform.position = startPosition;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

            transform.DORotate(Vector3.zero, duration).SetDelay(delay);
            transform.DOMove(endPosition, duration).SetDelay(delay);
        }
        
        public class Pool : MonoMemoryPool<TileView>
        {
            public const int Size = 13;
            public const string GroupName = "Pool-TileView";

            protected override void OnDespawned(TileView item)
            {
                base.OnDespawned(item);

                item.transform.localEulerAngles = Vector3.zero;
                item.transform.localScale = Vector3.one;
            }
        }
    }
}