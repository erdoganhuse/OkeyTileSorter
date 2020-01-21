using System;
using System.Collections.Generic;

namespace Core.Data.Board
{
    public class Hand
    {
        public event Action<IList<TileGroup>> OnSorted;
        
        public int Count => _tiles.Count;
        
        private readonly IList<Tile> _tiles;
        private IList<TileGroup> _groups;
        
        public Hand()
        {
            _tiles = new List<Tile>();
        }

        public Tile ElementAt(int index)
        {
            return _tiles[index];
        }
        
        public void Add(Tile tile)
        {
            _tiles.Add(tile);
        }

        public void Remove(int index)
        {
            
        }

        public void AssignSortedGroups(IList<TileGroup> groups)
        {
            _groups = groups;
            OnSorted?.Invoke(_groups);
        }
        
        public void Clear()
        {
            _tiles.Clear();
        }
    }
}