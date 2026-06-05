using System;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_OverchargePower : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            if (owner.cardHistory.GetCurrentRoundCardList(StageController.Instance.RoundTurn).Count > 0)
                return;

            int buffStack = _BASE_STACK;
            int chargeStack = owner.GetBuffStack(KeywordBuf.WarpCharge);
            if (chargeStack >= 10)
                buffStack = Math.Min(buffStack + chargeStack / _CHARGE_PER_STACK, _MAX_STACK);

            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, buffStack, owner);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, buffStack, owner);
        }

        
        private const int _BASE_STACK = 1;
        private const int _CHARGE_PER_STACK = 10;
        private const int _MAX_STACK = 3;
    }
}
