using virtu9CommonLORUtil.Buffs;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_ChargeVuln : PassiveAbilityBase
    {
        public override void OnCreated()
        {
            _hasSpentCharge = false;
        }

        public override void OnWaveStart()
        {
            _hasSpentCharge = false;
        }

        public override void OnRoundStart()
        {
            _canInflictVuln = _hasSpentCharge;
        }

        public override void OnUseChargeStack()
        {
            _hasSpentCharge = true;
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (!_canInflictVuln)
                return;

            BattleUnitModel target = behavior?.card?.target;
            if (target == null)
                return;

            var cooldown = target.GetBuff<BattleUnitBuf_WCorpPlus_ChargeVuln_Cooldown>();
            if (cooldown?.source != owner)
            {
                target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Vulnerable, _VULN_STACK, owner);
                target.AddBuff<BattleUnitBuf_WCorpPlus_ChargeVuln_Cooldown>(1, owner);
                owner.battleCardResultLog?.SetPassiveAbility(this);
                return;
            }
        }


        private bool _hasSpentCharge;
        private bool _canInflictVuln;

        private const int _VULN_STACK = 1;

        
        private class BattleUnitBuf_WCorpPlus_ChargeVuln_Cooldown : BattleUnitBuf_GenericTempEffectBase
        {
            public BattleUnitBuf_WCorpPlus_ChargeVuln_Cooldown(BattleUnitModel s) : base(1)
            {
                source = s;
            }

            public readonly BattleUnitModel source;
        }
    }
}
