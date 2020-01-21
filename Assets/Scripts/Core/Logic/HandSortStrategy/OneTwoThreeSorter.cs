using System;
using System.Collections.Generic;
using Core.Data;
using Core.Data.Board;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Core.Logic.HandSortStrategy
{
    public class OneTwoThreeSorter : IHandSorter
    {
        private NativeArray<TileGroup> _groups;
        
        public void Sort(Hand hand, ref IList<TileGroup> groups)
        {
            Tile[] handTiles = new Tile[hand.Count];
            for (int i = 0; i < handTiles.Length; i++)
            {
                handTiles[i] = hand.ElementAt(i);
            }
            
            Array.Sort(handTiles, (tileA, tileB) => tileA.Number.CompareTo(tileB.Number));

            List<int> groupedTileIds = new List<int>();
            for (int i = 0; i < handTiles.Length; i++)
            {
                if (groupedTileIds.Count == 0)
                {
                    groupedTileIds.Add(handTiles[i].Id);
                }
                else if(handTiles[i - 1].Number == handTiles[i].Number)
                {
                    
                }
                else if(handTiles[i - 1].Number + 1 == handTiles[i].Number)
                {
                    groupedTileIds.Add(handTiles[i].Id);
                }
                else
                {
                    if (groupedTileIds.Count > 3) groups.Add(new TileGroup(groupedTileIds));
                    
                    groupedTileIds.Clear();
                }
            }
        }
    }
}