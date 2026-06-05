using virtu9WCorpPlus.CardAbilities;

namespace virtu9WCorpPlus.DiceAbilities
{
    internal class DiceCardAbility_virtu9_WCorpPlus_Ripple_2 : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "Binding_Keyword",
            "WarpCharge"
        };

        
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target == null)
                return;
            int stack = _BASE_BIND;
            BattleDiceBehavior behavior = this.behavior;
            DiceCardSelfAbilityBase ability = behavior?.card?.cardAbility;
            if (ability is DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender chargeSpenderAbility && chargeSpenderAbility.ChargeSpent > 0)
                stack += _ADDED_BIND;
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, stack, owner);
        }

        
        private const int _BASE_BIND = 1;
        private const int _ADDED_BIND = 1;
    }
}
