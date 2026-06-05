using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PriorityScripts
{
    internal class DiceCardPriority_virtu9_WCorpPlus_Shred : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            int chargeStack = owner.GetBuffStack(KeywordBuf.WarpCharge);
            return chargeStack < 5 ? _BASE_PRIO : chargeStack - _MIN_CHARGE;
        }


        private const int _BASE_PRIO = -100;
        private const int _MIN_CHARGE = 5;
    }
}
