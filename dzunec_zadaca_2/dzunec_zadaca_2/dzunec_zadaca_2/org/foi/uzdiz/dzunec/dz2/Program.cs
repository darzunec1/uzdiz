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

            //dohvaćanje instance i putanje
            string putanjaDatoteke = Path.GetDirectoryName(datotekaParametra);
            SingletonParametri singletonParametri = SingletonParametri.DohvatiInstancu(datotekaParametra);


            //Generiranje slučajnog broja!
            int sjemeGeneratora = int.Parse(singletonParametri.DohvatiParametar("sjemeGeneratora"));
            SingletonGenSlucajnihBrojeva genSlucajnihBrojeva = SingletonGenSlucajnihBrojeva.DohvatiInstancu(sjemeGeneratora);
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

            //Generiranje otpada korisnicima

            DodijeliOtpadMalim(singletonParametri, genSlucajnihBrojeva);
            DodijeliOtpadSrednjim(singletonParametri, genSlucajnihBrojeva);
            DodijeliOtpadVelikim(singletonParametri, genSlucajnihBrojeva);

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("++++++++++++++ MALI KORISNICI ++++++++++++++");
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaMalihKorisnika)
                {
                    Console.WriteLine($"Sifra korisnika: {korisnik.Id}");
                    Console.WriteLine($"   Staklo: {korisnik.Staklo} kg");
                    Console.WriteLine($"   Papir: {korisnik.Papir} kg");
                    Console.WriteLine($"   Metal: {korisnik.Metal} kg");
                    Console.WriteLine($"   Bio: {korisnik.Bio} kg");
                    Console.WriteLine($"   Mješano: {korisnik.Mjesano} kg");
                    Console.WriteLine("-------------------------------------");

                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("+++++++++++++ SREDNJI KORISNICI ++++++++++++");

            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaSrednjihKorisnika)
                {
                    Console.WriteLine($"Sifra korisnika: {korisnik.Id}");
                    Console.WriteLine($"   Staklo: {korisnik.Staklo} kg");
                    Console.WriteLine($"   Papir: {korisnik.Papir} kg");
                    Console.WriteLine($"   Metal: {korisnik.Metal} kg");
                    Console.WriteLine($"   Bio: {korisnik.Bio} kg");
                    Console.WriteLine($"   Mješano: {korisnik.Mjesano} kg");
                    Console.WriteLine("-------------------------------------");

                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("+++++++++++++ VELIKI KORISNICI +++++++++++++");

            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaVelikihKorisnika)
                {
                    Console.WriteLine($"Sifra korisnika: {korisnik.Id}");
                    Console.WriteLine($"   Staklo: {korisnik.Staklo} kg");
                    Console.WriteLine($"   Papir: {korisnik.Papir} kg");
                    Console.WriteLine($"   Metal: {korisnik.Metal} kg");
                    Console.WriteLine($"   Bio: {korisnik.Bio} kg");
                    Console.WriteLine($"   Mješano: {korisnik.Mjesano} kg");
                    Console.WriteLine("-------------------------------------");

                }
            }
            Console.WriteLine("--------------------------------------------");

            System.Console.ReadKey();

        }
        public static void DodijeliOtpadMalim(SingletonParametri singletonParametri, SingletonGenSlucajnihBrojeva genSlucajnihBrojeva)
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaMalihKorisnika)
                {
                    double maliMinS = double.Parse(singletonParametri.DohvatiParametar("maliStaklo"));
                    double maliMaxS = double.Parse(singletonParametri.DohvatiParametar("maliStaklo")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Staklo = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinS, maliMaxS, 2);

                    double maliMinP = double.Parse(singletonParametri.DohvatiParametar("maliPapir"));
                    double maliMaxP = double.Parse(singletonParametri.DohvatiParametar("maliPapir")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Papir = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinP, maliMaxP, 2);

                    double maliMinM = double.Parse(singletonParametri.DohvatiParametar("maliMetal"));
                    double maliMaxM = double.Parse(singletonParametri.DohvatiParametar("maliMetal")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Metal = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinM, maliMaxM, 2);

                    double maliMinB = double.Parse(singletonParametri.DohvatiParametar("maliBio"));
                    double maliMaxB = double.Parse(singletonParametri.DohvatiParametar("maliBio")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Bio = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinB, maliMaxB, 2);

                    double maliMinMj = double.Parse(singletonParametri.DohvatiParametar("maliMješano"));
                    double maliMaxMj = double.Parse(singletonParametri.DohvatiParametar("maliMješano")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Mjesano = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinMj, maliMaxMj, 2);

                }

            }

        }

        public static void DodijeliOtpadSrednjim(SingletonParametri singletonParametri, SingletonGenSlucajnihBrojeva genSlucajnihBrojeva)
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaSrednjihKorisnika)
                {
                    double srednjiMinS = double.Parse(singletonParametri.DohvatiParametar("srednjiStaklo"));
                    double srednjiMaxS = double.Parse(singletonParametri.DohvatiParametar("srednjiStaklo")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Staklo = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinS, srednjiMaxS, 2);

                    double srednjiMinP = double.Parse(singletonParametri.DohvatiParametar("srednjiPapir"));
                    double srednjiMaxP = double.Parse(singletonParametri.DohvatiParametar("srednjiPapir")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Papir = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinP, srednjiMaxP, 2);

                    double srednjiMinM = double.Parse(singletonParametri.DohvatiParametar("srednjiMetal"));
                    double srednjiMaxM = double.Parse(singletonParametri.DohvatiParametar("srednjiMetal")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Metal = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinM, srednjiMaxM, 2);

                    double srednjiMinB = double.Parse(singletonParametri.DohvatiParametar("srednjiBio"));
                    double srednjiMaxB = double.Parse(singletonParametri.DohvatiParametar("srednjiBio")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Bio = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinB, srednjiMaxB, 2);

                    double srednjiMinMj = double.Parse(singletonParametri.DohvatiParametar("srednjiMješano"));
                    double srednjiMaxMj = double.Parse(singletonParametri.DohvatiParametar("srednjiMješano")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Mjesano = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinMj, srednjiMaxMj, 2);

                }

            }

        }

        public static void DodijeliOtpadVelikim(SingletonParametri singletonParametri, SingletonGenSlucajnihBrojeva genSlucajnihBrojeva)
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaVelikihKorisnika)
                {
                    double velikiMinS = double.Parse(singletonParametri.DohvatiParametar("velikiStaklo"));
                    double velikiMaxS = double.Parse(singletonParametri.DohvatiParametar("velikiStaklo")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Staklo = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinS, velikiMaxS, 2);

                    double velikiMinP = double.Parse(singletonParametri.DohvatiParametar("velikiPapir"));
                    double velikiMaxP = double.Parse(singletonParametri.DohvatiParametar("velikiPapir")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Papir = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinP, velikiMaxP, 2);

                    double velikiMinM = double.Parse(singletonParametri.DohvatiParametar("velikiMetal"));
                    double velikiMaxM = double.Parse(singletonParametri.DohvatiParametar("velikiMetal")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Metal = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinM, velikiMaxM, 2);

                    double velikiMinB = double.Parse(singletonParametri.DohvatiParametar("velikiBio"));
                    double velikiMaxB = double.Parse(singletonParametri.DohvatiParametar("velikiBio")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Bio = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinB, velikiMaxB, 2);

                    double velikiMinMj = double.Parse(singletonParametri.DohvatiParametar("velikiMješano"));
                    double velikiMaxMj = double.Parse(singletonParametri.DohvatiParametar("velikiMješano")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Mjesano = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinMj, velikiMaxMj, 2);

                }

            }

        }



    }
}
