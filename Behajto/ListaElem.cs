using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behajto
{
    class ListaElem<T>
    {
        public T Elem { get; set; }
        public ListaElem<T> Következő { get; set; }

        public ListaElem(T elem)
        {
            Elem = elem;
            Következő = null;
        }
    }
}
