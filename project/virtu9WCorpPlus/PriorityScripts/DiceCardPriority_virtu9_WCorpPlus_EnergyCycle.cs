using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PriorityScripts
{
    internal class DiceCardPriority_virtu9_WCorpPlus_EnergyCycle : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            int priority = _BASE_PRIO;

            if (owner.cardSlotDetail.PlayPoint <= _MIN_LIGHT)
                priority += _LIGHT_PRIO;

            if (owner.GetBuffStack(KeywordBuf.WarpCharge) <= _MIN_CHARGE)
                priority += _CHARGE_PRIO;

            return priority;
        }

        
        private const int _BASE_PRIO = -1;
        private const int _MIN_LIGHT = 1;
        private const int _LIGHT_PRIO = 3;
        private const int _MIN_CHARGE = 4;
        private const int _CHARGE_PRIO = 1;
    }
}
