using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_OverchargeDamage : PassiveAbilityBase
    {
        public override void OnCreated()
        {
            _triggers = 0;
        }

        public override void OnRoundStart()
        {
            _triggers = 0;
        }

        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            if (_triggers >= _MAX_TRIGGERS
                || (owner.turnState != BattleUnitTurnState.BREAK
                    && !owner.HasBuff(KeywordBuf.Stun)
                    && owner.GetBuffStack(KeywordBuf.WarpCharge) < _MIN_CHARGE
                    )
                )
                return;

            _triggers++;
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.DmgUp, 1, owner);
        }

        
        private int _triggers;

        private const int _MAX_TRIGGERS = 5;
        private const int _MIN_CHARGE = 10;
    }
}
