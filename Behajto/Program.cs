using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behajto
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Létrehozunk egy Behajtó objektumot, amely ITartozás típusú elemeket kezel
                Behajtó<ITartozás> behajtó = new Behajtó<ITartozás>(500);

                // Feliratkozunk a Behajtó eseményre
                behajtó.BehajtásEsemény += (ügyfél, összeg) =>
                {
                    if (összeg > 0)
                    {
                        Console.WriteLine($"Behajtás sikeres - Ügyfél: {ügyfél}, Összeg: {összeg}");
                    }
                    else
                    {
                        Console.WriteLine($"Behajtás sikertelen - Ügyfél: {ügyfél}");
                    }
                };

                // Hiteladatokat veszünk fel a Behajtóba
                behajtó.Megbízás(new SzemélyiHitel(200, "John Doe"));
                behajtó.Megbízás(new MaffiaHitel(500, "Don Corleone"));
                behajtó.Megbízás(new SzemélyiHitel(300, "Jane Doe"));

                // Végrehajtjuk a behajtást, amíg el nem érjük a 800-as bevételi célt
                behajtó.Bevetés(800);
            }
            catch (TúlSokTartozásException ex)
            {
                // Kezeljük a túl sok tartozás kivételt
                Console.WriteLine($"Hiba történt: {ex.Message}");
                Console.WriteLine($"Problémás tartozás: {ex.ProblémásTartozás}");
            }
            catch (Exception ex)
            {
                // Kezeljük egyéb kivételeket
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }
        }
    }
}