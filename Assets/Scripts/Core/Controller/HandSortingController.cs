using System;
using System.Collections.Generic;
using Core.Data;
using Core.Data.Board;
using Core.Logic.HandSortStrategy;

namespace Core.Controller
{
    public class HandSortingController
    {
        private readonly Dictionary<Type, IHandSorter> _handSorters;
        
        public HandSortingController()
        {
            _handSorters = new Dictionary<Type, IHandSorter>()
            {
                {typeof(OneTwoThreeSorter), new OneTwoThreeSorter()},
                {typeof(SevenSevenSevenSorter), new SevenSevenSevenSorter()},
                {typeof(SmartSorter), new SmartSorter()}
            };
        }
        
        ~HandSortingController(){}

        public void Sort<T>(Hand hand, ref IList<TileGroup> groups) where T : IHandSorter
        {            
            _handSorters[typeof(T)].Sort(hand, ref groups);
        }
    }
}