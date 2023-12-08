using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behajto
{
    class TúlSokTartozásException : Exception
    {
        public ITartozás ProblémásTartozás { get; }

        public TúlSokTartozásException(ITartozás tartozás)
            : base($"Túl sok tartozás az ügyfélre: {tartozás.Ügyfél}")
        {
            ProblémásTartozás = tartozás;
        }
    }
}
