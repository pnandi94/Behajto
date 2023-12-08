using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behajto
{
    interface ITartozás
    {
        int Összeg { get; }
        string Ügyfél { get; }
        bool Behajtás();
    }
}
