using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Helper.Layout
{
    public class WorldGridLayout : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private int _columnCount;
        [SerializeField] private int _rowCount;
        [SerializeField] private Vector2 _spacing;
        [SerializeField] private float _leftPadding;
        [SerializeField] private float _rightPadding;
        [SerializeField] private float _topPadding;
        [SerializeField] private float _bottomPadding;

        public Vector2 Size => _background.size * _background.transform.localScale.x;
        
        private Vector3? _gridSize;
        public Vector3 GridSize
        {
            get
            {
                if (_gridSize == null) _gridSize = GetGridSize();
                return _gridSize.Value;
            }
        }
        
        public Vector3 GetGridSize()
        {
            float scaleX = (Size.x - _leftPadding - _rightPadding - _spacing.x * (_columnCount - 1)) / _columnCount;
            float scaleY = (Size.y - _topPadding - _bottomPadding - _spacing.y * (_rowCount - 1)) / _rowCount;
            
            return new Vector3(scaleX, scaleY, 1f);
        }
        
        public Vector2 GetChildPosition(int childIndex)
        {
            Vector2 upperLeftPosition = GetPosition(Anchor.UpperLeft);
            
            int columnIndex = childIndex % _columnCount;
            int rowIndex = (childIndex / _columnCount);
                
            float posX = upperLeftPosition.x + _leftPadding + GridSize.x * ((2 * columnIndex + 1) / 2f) + _spacing.x * (columnIndex + 1);
            float posY = upperLeftPosition.y - _topPadding - GridSize.y * ((2 * rowIndex + 1) / 2f) - _spacing.y * (rowIndex + 1);
            
            return new Vector2(posX, posY);
        }
        
        public Vector2 GetPosition(Anchor anchor)
        {
            switch (anchor)
            {
                case Anchor.LowerCenter:
                    return (Vector2)(transform.position) + new Vector2(0f, -Size.y / 2f);
                case Anchor.LowerLeft:
                    return (Vector2)(transform.position) + new Vector2(-Size.x / 2f, -Size.y / 2f);
                case Anchor.LowerRight:
                    return (Vector2)(transform.position) + new Vector2(Size.x / 2f, -Size.y / 2f);
                case Anchor.MiddleCenter:
                    return (Vector2)(transform.position);
                case Anchor.MiddleLeft:
                    return (Vector2)(transform.position) + new Vector2(-Size.x / 2f, 0f);
                case Anchor.MiddleRight:
                    return (Vector2)(transform.position) + new Vector2(Size.x / 2f, 0f);
                case Anchor.UpperCenter:
                    return (Vector2)(transform.position) + new Vector2(0f, Size.y / 2f);
                case Anchor.UpperLeft:
                    return (Vector2)(transform.position) + new Vector2(-Size.x / 2f, Size.y / 2f);
                case Anchor.UpperRight:
                    return (Vector2)(transform.position) + new Vector2(Size.x / 2f, Size.y / 2f);
                    
                default:
                    return (Vector2)(transform.position);
            }
        }
    }
    
    public enum Anchor
    {
        UpperLeft,
        UpperCenter,
        UpperRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        LowerLeft,
        LowerCenter,
        LowerRight,
    }
}