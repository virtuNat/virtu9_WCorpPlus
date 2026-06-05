using System;
using virtu9CommonLORUtil.Buffs;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.PassiveAbilities
{
    internal class PassiveAbility_virtu9_WCorpPlus_CleanupOrder : PassiveAbilityBase
    {
        protected virtual int MinCharge => 5;

        protected virtual int MaxProcs => 2;

        protected virtual int MaxDmg => 4;


        public override void OnStartBattle()
        {
            foreach (BattleUnitModel unit in owner.GetAliveAllies())
            {
                if (unit.GetBuffStack(KeywordBuf.WarpCharge) >= MinCharge)
                {
                    unit.AddBuffWithoutDupe<BattleUnitBuf_virtu9_WCorpPlus_CleanupBuff>(0, this);
                }
            }
        }


        private class BattleUnitBuf_virtu9_WCorpPlus_CleanupBuff : BattleUnitBuf_GenericTempEffectBase
        {
            public BattleUnitBuf_virtu9_WCorpPlus_CleanupBuff(PassiveAbility_virtu9_WCorpPlus_CleanupOrder p) : base(1)
            {
                _srcPassive = p;
                _procCount = 0;
            }

            public override void OnSuccessAttack(BattleDiceBehavior behavior)
            {
                if (_procCount >= _srcPassive.MaxProcs)
                    return;

                BattlePlayingCardDataInUnitModel card = behavior?.card;
                BattleUnitModel target = card?.target;
                if (target == null)
                    return;

                int slotID = card.targetSlotOrder;
                if (0 > slotID || slotID >= target.speedDiceCount)
                    return;

                int speedDiff = card.speedDiceResultValue - target.speedDiceResult[slotID].value;
                if (speedDiff <= 0)
                    return;

                _procCount++;
                target.TakeDamage(Math.Min(speedDiff, _srcPassive.MaxDmg), DamageType.Passive, _owner, 0);
                _owner.battleCardResultLog?.SetPassiveAbility(_srcPassive);
            }


            private readonly PassiveAbility_virtu9_WCorpPlus_CleanupOrder _srcPassive;

            private int _procCount;
        }
    }
}
