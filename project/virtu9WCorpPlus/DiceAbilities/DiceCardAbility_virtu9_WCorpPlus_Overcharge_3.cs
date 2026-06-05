using virtu9CommonLORUtil.Buffs;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.DiceAbilities
{
    internal class DiceCardAbility_virtu9_WCorpPlus_Overcharge_3 : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "WarpCharge",
            "Paralysis_Keyword"
        };

        
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target == null)
                return;
            int chargeStack = owner.GetBuffStack(KeywordBuf.WarpCharge);
            if (chargeStack < _MIN_CHARGE || chargeStack > _MAX_CHARGE
                || target.HasBuff<BattleUnitBuf_WCorpPlus_Overcharge_Cooldown_3>()
                )
                return;
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, _DEBUFF_STACK, owner);
        }

        
        private const int _MIN_CHARGE = 6;
        private const int _MAX_CHARGE = 10;
        private const int _DEBUFF_STACK = 2;

        
        private class BattleUnitBuf_WCorpPlus_Overcharge_Cooldown_3 : BattleUnitBuf_GenericTempEffectBase
        {
            public BattleUnitBuf_WCorpPlus_Overcharge_Cooldown_3() : base(1)
            {
            }
        }
    }
}
