using System;
using System.Collections.Generic;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class Odvoz
    {
        public static List<Vozilo> listaVozilaZaSkupljanje = new List<Vozilo>();

        public static List<Spremnik> rasporedSpremnik = new List<Spremnik>();

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
                    case "KVAR":
                        Console.WriteLine("Kvar vozila");
                        VozilaKvar(dispecer.ListaVozilaDispecer);
                        break;
                    case "STATUS":
                        Console.WriteLine("Status svih vozila");
                        VozilaKvar(dispecer.ListaVozilaDispecer);
                        break;
                    case "ISPRAZNI":
                        Console.WriteLine("Pražnjenje vozila");
                        PraznjenjeVozila(dispecer.ListaVozilaDispecer);
                        break;
                    case "KONTROLA":
                        Console.WriteLine(" Vozilo ide na kontrolu");
                        PraznjenjeVozila(dispecer.ListaVozilaDispecer);
                        break;

                    default: Console.WriteLine("Ne postoji naredba");
                        break;
                }
            }
        }

        private static void PraznjenjeVozila(List<string> listaVozilaDispecer)
        {
            //TODO: Praznjenje vozila
        }

        private static void VozilaKvar(List<string> listaVozilaDispecer)
        {
            //TODO: Vozila u kvaru
        }

        private static void VozilaKrecu(int brojCiklusa)
        {
            DefinirajPreuzimanje();

            DodijeliVrsteSpremnika();

            DajRasporedSpremnika();

            if (brojCiklusa >= 0)
            {
                SkupljajOtpad();
            }
            else
            {
                //prema broju ciklusa
            }
        }

        private static void DajRasporedSpremnika()
        {
            foreach (var vozilo in Citac.ListaVozila)
            {
                foreach (int brojUlice in vozilo.redoslijedKretanja)
                {
                    Ulica ulica = Citac.ListaUlica[brojUlice];
                    foreach (var spremnik in ulica.ListaSpremnikaUlice)
                    {
                        if (!rasporedSpremnik.Contains(spremnik))
                        {
                            rasporedSpremnik.Add(spremnik);
                        }

                    }
                }
            }
        }

        private static void DodijeliVrsteSpremnika()
        {
            foreach (var vozilo in Citac.ListaVozila)
            {
                vozilo.DodijeliVrstuSpremnika(vozilo);
            }
        }

        private static void SkupljajOtpad()
        {

        }

        private static void DefinirajPreuzimanje()
        {
            int preuzimanje = int.Parse(Program.singletonParametri.DohvatiParametar("preuzimanje"));

            if (preuzimanje == 0)
            {
                List<int> redoslijedStaticni = DajRedoslijedUlica();

                foreach (var vozilo in Citac.ListaVozila)
                {
                    vozilo.redoslijedKretanja = redoslijedStaticni;
                }
            }
            else
            {
                foreach (var vozilo in Citac.ListaVozila)
                {
                    vozilo.redoslijedKretanja = DajRedoslijedUlica();
                }
            }
        }

        public static List<int> DajRedoslijedUlica()
        {
            List<int> redoslijedUlica = new List<int>();

            int sjemeGeneratora = int.Parse(Program.singletonParametri.DohvatiParametar("sjemeGeneratora"));
            SingletonGenSlucajnihBrojeva genSlucajnihBrojeva = SingletonGenSlucajnihBrojeva.DohvatiInstancu(sjemeGeneratora);

            do
            {
                int slucajniBroj = genSlucajnihBrojeva.SlucajniBrojInt(0, Citac.ListaUlica.Count );
                if (!redoslijedUlica.Contains(slucajniBroj))
                {
                    redoslijedUlica.Add(slucajniBroj);
                }

            } while (redoslijedUlica.Count != Citac.ListaUlica.Count);

            return redoslijedUlica;
        }

        private static void PokupiSavOtpad()
        {
            //TODO: Pokupi Sav otpad
        }

        private static void PripremaVozila(List<string> stringVozila)
        {
            foreach (var idVozila in stringVozila)
            {
                foreach (var vozilo in Citac.ListaVozila)
                {
                    if (vozilo.Id == idVozila)
                    {
                        listaVozilaZaSkupljanje.Add(vozilo);
                        Console.WriteLine("Vozilo " + vozilo.Id + " je dodano u listu pripremljenih vozila!");
                    }
                }
            }
        }
    }
}
