using System;
using virtu9WCorpPlus.CardAbilities;

namespace virtu9WCorpPlus.DiceAbilities
{
    internal class DiceCardAbility_virtu9_WCorpPlus_Shred_1 : DiceCardAbilityBase
    {
        public DiceCardAbility_virtu9_WCorpPlus_Shred_1()
        {
            _procCount = 0;
        }

        //public override void OnDrawParrying()
        //{
        //    ActivateBonusAttackDice();
        //}

        //public override void OnLoseParrying()
        //{
        //    ActivateBonusAttackDice();
        //}

        public override void OnSucceedAttack()
        {
            DiceCardSelfAbilityBase ability = behavior?.card?.cardAbility;
            if (!(ability is DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender chargeSpenderAbility))
                return;

            int chargeSpent = chargeSpenderAbility.ChargeSpent;
            if (chargeSpent >= 5)
            {
                int procCount = _procCount;
                _procCount = procCount + 1;
                if (procCount < Math.Min(chargeSpent / _CHARGE_PER_PROC, _MAX_PROCS))
                {
                    ActivateBonusAttackDice();
                    return;
                }
            }
        }


        private int _procCount;

        private const int _CHARGE_PER_PROC = 5;
        private const int _MAX_PROCS = 2;
    }
}
