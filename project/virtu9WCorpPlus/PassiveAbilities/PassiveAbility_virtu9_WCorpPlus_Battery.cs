namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_Battery : PassiveAbilityBase
    {
        public override void OnCreated()
        {
            _procCount = 0;
        }

        public override void OnRoundStart()
        {
            _procCount = 0;
        }

        public override void OnUseChargeStack()
        {
            if (_procCount++ >= _MAX_PROCS)
                return;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.WarpCharge, _CHARGE_STACK, owner);
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }


        private int _procCount;

        private const int _MAX_PROCS = 3;
        private const int _CHARGE_STACK = 1;
    }
}
