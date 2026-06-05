using System.Linq;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_CleanupOrderEnemy : PassiveAbility_virtu9_WCorpPlus_CleanupOrder
    {
        protected override int MaxProcs => 3;


        public override int OnAddKeywordBufByCard(BattleUnitBuf buf, int stack)
        {
            if (!owner.GetAliveAllies().Any() || owner.emotionDetail.EmotionLevel >= _MIN_EMOLVL)
            {
                owner.battleCardResultLog?.SetPassiveAbility(this);
                return _ADDED_CHARGE;
            }
            return 0;
        }


        private const int _MIN_EMOLVL = 2;
        private const int _ADDED_CHARGE = 1;
    }
}
