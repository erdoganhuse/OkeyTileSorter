using Core.Data.Board;

namespace Signals
{
    public class HandCreatedSignal
    {
        public readonly Hand Hand;

        public HandCreatedSignal(Hand hand)
        {
            Hand = hand;
        }
    }
}