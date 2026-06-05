using System;
using virtu9CommonLORUtil.Buffs;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_Rewind : DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender
    {
        public override string[] Keywords => new string[]
        {
            "WarpCharge",
            "Recover_Keyword"
        };

        
        public override void OnUseCard()
        {
            if (owner.HasBuff<BattleUnitBuf_WCorpPlus_Rewind_Heal_Block>())
                return;

            var charge = owner.GetBuff<BattleUnitBuf_warpCharge>();
            if (charge == null || charge.stack <= 0)
                return;

            int chargeSpent = Math.Min(charge.stack, _MAX_CHARGE);
            if (!charge.UseStack(chargeSpent, true))
                return;

            _chargeSpent = chargeSpent;
            owner.RecoverHP(chargeSpent * _HEAL_PER_CHARGE);
            owner.AddBuffWithoutDupe<BattleUnitBuf_WCorpPlus_Rewind_Heal_Block>();
        }

        
        private const int _MAX_CHARGE = 3;
        private const int _HEAL_PER_CHARGE = 3;

        
        public class BattleUnitBuf_WCorpPlus_Rewind_Heal_Block : BattleUnitBuf_GenericTempEffectBase
        {
            public BattleUnitBuf_WCorpPlus_Rewind_Heal_Block() : base(1)
            {
            }
        }
    }
}
