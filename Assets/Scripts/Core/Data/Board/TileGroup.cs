using System.Collections.Generic;

namespace Core.Data.Board
{
    public struct TileGroup
    {
        public int Count => _tileIds.Count;
        
        private readonly List<int> _tileIds;

        public TileGroup(List<int> tileIds)
        {
            _tileIds = tileIds;
        }

        public int ElementAt(int index)
        {
            return _tileIds[index];
        }

        public void Add(int index)
        {
            _tileIds.Add(index);
        }

        public void Clear()
        {
            _tileIds.Clear();
        }
    }
}