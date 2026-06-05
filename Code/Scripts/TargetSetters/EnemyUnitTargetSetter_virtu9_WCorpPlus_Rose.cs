using System.Collections.Generic;
using System.Linq;
using TwistRand;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.TargetSetters
{
    internal class EnemyUnitTargetSetter_virtu9_WCorpPlus_Rose : EnemyUnitTargetSetter
    {
        public override BattleUnitModel SelectTargetUnit(List<BattleUnitModel> candidates)
        {
            IEnumerable<BattleUnitModel> targets = candidates.AllMinBy(u => u.speedDiceResult.Average(d => d.value));
            if (Enumerable.Any(targets))
            {
                return targets.ChooseOne();
            }
            return candidates.ChooseOne();
        }
    }
}
