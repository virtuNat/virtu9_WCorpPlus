using System;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_Ripple : DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender
    {
        public override void OnUseCard()
        {
            var charge = owner.GetBuff<BattleUnitBuf_warpCharge>();
            if (charge == null || charge.stack <= 0)
                return;

            int chargeSpent = Math.Min(charge.stack, _MAX_CHARGE);
            if (!charge.UseStack(chargeSpent, true))
                return;

            _chargeSpent = chargeSpent;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = chargeSpent
            });
        }

        
        private const int _MAX_CHARGE = 3;
    }
}
