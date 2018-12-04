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
                IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisUvjetni("--------------------------------------------------): ");
                IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisUvjetni("Vlastita funkcionalnost (provjera cijene spremnika): ");
                KontejnerNabava kontejner = new KontejnerNabava();
                IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisUvjetni("Nabavna cijena kontejnera: " + kontejner.DajCijenu() + "kn");

                Jamstvo5God jamstvo = new Jamstvo5God(kontejner);
                IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisUvjetni("Cijena kontejnera s jamstvom od 5 godina iznosi: " + jamstvo.DajCijenu() + "kn");

                NoznoOtvaranje noznoOtvaranje = new NoznoOtvaranje(kontejner);
                IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisUvjetni("Cijena kontejnera s nožnim otvaranjem iznosi: " + noznoOtvaranje.DajCijenu() + "kn");

                SenzorOtvaranje senzorOtvaranje = new SenzorOtvaranje(kontejner);
                IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola.IspisUvjetni("Cijena kontejnera s otvaranjem na senzor iznosi: " + senzorOtvaranje.DajCijenu() + "kn");
        }

    }
}
