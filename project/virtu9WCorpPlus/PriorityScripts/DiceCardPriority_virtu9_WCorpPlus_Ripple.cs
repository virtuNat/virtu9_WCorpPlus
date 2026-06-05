using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PriorityScripts
{
    internal class DiceCardPriority_virtu9_WCorpPlus_Ripple : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            int priority = _BASE_PRIO;
            int chargeStack = owner.GetBuffStack(KeywordBuf.WarpCharge);

            if (_MIN_CHARGE <= chargeStack)
                priority += _CHARGE_PRIO;
            
            if (_MAX_CHARGE <= chargeStack && chargeStack <= _OVERCHARGE)
                priority += _MID_CHARGE_PRIO;
            
            return priority;
        }

        
        private const int _BASE_PRIO = -2;
        private const int _MIN_CHARGE = 1;
        private const int _MAX_CHARGE = 3;
        private const int _OVERCHARGE = 6;
        private const int _CHARGE_PRIO = 2;
        private const int _MID_CHARGE_PRIO = 2;
    }
}
