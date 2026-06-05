using System;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_RipSpace : DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender
    {
        public override void OnUseCard()
        {
            var charge = owner.GetBuff<BattleUnitBuf_warpCharge>() ?? new BattleUnitBuf_warpCharge();
            if (charge.UseStack(_MIN_CHARGE, true))
            {
                _chargeSpent = _MIN_CHARGE;
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = _MAX_POWER
                });
                return;
            }

            _chargeSpent = charge.stack;
            charge.UseStack(_chargeSpent, true);
            int selfDmg = (int)Math.Round((10 - _chargeSpent) * _HP_SCALE * owner.MaxHp);
            owner.TakeDamage(CustomMathExt.Clamp(1, selfDmg, _MAX_SELF_DMG), DamageType.Card_Ability, owner);

            FilterUtil.ShowWarpBloodFilter();
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = _chargeSpent
            });
        }

        
        private const int _MIN_CHARGE = 10;
        private const int _MAX_POWER = 10;
        private const double _HP_SCALE = 0.01d;
        private const int _MAX_SELF_DMG = 20;
    }
}
