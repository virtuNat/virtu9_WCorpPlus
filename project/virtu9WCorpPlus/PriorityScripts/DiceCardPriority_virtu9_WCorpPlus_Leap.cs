using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PriorityScripts
{
    internal class DiceCardPriority_virtu9_WCorpPlus_Leap : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            int priority = _BASE_PRIO;

            int hand = owner.allyCardDetail.GetHand().Count;
            if (hand <= _MIN_HAND)
                priority += _DRAW_PRIO;
            
            else if (hand >= _MAX_HAND && owner.GetBuffStack(KeywordBuf.WarpCharge) <= _MAX_CHARGE)
                priority += _CHARGE_PRIO;
            
            return priority;
        }

        
        private const int _BASE_PRIO = -1;
        private const int _MIN_HAND = 1;
        private const int _MAX_HAND = 5;
        private const int _DRAW_PRIO = 2;
        private const int _MAX_CHARGE = 3;
        private const int _CHARGE_PRIO = 2;
    }
}
