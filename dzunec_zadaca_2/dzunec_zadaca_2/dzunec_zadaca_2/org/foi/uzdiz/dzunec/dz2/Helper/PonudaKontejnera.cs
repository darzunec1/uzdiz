using System;
using static org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Decorator.Decorator;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class PonudaKontejnera
    {
        public PonudaKontejnera()
        {
        }

        public static void Ponuda ()
        {
            Console.WriteLine("--------------------------------------------------): ");
            Console.WriteLine("Vlastita funkcionalnost (provjera cijene spremnika): ");
            KontejnerNabava kontejner = new KontejnerNabava();
            Console.WriteLine("Nabavna cijena kontejnera: " + kontejner.DajCijenu() + "kn");

            Jamstvo5God jamstvo = new Jamstvo5God(kontejner);
            Console.WriteLine("Cijena kontejnera s jamstvom od 5 godina iznosi: " + jamstvo.DajCijenu() + "kn");

            NoznoOtvaranje noznoOtvaranje = new NoznoOtvaranje(kontejner);
            Console.WriteLine("Cijena kontejnera s nožnim otvaranjem iznosi: " + noznoOtvaranje.DajCijenu() + "kn");

            SenzorOtvaranje senzorOtvaranje = new SenzorOtvaranje(kontejner);
            Console.WriteLine("Cijena kontejnera s otvaranjem na senzor iznosi: " + senzorOtvaranje.DajCijenu() + "kn");
        }
    }
}
