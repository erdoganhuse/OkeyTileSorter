using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Data.Board
{
    public struct Deck
    {
        public int Count => _tiles.Count;
        
        private readonly IList<Tile> _tiles;
        
        public Deck(IList<Tile> tiles)
        {
            _tiles = new List<Tile>();
            _tiles = tiles;
        }

        public void Push(Tile tile)
        {
            _tiles.Add(tile);
        }
        
        public Tile PopAt(int index)
        {
            Tile tile = _tiles[index];
            _tiles.RemoveAt(index);
            return tile;
        }
        
        public Tile PopRandom()
        {
            return PopAt(UnityEngine.Random.Range(0, Count));
        }

        public Tile GetRandom()
        {
            return _tiles[UnityEngine.Random.Range(0, Count)];
        }

        public void Clear()
        {
            _tiles.Clear();
        }

        public Deck Copy()
        {
            return new Deck(_tiles);
        }
        
        #region Overloads

        public Tile this[int index] => _tiles[index];

        public static Deck operator +(Deck deckA, Deck deckB)
        {
            return new Deck(deckA._tiles.Concat(deckB._tiles).ToList());
        }

        #endregion
        
        #region Statics

        public static Deck CreateFullDeck()
        {
            IList<Tile> tiles = new List<Tile>();

            for (int i = 0; i < 104; i++)
            {
                tiles.Add(new Tile(i, i % 13 + 1, (TileType)((i / 13) % 4)));
            }
            
            return new Deck(tiles);
        }

        #endregion
    }
}