using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper;

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

            List<Spremnik> listaSvihSpremnika = listaSpremnikaMali.Concat(listaSpremnikaSrednji)
                                                       .Concat(listaSpremnikaVeliki)
                                                       .ToList();

            //Generiranje otpada korisnicima

            DodjelaOtpada.DodijeliOtpadMalim(singletonParametri, genSlucajnihBrojeva);
            DodjelaOtpada.DodijeliOtpadSrednjim(singletonParametri, genSlucajnihBrojeva);
            DodjelaOtpada.DodijeliOtpadVelikim(singletonParametri, genSlucajnihBrojeva);

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("++++++++++++++ MALI KORISNICI ++++++++++++++");
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaMalihKorisnika)
                {
                    Console.WriteLine($"Sifra korisnika: {korisnik.Id} ");
                    Console.WriteLine($"Staklo:{korisnik.Staklo}kg Papir:{korisnik.Papir}kg Metal:{korisnik.Metal}kg Bio:{korisnik.Bio}kg Mješano:{korisnik.Mjesano}kg");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");

                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("+++++++++++++ SREDNJI KORISNICI ++++++++++++");

            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaSrednjihKorisnika)
                {

                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Sifra korisnika: {korisnik.Id} ");
                    Console.WriteLine($"Staklo:{korisnik.Staklo}kg Papir:{korisnik.Papir}kg Metal:{korisnik.Metal}kg Bio:{korisnik.Bio}kg Mješano:{korisnik.Mjesano}kg");
                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("+++++++++++++ VELIKI KORISNICI +++++++++++++");

            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaVelikihKorisnika)
                {
                    Console.WriteLine($"Sifra korisnika: {korisnik.Id} ");
                    Console.WriteLine($"Staklo:{korisnik.Staklo}kg Papir:{korisnik.Papir}kg Metal:{korisnik.Metal}kg Bio:{korisnik.Bio}kg Mješano:{korisnik.Mjesano}kg");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------");

                }
            }
            Console.WriteLine("--------------------------------------------");
            //Korisnici stavljaju otpad u spremnike
            foreach (var spremnik in listaSvihSpremnika)
            {
                foreach (var korisnik in spremnik.ListaKorisnika)
                {
                    if (spremnik.Naziv == "staklo")
                    {         
                        if ((spremnik.Nosivost - spremnik.KolicinaOtpada) < korisnik.Staklo)
                        {
                            spremnik.KolicinaOtpada += spremnik.Nosivost - spremnik.KolicinaOtpada;
                            Console.WriteLine("Spremnik je puni!");
                        }
                        else
                        {
                            spremnik.KolicinaOtpada += korisnik.Staklo;
                            korisnik.Staklo = korisnik.Staklo - spremnik.KolicinaOtpada;
                        }

                    }
                    else if (spremnik.Naziv == "metal")
                    {
                        spremnik.KolicinaOtpada += korisnik.Metal;
                        korisnik.Metal = korisnik.Metal - spremnik.KolicinaOtpada;
                    }
                    else if (spremnik.Naziv == "bio")
                    {
                        spremnik.KolicinaOtpada += korisnik.Bio;
                        korisnik.Bio = korisnik.Bio - spremnik.KolicinaOtpada;
                    }
                    else if (spremnik.Naziv == "mješano")
                    {
                        spremnik.KolicinaOtpada += korisnik.Mjesano;
                        korisnik.Mjesano = korisnik.Mjesano - spremnik.KolicinaOtpada;
                    }
                    else if (spremnik.Naziv == "papir")
                    {
                        spremnik.KolicinaOtpada += korisnik.Papir;
                        korisnik.Papir = korisnik.Papir - spremnik.KolicinaOtpada;
                    }
                }
               
            }

            foreach (var spr in listaSvihSpremnika)
            {
                Console.WriteLine($"Id spremnika: {spr.Id} Naziv spremnika: {spr.Naziv} Nosivost: {spr.Nosivost}kg KOLICINA OTPADA: {spr.KolicinaOtpada}kg");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------");
            }

            System.Console.ReadKey();

        }


    }
}
