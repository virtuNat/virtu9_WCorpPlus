using System.Collections.Generic;
using System.Linq;
using TwistRand;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_ChargeBuff : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if (owner.GetBuffStack(KeywordBuf.WarpCharge) < _MIN_CHARGE)
                return;

            IEnumerable<BattleUnitModel> allies = owner.GetOtherAliveAllies(null);
            if (!allies.Any())
                return;

            IEnumerable<BattleUnitModel> targets = allies.Where(u => _ROSE_IDS.Contains(u.Book.BookId));
            if (targets.Any())
            {
                targets.ChooseOne()?.bufListDetail.AddKeywordBufThisRoundByEtc(_BUF_TYPES.ChooseOne(), _BUFF_STACK, owner);
                return;
            }
            allies.ChooseOne()?.bufListDetail.AddKeywordBufThisRoundByEtc(_BUF_TYPES.ChooseOne(), _BUFF_STACK, owner);
            return;
        }


        private static readonly LorId[] _ROSE_IDS = new LorId[]
        {
            new LorId(140019),
            new LorId(240019),
            new LorId(ModMetaInfo.packageId, 4),
            new LorId(ModMetaInfo.packageId, 8)
        };

        private static readonly KeywordBuf[] _BUF_TYPES = new KeywordBuf[]
        {
            KeywordBuf.Strength, KeywordBuf.Endurance
        };

        private const int _MIN_CHARGE = 6;
        private const int _BUFF_STACK = 1;
    }
}
