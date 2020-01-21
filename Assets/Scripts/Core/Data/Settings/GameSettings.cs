using System.Collections.Generic;
using Core.Data.Board;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Data.Settings
{
    public static class GameSettings
    {
        public const int TileCountInHand = 14;

        public static IReadOnlyDictionary<TileType, Color> TileColors { get; } = new Dictionary<TileType, Color>
        {
            {TileType.Red, new Color(1f, 0.32f, 0.23f)},
            {TileType.Blue, new Color(0.26f, 0.21f, 1f)},
            {TileType.Black, Color.black},
            {TileType.Yellow, new Color(1f, 0.74f, 0.13f)}
        };
    }
}