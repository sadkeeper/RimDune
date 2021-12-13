using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;

namespace RimDune
{

    public class HediffCompProperties_Voiced : HediffCompProperties
    {
        public int voicedTicksLeft;
    }

    public class HediffComp_Voiced : HediffComp
    {
        public int voicedTicksLeft = 0;
        public Faction originalFaction;
        public Faction playerFaction;
        public Pawn Target = null;


        public bool Voiced
        {
            get 
            {
                return this.voicedTicksLeft > 0;
                
            }
        }

        private HediffCompProperties_Voiced Props
        {
            get
            {
                return (HediffCompProperties_Voiced)this.props;
            }
        }
        public virtual float VoicedChangePerDay()
        {
            return this.Props.voicedTicksLeft;
        }

        public void VoicedHandlerTick()
        {
            Pawn pawn = this.parent.pawn;
            this.originalFaction = pawn.Faction;
            this.playerFaction = Faction.OfPlayer;
            if (this.voicedTicksLeft > 0)
            {
                this.voicedTicksLeft--;
                this.Target.SetFaction(playerFaction);

                if (pawn != null)
                {
                    this.voicedTicksLeft = 0;
                }

            }
            else if (this.voicedTicksLeft <= 0)
            {
                this.Target.SetFaction(originalFaction);
            }
        }

    }


}
