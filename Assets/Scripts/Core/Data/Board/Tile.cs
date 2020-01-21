using UnityEngine;

namespace Core.Data.Board
{
    public struct Tile
    {
        public readonly int Id;
        public readonly int Number;
        public readonly TileType Type;

        public Tile(int id, int number, TileType type)
        {
            Id = id;
            Number = number;
            Type = type;
        }
        
        public static bool operator== (Tile tileA, Tile tileB)
        {
            return (tileA.Number == tileB.Number && tileA.Type == tileB.Type);
        }        
        
        public static bool operator!= (Tile tileA, Tile tileB)
        {
            return (tileA.Number != tileB.Number || tileA.Type != tileB.Type);
        }
    }

    public enum TileType
    {
        Red,
        Blue,
        Black,
        Yellow,
    }
}