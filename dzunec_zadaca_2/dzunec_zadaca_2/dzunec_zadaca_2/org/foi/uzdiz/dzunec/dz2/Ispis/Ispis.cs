using System;
using System.Collections.Generic;
namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Ispis
{
    public class Ispis
    {
        public Ispis()
        {
        }

        public static void IspisKorisnikaOtpad()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("++++++++++++++ MALI KORISNICI ++++++++++++++");
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaMalihKorisnika)
                {
                    Console.WriteLine($"Sifra korisnika: {korisnik.Id} ");
                    Console.WriteLine($"Staklo:{korisnik.Staklo}kg Papir:{korisnik.Papir}kg Metal:{korisnik.Metal}kg Bio:{korisnik.Bio}kg Mješano:{korisnik.Mjesano}kg");
                    Console.WriteLine("------------------------------------------------------------------------------");

                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("+++++++++++++ SREDNJI KORISNICI ++++++++++++");

            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaSrednjihKorisnika)
                {

                    Console.WriteLine("------------------------------------------------------------------------------");
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
                    Console.WriteLine("------------------------------------------------------------------------------");

                }
            }

        }

        public static void IspisSpremnika()
        {
            foreach (var spr in Citac.ListaSvihSpremnika)
            {
                Console.WriteLine($"Id spremnika: {spr.Id} Naziv spremnika: {spr.Naziv} Nosivost: {spr.Nosivost}kg KOLICINA OTPADA: {spr.KolicinaOtpada}kg");
                Console.WriteLine("Status: " + spr.Status);
                Console.WriteLine("------------------------------------------------------------------------------");
            }
        }

        public static void IspisSpremnikaPoUlicama()
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                Console.WriteLine("((((++++++++++))))");
                Console.WriteLine("Ulica: " + ulica.Id);
                Console.WriteLine("((((++++++++++))))");
                foreach (var spremnik in ulica.ListaSpremnikaUlice)
                {
                    Console.WriteLine($"Id spremnika: {spremnik.Id} Naziv spremnika: {spremnik.Naziv} Nosivost: {spremnik.Nosivost}kg KOLICINA OTPADA: {spremnik.KolicinaOtpada}kg");
                    Console.WriteLine("------------------------------------------------------------------------------");
                }
            }

        }

        public static void IspisUlicaOtpad()
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                List<float> listaOtpadaUlice = ulica.UlicaOtpad(ulica);
                var polje = new string[] { "Staklo: ", "Papir: ", "Metal: ", "Bio: ", "Mješano: " };
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("Otpad u ulici " + ulica.Id + " "+ ulica.Naziv);
                Console.WriteLine("+++++++++++++++++++++++++++");
                int i = 0;
                foreach (var otpad in listaOtpadaUlice)
                {
                    Console.WriteLine(polje[i] + otpad + "kg");
                    i++;
                }
            }
        }
    }
}
