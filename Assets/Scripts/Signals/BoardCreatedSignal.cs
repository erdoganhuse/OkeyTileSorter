using Core.Data.Board;

namespace Signals
{
    public class BoardCreatedSignal
    {
        public readonly Tile OkeyTile;

        public BoardCreatedSignal(Tile okeyTile)
        {
            OkeyTile = okeyTile;
        }
    }
}