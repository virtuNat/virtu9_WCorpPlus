using System;
using virtu9WCorpPlus.CardAbilities;

namespace virtu9WCorpPlus.DiceAbilities
{
    internal class DiceCardAbility_virtu9_WCorpPlus_RipSpace_1 : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "DrawCard_Keyword",
            "WarpCharge"
        };


        public override void OnSucceedAttack()
        {
            DiceCardSelfAbilityBase ability = behavior?.card?.cardAbility;
            if (!(ability is DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender chargeSpenderAbility) 
                || chargeSpenderAbility.ChargeSpent < _CHARGE_PER_DRAW
                )
                return;
            int val = chargeSpenderAbility.ChargeSpent / _CHARGE_PER_DRAW;
            owner.allyCardDetail.DrawCards(Math.Min(val, _MAX_DRAW));
        }

        
        private const int _CHARGE_PER_DRAW = 5;
        private const int _MAX_DRAW = 2;
    }
}
