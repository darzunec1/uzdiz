using System;
using System.Collections.Generic;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class Odvoz
    {
        public static List<Vozilo> listaPripremljenihVozila = new List<Vozilo>();

        public Odvoz()
        {
        }

        public static void ProvediNaredbe()
        {
            foreach (var dispecer in Citac.ListaDispecer)
            {
                string naredba = dispecer.Komanda;

                switch (naredba)
                {
                    case "PRIPREMI":
                        Console.WriteLine("Odabrana je naredba PRIPREMI");
                        PripremaVozila(dispecer.ListaVozilaDispecer);
                        break;
                    case "KRENI":
                        Console.WriteLine("Vozila krećeju pokupljati otpad");
                        VozilaKrecu(dispecer.BrojCiklusa);
                        break;

                    default: Console.WriteLine("Ne postoji naredba");
                        break;
                }
            }
        }

        private static void VozilaKrecu(int brojCiklusa)
        {
            if (brojCiklusa == 0)
            {
                //PokupiSavOtpad();
            }
            else
            {
                //prema broju ciklusa
            }
        }

        private static void PokupiSavOtpad()
        {
            throw new NotImplementedException();
        }

        private static void PripremaVozila(List<string> stringVozila)
        {
            foreach (var idVozila in stringVozila)
            {
                foreach (var vozilo in Citac.ListaVozila)
                {
                    if (vozilo.Id == idVozila)
                    {
                        listaPripremljenihVozila.Add(vozilo);
                        Console.WriteLine("Vozilo " + vozilo.Id + " je dodano u listu pripremljenih vozila!");
                    }
                }
            }
        }
    }
}
