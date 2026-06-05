using System;

namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_Leap : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "DrawCard_Keyword",
            "WarpCharge"
        };

        
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(_DRAW_COUNT);

            int cards = owner.allyCardDetail.GetHand().Count;
            if (cards < 2)
                return;

            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, Math.Min(cards / _CARDS_PER_CHARGE, _MAX_CHARGE), owner);
        }

        
        private const int _DRAW_COUNT = 1;
        private const int _CARDS_PER_CHARGE = 2;
        private const int _MAX_CHARGE = 3;
    }
}
