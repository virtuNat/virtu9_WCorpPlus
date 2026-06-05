using System.Collections.Generic;
using System.Linq;
using TwistRand;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_UpLeap : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "WarpCharge",
            "Quickness_Keyword"
        };

        public override void OnUseCard()
        {
            var charge = owner.GetBuff<BattleUnitBuf_warpCharge>();
            if (charge == null || !charge.UseStack(_CHARGE_COST, true))
                return;

            IEnumerable<BattleUnitModel> allies = owner.GetAliveAllies(null);
            if (!allies.Any())
                return;

            foreach (BattleUnitModel ally in allies.SampleCombinations(_MAX_ALLIES, true))
            {
                ally.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, _HASTE_STACK, owner);
            }
        }


        private const int _CHARGE_COST = 3;
        private const int _MAX_ALLIES = 4;
        private const int _HASTE_STACK = 1;
    }
}
