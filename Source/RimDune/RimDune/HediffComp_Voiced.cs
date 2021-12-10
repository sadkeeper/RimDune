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
    public class HediffComp_Voiced : HediffComp
    {
        public Thing parent;
        private int voicedTicksLeft = 0;
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

        public HediffComp_Voiced(Thing parent)
        {
            this.parent = parent;
        }


        public void VoicedHandlerTick()
        {
            Pawn pawn = this.parent as Pawn;
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
            else if (this.voicedTicksLeft == 0)
            {
                this.Target.SetFaction(originalFaction);
            }
        }

    }


}
