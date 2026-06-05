using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PriorityScripts
{
    internal class DiceCardPriority_virtu9_WCorpPlus_RipSpace : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            return owner.GetBuffStack(KeywordBuf.WarpCharge) < _MIN_CHARGE ? _BASE_PRIO : _CHARGE_PRIO;
        }


        private const int _BASE_PRIO = -100;
        private const int _MIN_CHARGE = 10;
        private const int _CHARGE_PRIO = 5;
    }
}
