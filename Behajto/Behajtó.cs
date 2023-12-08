using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behajto
{
    class Behajtó<T> where T : ITartozás
    {
        public delegate void BehajtásFigyelő(string ügyfél, int behajtásÖsszeg);

        public event BehajtásFigyelő BehajtásEsemény;

        private ListaElem<T> fej;
        private int maxTartozásPerFő;

        public Behajtó(int maxTartozásPerFő)
        {
            this.maxTartozásPerFő = maxTartozásPerFő;
        }

        public void Megbízás(T elem)
        {
            var újElem = new ListaElem<T>(elem);
            var aktuális = fej;
            ListaElem<T> előző = null;

            while (aktuális != null && aktuális.Elem.Összeg < elem.Összeg)
            {
                előző = aktuális;
                aktuális = aktuális.Következő;
            }

            if (előző == null)
            {
                újElem.Következő = fej;
                fej = újElem;
            }
            else
            {
                újElem.Következő = aktuális;
                előző.Következő = újElem;
            }

            if (TartozásokÖsszege(elem.Ügyfél) > maxTartozásPerFő)
            {
                fej = előző?.Következő; // Töröljük a hozzáadott elemet
                throw new TúlSokTartozásException(elem);
            }
        }

        public void Bevetés(int bevételcél)
        {
            var aktuális = fej;

            while (aktuális != null && bevételcél > 0)
            {
                bool sikeresBehajtás = aktuális.Elem.Behajtás();

                OnBehajtásEsemény(aktuális.Elem.Ügyfél, sikeresBehajtás ? aktuális.Elem.Összeg : 0);

                if (sikeresBehajtás)
                {
                    bevételcél -= aktuális.Elem.Összeg;
                    ListaElem<T> töröltElem = aktuális;
                    aktuális = aktuális.Következő;
                    Töröl(töröltElem);
                }
                else
                {
                    aktuális = aktuális.Következő;
                }
            }
        }

        private void Töröl(ListaElem<T> elem)
        {
            if (elem == fej)
            {
                fej = elem.Következő;
            }
            else
            {
                var aktuális = fej;
                ListaElem<T> előző = null;

                while (aktuális != elem)
                {
                    előző = aktuális;
                    aktuális = aktuális.Következő;
                }

                előző.Következő = elem.Következő;
            }
        }

        private int TartozásokÖsszege(string ügyfél)
        {
            var aktuális = fej;
            int összeg = 0;

            while (aktuális != null && aktuális.Elem.Ügyfél == ügyfél)
            {
                összeg += aktuális.Elem.Összeg;
                aktuális = aktuális.Következő;
            }

            return összeg;
        }

        private void OnBehajtásEsemény(string ügyfél, int behajtásÖsszeg)
        {
            BehajtásEsemény?.Invoke(ügyfél, behajtásÖsszeg);
        }
    }
}
