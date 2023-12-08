using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behajto
{
    class SzemélyiHitel : ITartozás
    {
        public int Összeg { get; }
        public string Ügyfél { get; }

        public SzemélyiHitel(int összeg, string ügyfél)
        {
            Összeg = összeg;
            Ügyfél = ügyfél;
        }

        public virtual bool Behajtás()
        {
            if (BehajtóVagyon >= Összeg)
            {
                BehajtóVagyon -= Összeg;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int BehajtóVagyon = 1000; // Példa érték, a főprogramban inicializáld

        public override string ToString()
        {
            return $"Személyi hitel - Ügyfél: {Ügyfél}, Összeg: {Összeg}";
        }
    }
}
