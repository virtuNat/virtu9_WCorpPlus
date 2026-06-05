using TwistRand;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_ChargeQuick : PassiveAbilityBase
    {
        public PassiveAbility_virtu9_WCorpPlus_ChargeQuick()
        {
            _roller = new PseudoRNG(_HASTE_CHANCE);
        }

        public override void OnCreated()
        {
            _hasteGained = 0;
        }

        public override void OnRoundStart()
        {
            _hasteGained = 0;
        }

        public override void OnGainChargeStack()
        {
            RollHaste();
        }

        public override void OnUseChargeStack()
        {
            RollHaste();
        }

        private void RollHaste()
        {
            if (_hasteGained >= _MAX_HASTE || !_roller.Roll())
                return;

            _hasteGained++;
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, _HASTE_STACK, owner);
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }


        private readonly PseudoRNG _roller;
        private int _hasteGained;

        private const float _HASTE_CHANCE = 0.4f;
        private const int _MAX_HASTE = 2;
        private const int _HASTE_STACK = 1;
    }
}
