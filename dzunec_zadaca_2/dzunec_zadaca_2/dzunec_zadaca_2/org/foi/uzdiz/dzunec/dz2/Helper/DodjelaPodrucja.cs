using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper;
using static org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Composite.CompositePodrucja;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Ispis;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class DodjelaPodrucja
    {
        public DodjelaPodrucja()
        {
        }
        public static List<PodrucjeCom> listaCom = new List<PodrucjeCom>();
        public static List<UlicaPodrucja> listUlicaPod = new List<UlicaPodrucja>();

        public static void DodijeliPotpodrucja()
        {

            //postavljanje podpodrucja
            foreach (Podrucje podrucje in Citac.ListaPodrucja)
            {
                if (podrucje.Id.StartsWith('u'))
                {
                    Ulica ulica = Citac.ListaUlica.FirstOrDefault(p => p.Id == podrucje.Id);
                    UlicaPodrucja up = new UlicaPodrucja(podrucje.Id, podrucje.Naziv, ulica);
                    listUlicaPod.Add(up);
                }
                else
                {
                    PodrucjeCom podrucjeK = new PodrucjeCom(podrucje.Id, podrucje.Naziv);
                    listaCom.Add(podrucjeK);
                }

            }

            foreach (var podrucjeComposit in listaCom)
            {
                Podrucje podrucje = Citac.ListaPodrucja.FirstOrDefault(pod => pod.Id == podrucjeComposit.PodrucjeID);

                foreach (var dioPodrucjaId in podrucje.Dio)
                {
                    if (dioPodrucjaId.StartsWith('u'))
                    {
                        Ulica ulicaObjekt = new Ulica();
                        foreach (var ulica in Citac.ListaUlica)
                        {
                            if (ulica.Id == dioPodrucjaId)
                            {
                                ulicaObjekt = ulica;
                            }
                        }

                        UlicaPodrucja ulicaPodrucjaObjekt = new UlicaPodrucja(dioPodrucjaId, ulicaObjekt.Naziv, ulicaObjekt);
                        if (ulicaPodrucjaObjekt != null)
                        {
                            podrucjeComposit.Dodijeli(ulicaPodrucjaObjekt);
                        }


                    }
                    else
                    {

                        PodrucjeCom podrucjeObjekt = listaCom.FirstOrDefault(pod => pod.PodrucjeID == dioPodrucjaId);
                        if (podrucjeObjekt != null)
                        {
                            podrucjeComposit.Dodijeli(podrucjeObjekt);
                        }

                    }


                }
            }
        }
    }
}
