using System;
using System.Collections.Generic;
using System.Linq;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class Odvoz
    {
        static List<Vozilo> listaVozilaZaSkupljanje = new List<Vozilo>();

        static List<Vozilo> listaVozilaZaPraznjenje = new List<Vozilo>();

        public static int brojacCiklusa = 1;

        public static int ciklus = 0;


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
                        Console.WriteLine("- - - > NAREDBA: Pripremi vozila");
                        Console.WriteLine("");
                        PripremaVozila(dispecer.ListaVozilaDispecer);
                        break;
                    case "KRENI":
                        Console.WriteLine("- - - > NAREDBA: Vozila krećeju pokupljati otpad");
                        Console.WriteLine("");
                        VozilaKrecu(dispecer.BrojCiklusa);
                        brojacCiklusa = 0;
                        break;
                    case "KVAR":
                        Console.WriteLine("- - - > NAREDBA: Kvar vozila");
                        Console.WriteLine("");
                        VozilaKvar(dispecer.ListaVozilaDispecer);
                        break;
                    case "STATUS":
                        Console.WriteLine("- - - > NAREDBA: Status svih vozila");
                        Console.WriteLine("");
                        StatusVozila(dispecer.ListaVozilaDispecer);
                        break;
                    case "ISPRAZNI":
                        Console.WriteLine("- - - > NAREDBA: Pražnjenje vozila");
                        Console.WriteLine("");
                        PraznjenjeVozila(dispecer.ListaVozilaDispecer);
                        break;
                    case "KONTROLA":
                        Console.WriteLine("- - - > NAREDBA: Vozilo ide na kontrolu");
                        Console.WriteLine("");
                        PraznjenjeVozila(dispecer.ListaVozilaDispecer);
                        break;

                    default: Console.WriteLine("Ne postoji naredba");
                        break;
                }
            }
        }

        private static void StatusVozila(List<string> listaVozilaDispecer)
        {
            Console.WriteLine("Ispis statusa sih vozila: ");
            foreach (var vozilo in Citac.ListaVozila)
            {
                Console.WriteLine("Vozilo: " + vozilo.Id + " " + vozilo.Naziv + " Status:" + vozilo.Status);
            }
        }

        private static void PraznjenjeVozila(List<string> listaVozilaDispecer)
        {
            foreach (var vozilo in Citac.ListaVozila)
            {
                if (vozilo.Status == "Praznjenje")
                {
                    vozilo.Dostupno = vozilo.Nosivost;
                    vozilo.Popunjenost = 0;

                    Console.WriteLine("Vozilo " + vozilo.Id + " " + vozilo.Naziv + " je ispraznilo svoj otpad!");
                }
            }
        }

        private static void VozilaKvar(List<string> listaVozilaDispecer)
        {
            foreach (var voziloId in listaVozilaDispecer)
            {
                List<Vozilo> v = Citac.ListaVozila.Where(p => p.Id == voziloId).ToList();
                foreach (var voz in v)
                {
                    voz.Status = "Kvar";
                }
            }
            foreach (var vozilo in Citac.ListaVozila)
            {
                if (vozilo.Status == "Kvar")
                {
                    Console.WriteLine("Vozilo " + vozilo.Id + " " + vozilo.Naziv + "  Status: " + vozilo.Status);
                }
            }
        }

        private static void VozilaKrecu(int brojCiklusa)
        {
            DefinirajPreuzimanje();

            DodijeliVrsteSpremnika();

            DajRasporedSpremnika();

            SkupljajOtpad(brojCiklusa);
            
        }


        private static void DajRasporedSpremnika()
        {

            foreach (var vozilo in Citac.ListaVozila)
            {
                Kolekcija kolekcija = new Kolekcija();

                foreach (int brojUlice in vozilo.redoslijedKretanja)
                {
                    Ulica ulica = Citac.ListaUlica[brojUlice];
                    List<Spremnik> listaSpremnika = ulica.ListaSpremnikaUlice.Where(s => s.Naziv == vozilo.VrstaSpremnika).ToList();
                    for (int i = 0; i < listaSpremnika.Count; i++)
                    {
                        kolekcija[i] = listaSpremnika[i];
                    }
                }

                Iterator iterator = kolekcija.KreirajIterator();
                vozilo.Iterator = iterator;
            }
        }

        private static void DodijeliVrsteSpremnika()
        {
            foreach (var vozilo in Citac.ListaVozila)
            {
                vozilo.DodijeliVrstuSpremnika(vozilo);
            }
        }

        private static void SkupljajOtpad(int brojCiklusa)
        {
            while (brojCiklusa > brojacCiklusa)
            {
                foreach (var vozilo in listaVozilaZaSkupljanje)
                {
                    if (listaVozilaZaSkupljanje.Count > 0 && !vozilo.Iterator.JelGotovo)
                    {

                        Spremnik s = vozilo.Iterator.TrenutniSpremnik;
                        if (s.KolicinaOtpada > 0)
                        {
                            if (vozilo.Dostupno > s.KolicinaOtpada)
                            {
                                Console.WriteLine("-----------------------------------------------------------------------");
                                vozilo.Popunjenost += s.KolicinaOtpada;
                                vozilo.Dostupno = vozilo.Nosivost - vozilo.Popunjenost;
                                s.KolicinaOtpada = 0;
                                vozilo.Iterator.Sljedeci();
                                Console.WriteLine(ciklus + " CIKLUS" + " Vozilo " + vozilo.Naziv + " Nosivost: " + vozilo.Nosivost + " Pokupilo: " + vozilo.Popunjenost);
                                ciklus++;

                            }
                            else
                            {
                                vozilo.Status = "Praznjenje";
                                ciklus++;
                            }
                           
                        }
                    }
                    brojacCiklusa++;

                }
            }

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
                        vozilo.Status = "Pripremljeno";
                        listaVozilaZaSkupljanje.Add(vozilo);
                        Console.WriteLine("Vozilo " + vozilo.Id + " je dodano u listu pripremljenih vozila!");
                    }
                }
            }
        }
    }
}
