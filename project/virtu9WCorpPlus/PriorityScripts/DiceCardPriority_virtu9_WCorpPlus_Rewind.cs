using virtu9CommonLORUtil.Extensions;
using static virtu9WCorpPlus.CardAbilities.DiceCardSelfAbility_virtu9_WCorpPlus_Rewind;

namespace virtu9WCorpPlus.PriorityScripts
{
    internal class DiceCardPriority_virtu9_WCorpPlus_Rewind : DiceCardPriorityBase
    {
        public override int GetPriorityBonus(BattleUnitModel owner)
        {
            if (owner.HasBuff<BattleUnitBuf_WCorpPlus_Rewind_Heal_Block>())
                return _BASE_PRIO;

            int priority = _BASE_PRIO;

            if (owner.MaxHp - owner.hp >= _MIN_DMG)
                priority += _HEAL_PRIO;
            
            if (owner.GetBuffStack(KeywordBuf.WarpCharge) <= _MIN_CHARGE)
                priority += _HEAL_PRIO;
            
            return priority;
        }

        
        private const int _BASE_PRIO = -2;
        private const int _MIN_DMG = 9;
        private const int _MIN_CHARGE = 3;
        private const int _HEAL_PRIO = 2;
    }
}
