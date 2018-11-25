using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using dzunec_zadaca_2.Models;

namespace dzunec_zadaca_2
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
            citac.UcitajUlice(citac.ProcitajDatoteku(singletonParametri.DohvatiParametar("ulice")));
            citac.UcitajSpremnike(citac.ProcitajDatoteku(singletonParametri.DohvatiParametar("spremnici")));


            List<Spremnik> listaSpremnika = citac.GenerirajSpremnike();

            Spremnik neki = listaSpremnika[1];
            int b = 6;
            b = 9;

            System.Console.ReadKey();

        }
    }
}
