using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behajto
{
    class MaffiaHitel : SzemélyiHitel
    {
        public MaffiaHitel(int összeg, string ügyfél) : base(összeg, ügyfél)
        {
        }

        public override bool Behajtás()
        {
            return false;
        }
    }
}
