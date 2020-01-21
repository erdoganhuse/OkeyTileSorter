using System.Collections.Generic;
using Core.Data;
using Core.Data.Board;

namespace Core.Logic.HandSortStrategy
{
    public interface IHandSorter
    {
        void Sort(Hand hand, ref IList<TileGroup> groups);
    }
}