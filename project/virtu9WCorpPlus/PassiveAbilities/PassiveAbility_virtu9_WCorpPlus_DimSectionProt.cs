using System;
using TwistRand;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_DimSectionProt : PassiveAbilityBase
    {
        public override int GetDamageReduction(BattleDiceBehavior behavior)
        {
            int stack = owner.GetBuffStack(KeywordBuf.WarpCharge);
            double prob = _BASE_PROB * Math.Pow(_PROB_UP, Math.Min(0, stack));

            if (!Twister.StaticTwister.Chance(prob))
            {
                return Twister.StaticTwister.Range(_MIN_PDMG_RED, _MAX_PDMG_RED);
            }
            return 0;
        }

        public override int GetBreakDamageReduction(BattleDiceBehavior behavior)
        {
            int stack = owner.GetBuffStack(KeywordBuf.WarpCharge);
            double prob = _BASE_PROB * Math.Pow(_PROB_UP, Math.Min(0, stack));

            if (!Twister.StaticTwister.Chance(prob))
            {
                return Twister.StaticTwister.Range(_MIN_BDMG_RED, _MAX_BDMG_RED);
            }
            return 0;
        }


        private const double _BASE_PROB = 0.9d;
        private const double _PROB_UP = 0.95d;
        private const int _MIN_PDMG_RED = 2;
        private const int _MAX_PDMG_RED = 3;
        private const int _MIN_BDMG_RED = 1;
        private const int _MAX_BDMG_RED = 2;
    }
}
