using System;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_ChargeHeal : PassiveAbilityBase
    {
        public override void OnCreated()
        {
            _triggered = false;
        }
        
        public override void OnRoundStart()
        {
            _triggered = false;
        }

        public override void OnGainChargeStack()
        {
            if (_triggered)
                return;

            int stack = owner.GetBuffStack(KeywordBuf.WarpCharge);
            if (stack < _CHARGE_PER_HEAL)
                return;

            _triggered = true;
            owner.RecoverHP(Math.Min(stack / _CHARGE_PER_HEAL, _MAX_HEAL));
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }


        private bool _triggered;

        private const int _CHARGE_PER_HEAL = 4;
        private const int _MAX_HEAL = 5;
    }
}
