using System;
using TwistRand;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_DimSectionDmg : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            int stack = owner.GetBuffStack(KeywordBuf.WarpCharge);
            double prob = _BASE_PROB * Math.Pow(_PROB_UP, Math.Min(0, stack));

            if (Twister.StaticTwister.Chance(prob))
                return;

            BattleCardTotalResult resultLog = owner.battleCardResultLog;
            if (resultLog != null)
            {
                resultLog.SetSucceedAtkEvent(FilterUtil.ShowWarpFilter);
                resultLog.SetPassiveAbility(this);
            }
            behavior?.card?.target.TakeDamage(_DMG, DamageType.Passive, owner);
        }


        private const double _BASE_PROB = 0.9d;
        private const double _PROB_UP = 0.95d;
        private const int _DMG = 5;
    }
}
