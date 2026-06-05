using System;
using System.Collections.Generic;

namespace virtu9WCorpPlus.AggroSetter
{
    internal class EnemyUnitAggroSetter_virtu9_WCorpPlus : EnemyUnitAggroSetter
    {
        public override void OnRoundStart(List<BattleUnitModel> playerUnits)
        {
            foreach (BattleUnitModel battleUnitModel in playerUnits)
            {
                int aggro = (int)Math.Round(_HP_MULT * (1 - battleUnitModel.hp / battleUnitModel.MaxHp));
                aggro += _DEBUFF_MULT * battleUnitModel.bufListDetail.GetNegativeBufTypeCount();
                if (battleUnitModel.IsBreakLifeZero() || battleUnitModel.turnState == BattleUnitTurnState.BREAK)
                {
                    aggro += _BREAK_SCORE;
                }
                battleUnitModel.aggroDetail.AddRoundScore(aggro);
            }
        }

        private const int _HP_MULT = 10;
        private const int _DEBUFF_MULT = 3;
        private const int _BREAK_SCORE = 10;
    }
}
