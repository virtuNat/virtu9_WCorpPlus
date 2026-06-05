using System.Collections.Generic;
using System.Linq;
using TwistRand;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.TargetSetters
{
    internal class EnemyUnitTargetSetter_virtu9_WCorpPlus_Agent : EnemyUnitTargetSetter
    {
        public override BattleUnitModel SelectTargetUnit(List<BattleUnitModel> candidates)
        {
            IEnumerable<BattleUnitModel> targets = candidates.ChooseWeighted(candidates.Select(u => (uint)u.aggroDetail.GetAggroScore()));
            if (targets.Any())
            {
                return Enumerable.First(targets);
            }
            targets = candidates.AllMaxBy(u => u.aggroDetail.GetAggroScore());
            if (targets.Any())
            {
                return targets.ChooseOne();
            }
            return candidates.ChooseOne();
        }
    }
}
