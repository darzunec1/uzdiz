using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2
{
    class Program
    {
        private static readonly Random rnd = new Random();

        static void Main(string[] args)
        {

            string datotekaParametra = args[0];
            if (args.Length != 1)
            {
                Console.WriteLine("Program mora imati jedan parametar: DZ_1_parametri.txt i parametar za logiranje izlaza: LogIzlaz.txt");

            }
            
            string putanjaDatoteke = Path.GetDirectoryName(datotekaParametra);
            SingletonParametri singletonParametri = SingletonParametri.DohvatiInstancu(datotekaParametra);


            //Generiranje slučajnog broja!
            SingletonGenSlucajnihBrojeva genSlucajnihBrojeva = SingletonGenSlucajnihBrojeva.DohvatiInstancu(int.Parse(singletonParametri.DohvatiParametar("sjemeGeneratora")));
            int brojDecimala = int.Parse(singletonParametri.DohvatiParametar("brojDecimala"));

            //Inicijalizacija datoteke za logiranje izlaznih podataka
            Log.Init("IzlazniPodaci.txt");
            Console.WriteLine("Inicijalizirana datoteka za izlaz");

            //Citanje datoteke
            Citac citac = new Citac();
            string cijelaPutanjaUlice = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("ulice"));
            citac.UcitajUlice(citac.ProcitajDatoteku(cijelaPutanjaUlice));

            string cijelaPutanjaSpremnici = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("spremnici"));
            citac.UcitajSpremnike(citac.ProcitajDatoteku(cijelaPutanjaSpremnici));

            List<Spremnik> listaSpremnikaMali = citac.GenerirajSpremnikeMali();
            List<Spremnik> listaSpremnikaSrednji = citac.GenerirajSpremnikeSrednji();
            List<Spremnik> listaSpremnikaVeliki = citac.GenerirajSpremnikeVeliki();

            //var podrucje = new Podrucje();
            //podrucje.Dijete.Add(new Podpodrucje { Id = "1" });
            //podrucje.Dijete.Add(new PUlica { Id = "2" });

            //var grupa = new Podrucje();
            //grupa.Dijete.Add(new Podpodrucje { Id = "4" });
            //grupa.Dijete.Add(new PUlica  { Id = "3" });

            //Generiranje otpada korisnicima

            foreach (var ulica in Citac.ListaUlica )
            {
                foreach (var korisnik in ulica.ListaMalihKorisnika)
                {
                    double maliMin = double.Parse(singletonParametri.DohvatiParametar("maliStaklo"));
                    double maliStaklo = double.Parse(singletonParametri.DohvatiParametar("maliStaklo")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                                                  korisnik.Staklo = genSlucajnihBrojeva.SlucajniBrojFloat(maliMin, maliStaklo, 2);

                }

            }
            Console.WriteLine("--------------------------------------------");

            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaMalihKorisnika)
                {
                    Console.WriteLine($"{korisnik.Id}");
                    Console.WriteLine($"{korisnik.Staklo} kg");
                }
            }

            Console.WriteLine("--------------------------------------------");

            System.Console.ReadKey();

        }
    }
}
