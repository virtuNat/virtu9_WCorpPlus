using System;
using System.Collections.Generic;

namespace virtu9WCorpPlus.AggroSetter
{
    internal class EnemyUnitAggroSetter_virtu9_WCorpPlus : EnemyUnitAggroSetter
    {
        public override void OnRoundStart(List<BattleUnitModel> playerUnits)
        {
            foreach (BattleUnitModel unit in playerUnits)
            {
                int aggro = (int)Math.Round(_HP_MULT * (1 - unit.hp / unit.MaxHp));
                aggro += _DEBUFF_MULT * unit.bufListDetail.GetNegativeBufTypeCount();
                if (unit.IsBreakLifeZero() || unit.turnState == BattleUnitTurnState.BREAK)
                {
                    aggro += _BREAK_SCORE;
                }
                unit.aggroDetail.AddRoundScore(aggro);
            }
        }

        private const int _HP_MULT = 10;
        private const int _DEBUFF_MULT = 3;
        private const int _BREAK_SCORE = 10;
    }
}
