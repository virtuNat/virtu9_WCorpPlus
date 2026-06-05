using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PriorityScripts
{
    internal class DiceCardPriority_virtu9_WCorpPlus_DimRift : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            int priority = _BASE_PRIO;

            if (owner.GetBuffStack(KeywordBuf.WarpCharge) > _MAX_CHARGE)
                priority += _CHARGE_PRIO;

            return priority;
        }

        
        private const int _BASE_PRIO = 1;
        private const int _MAX_CHARGE = 4;
        private const int _CHARGE_PRIO = -2;
    }
}
