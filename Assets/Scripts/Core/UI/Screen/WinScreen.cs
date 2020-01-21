using DeveGames.PopupSystem.Scripts;
using DeveGames.PopupSystem.Scripts.AnimationStrategy;
using UnityEngine;
using Zenject;

namespace Core.UI.Screen
{
    [RequireComponent(typeof(ZenAutoInjecter))]
    public class WinScreen : Popup<WinScreen>
    {
        private void Awake() => SetAnimationStrategy(new SubtleAnimationStrategy());
    }
}