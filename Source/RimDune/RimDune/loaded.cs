using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;


namespace RimDune
{
    [StaticConstructorOnStartup]
    public static class Loaded
    {
        static Loaded()
        {
            Log.Message("RimDune is loaded");
        }
    }
}
