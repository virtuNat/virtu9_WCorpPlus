using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_EnergyCycle : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "Energy_Keyword",
            "WarpCharge"
        };

        
        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPoint(_LIGHT_COUNT);

            if (owner.GetBuffStack(KeywordBuf.WarpCharge) > _MAX_CHARGE)
                return;

            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, _CHARGE_STACK, owner);
        }

        
        private const int _LIGHT_COUNT = 1;
        private const int _MAX_CHARGE = 4;
        private const int _CHARGE_STACK = 2;
    }
}
