using System.Collections.Generic;
using LOR_DiceSystem;
using virtu9WCorpPlus.CardAbilities;
using static RencounterManager;

namespace virtu9WCorpPlus.BehaviorActions
{
    internal class BehaviourAction_virtu9_WCorpPlus_Ripping : BehaviourActionBase
    {
        public override List<MovingAction> GetMovingAction(ref ActionAfterBehaviour self, ref ActionAfterBehaviour opponent)
        {
            List<MovingAction> action = base.GetMovingAction(ref self, ref opponent);
            BattleCardBehaviourResult behaviorResult = self.behaviourResultData;

            DiceCardSelfAbilityBase ability = null;
            if (behaviorResult != null)
                ability = behaviorResult.playingCard?.cardAbility;
            if (!(ability is DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender chargeSpenderAbility))
                return action;

            int chargeSpent = chargeSpenderAbility.ChargeSpent;
            DiceBehaviour behavior = behaviorResult.behaviourRawData;
            if (chargeSpent <= 4)
                behavior.EffectRes = "WarpCrew_S1";
            else if (chargeSpent <= 9)
                behavior.EffectRes = "WarpCrew_S2";
            else
                behavior.EffectRes = "WarpCrew_S3";

            return action;
        }
    }
}
