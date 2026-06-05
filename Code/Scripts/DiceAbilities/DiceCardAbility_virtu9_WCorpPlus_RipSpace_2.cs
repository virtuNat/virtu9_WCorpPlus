using System.Collections;
using UnityEngine;
using virtu9WCorpPlus.CardAbilities;

namespace virtu9WCorpPlus.DiceAbilities
{
    internal class DiceCardAbility_virtu9_WCorpPlus_RipSpace_2 : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[]
        {
            "WarpCharge"
        };

        
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target == null)
                return;

            DiceCardSelfAbilityBase ability = behavior?.card?.cardAbility;
            if (!(ability is DiceCardSelfAbility_virtu9_WCorpPlus_ChargeSpender chargeSpenderAbility))
                return;

            target.TakeDamage(chargeSpenderAbility.ChargeSpent, DamageType.Card_Ability, owner);
            owner.battleCardResultLog?.SetSucceedAtkEvent(WarpEffect);
        }

        private void WarpEffect()
        {
            FilterUtil.ShowWarpFilter();
            var camManager = BattleCamManager.Instance;
            CameraFilterPack_FX_EarthQuake earthquakeFX = camManager?.EffectCam.gameObject.AddComponent<CameraFilterPack_FX_EarthQuake>() ?? null;
            if (earthquakeFX == null)
                return;

            earthquakeFX.StartCoroutine(WarpEQRoutine(earthquakeFX));
            AutoScriptDestruct autoDestruct = camManager?.EffectCam.gameObject.AddComponent<AutoScriptDestruct>() ?? null;
            if (autoDestruct == null)
                return;

            autoDestruct.targetScript = earthquakeFX;
            autoDestruct.time = 0.5f;
        }

        private IEnumerator WarpEQRoutine(CameraFilterPack_FX_EarthQuake effect)
        {
            float e = 0f;
            while (e < 1f)
            {
                e += Time.deltaTime * 2f;
                effect.Speed = 30f * (1f - e);
                effect.X = 0.02f * (1f - e);
                effect.Y = 0.02f * (1f - e);
                yield return null;
            }
            yield break;
        }
    }
}
