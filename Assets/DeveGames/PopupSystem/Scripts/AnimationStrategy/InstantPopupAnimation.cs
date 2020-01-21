using System;
using DeveGames.Extensions;
using DG.Tweening;

namespace DeveGames.PopupSystem.Scripts.AnimationStrategy
{
    public class InstantPopupAnimation : IAnimationStrategy
    {
        public void PerformOpenAnimation(Popup popup, Action onOpenAnimationEnded = null)
        {
            onOpenAnimationEnded.SafeInvoke();
        }
    
        public void PerformCloseAnimation(Popup popup, Action onCloseAnimationEnded = null)
        {
            onCloseAnimationEnded.SafeInvoke();
        }
    }
}