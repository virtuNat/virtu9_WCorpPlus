using System;
using virtu9CommonLORUtil.Extensions;

namespace virtu9WCorpPlus.CardAbilities
{
    internal class DiceCardSelfAbility_virtu9_WCorpPlus_Shred : DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender
    {
        public override void OnUseCard()
        {
            int dmgRate = 0;
            BattleUnitModel target = card.target;
            int slotID = card.targetSlotOrder;
            if (target != null
                && 0 <= slotID && slotID < target.speedDiceCount
                && card.speedDiceResultValue - target.speedDiceResult[slotID].value >= _MIN_SPEED_DIFF
                )
                dmgRate = _DMG_RATE;

            int power = 0;
            BattleUnitBuf_warpCharge charge = owner.GetBuff<BattleUnitBuf_warpCharge>();
            if (charge != null && charge.stack >= _MIN_CHARGE)
            {
                if (charge.stack < _MAX_CHARGE)
                {
                    if (charge.stack == _MIN_CHARGE)
                        owner.UnitData.historyInUnit.spaceCutFail = 1;

                    int selfDmg = (int)Math.Round((_MAX_HP_SCALE - charge.stack) * _HP_SCALE * owner.MaxHp);
                    owner.TakeDamage(Math.Max(_MIN_SELF_DMG, selfDmg), DamageType.Card_Ability, owner, 0);
                    owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Stun, 1, owner);
                    FilterUtil.ShowWarpBloodFilter();
                }
                _chargeSpent = charge.stack;
                charge.UseStack(charge.stack, true);
                power = _POWER_UP;
            }
            if (dmgRate <= 0 && power <= 0)
                return;

            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                dmgRate = dmgRate,
                power = power
            });
        }


        private const int _MIN_SPEED_DIFF = 3;
        private const int _DMG_RATE = 25;
        private const int _MIN_CHARGE = 5;
        private const int _MAX_CHARGE = 10;
        private const int _MAX_HP_SCALE = 20;
        private const double _HP_SCALE = 0.01d;
        private const int _MIN_SELF_DMG = 5;
        private const int _POWER_UP = 8;
    }
}
