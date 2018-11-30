using System;
using System.Collections.Generic;
using System.Linq;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper;
using static org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Composite.CompositePodrucja;

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

        public static void OtpadPoPodrucju()
        {
            Console.WriteLine("Ispis područja: ");

            foreach (var podrucje in DodjelaPodrucja.listaCom)
            {
                podrucje.Ispis(1);
                break;
            }

            foreach (var ulica in DodjelaPodrucja.listUlicaPod)
            {

                Podrucje podrucje = Citac.ListaPodrucja.FirstOrDefault(p => p.Id == ulica.PodrucjeID);
                if (podrucje != null)
                {
                    podrucje.listaUlica.Add(ulica);
                }

            }

        }
        public static void DododajPodrucjaUUlice()
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var podrucjeNajdonjeRazine in DodjelaPodrucja.listaCom)
                {
                    UlicaPodrucja ulicaNadjena = (UlicaPodrucja) podrucjeNajdonjeRazine.podrucja.FirstOrDefault(u => u.PodrucjeID == ulica.Id);

                    if (ulicaNadjena == null)
                    {
                        continue;
                    }

                    podrucjeNajdonjeRazine.ulicaPodrucja.Add(ulicaNadjena);
                    PodrucjeCom podrucjeIduceRazine = new PodrucjeCom("", "");
                    var podrucjeNajdonjeRazinePom = podrucjeNajdonjeRazine;
                    while (podrucjeIduceRazine != null)
                    {
                        foreach (var podrucjeKompozita in DodjelaPodrucja.listaCom)
                        {
                            podrucjeIduceRazine = (PodrucjeCom)podrucjeKompozita.podrucja.FirstOrDefault(p => p.PodrucjeID == podrucjeNajdonjeRazinePom.PodrucjeID);
                            if (podrucjeIduceRazine != null)
                            {
                                podrucjeKompozita.ulicaPodrucja.Add(ulicaNadjena);
                                podrucjeNajdonjeRazinePom = podrucjeKompozita;
                                break;
                            }

                        }

                    }
                }
            }

        }
        
        public static void IspisOtpadaPoPodrucju()
        {
            foreach (var pod in DodjelaPodrucja.listaCom)
            {
                float mjesano = 0;
                float bio = 0;
                float staklo = 0;
                float papir = 0;
                float metal = 0;
                foreach (var ulicaPod in pod.ulicaPodrucja)
                {
                    List<float> listaOtpadaTrenutnog = ulicaPod.Ulica.ListaOtpadaUlica;

                    staklo += listaOtpadaTrenutnog[0];
                    papir += listaOtpadaTrenutnog[1];
                    metal += listaOtpadaTrenutnog[2];
                    bio += listaOtpadaTrenutnog[3];
                    mjesano += listaOtpadaTrenutnog[4];

                }
                var polje = new string[] { "Staklo: ", "Papir: ", "Metal: ", "Bio: ", "Mješano: " };
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("Otpad u podrucju " + pod.PodrucjeID + " " + pod.Naziv);
                Console.WriteLine($"Staklo: {staklo} Papir: {papir} Metal: {metal}kg Bio: {bio}kg Mjesano: {mjesano}kg");
                Console.WriteLine("+++++++++++++++++++++++++++");

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
