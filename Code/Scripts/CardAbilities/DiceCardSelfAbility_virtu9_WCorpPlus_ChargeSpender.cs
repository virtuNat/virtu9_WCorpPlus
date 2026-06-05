namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "WarpCharge"
        };

        public virtual int ChargeSpent => _chargeSpent;


        protected int _chargeSpent;
    }
}
