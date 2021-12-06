using System;
using Verse;
using RimWorld;
using UnityEngine;
using AbilityUser;
using JecsTools;

namespace RimDune
{
    [DefOf]
    public class DuneDefOf
    {
        public static AbilityUser.AbilityDef rd_theVoice;
    }

    public class VoiceHediff : HediffWithComps
    {

        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostRemoved();
            var comp = pawn.TryGetComp<CompAbilityUser>();

            if (comp == null)
            {
                return;
            }

            var abilityDef = DuneDefOf.rd_theVoice;
            comp.AddPawnAbility(abilityDef);
            Log.Message("Added");
        }
        public override void PostRemoved()
        {
            base.PostRemoved();
            var comp = pawn.TryGetComp<CompAbilityUser>();

            if (comp == null)
            {
                return;
            }

            var abilityDef = DuneDefOf.rd_theVoice;
            comp.RemovePawnAbility(abilityDef);
            Log.Message("removed");
        }
    }



    public class TheVoice : Projectile_AbilityLaser
    {
        public int TicksToImpact => ticksToImpact;

        public Vector3 ProjectileDrawPos
        {
            get
            {
                if (selectedTarget != null)
                    return selectedTarget.DrawPos;
                if (targetVec != null)
                    return targetVec;
                return ExactPosition;
            }
        }
        public override void Impact_Override(Thing hitThing)
        {
            base.Impact_Override(hitThing);
            if (hitThing != null)
            {
                var damageAmountBase = def.projectile.GetDamageAmount(1f);
                var equipmentDef = this.equipmentDef;
                var dinfo = new DamageInfo(def.projectile.damageDef, damageAmountBase, this.def.projectile.GetArmorPenetration(1f), ExactRotation.eulerAngles.y,
                    launcher, null, equipmentDef);
                hitThing.TakeDamage(dinfo);
                PostImpactEffects(hitThing);
            }
        }

        public virtual void PostImpactEffects(Thing hitThing)
        {
        }

        public virtual bool IsInIgnoreHediffList(Hediff hediff)
        {
            if (hediff != null)
                if (hediff.def != null)
                {
                    var compAbility = Caster.TryGetComp<CompAbilityUser>();
                    if (compAbility != null)
                        if (compAbility.IgnoredHediffs() != null)
                            if (compAbility.IgnoredHediffs().Contains(hediff.def))
                                return true;
                }

            return false;
        }
    }
}
