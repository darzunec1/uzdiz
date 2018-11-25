using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dzunec_zadaca_2.Models;

namespace dzunec_zadaca_2
{
    public class Citac
    {
        public static List<Ulica> ListaUlica { get; set; } = new List<Ulica>();

        public static List<VrstaSpremnik> ListaVrstaSpremnika { get; set; } = new List<VrstaSpremnik>();

        public static List<Spremnik> ListaSpremnika { get; set; } = new List<Spremnik>();


        static string[] sadrzajDatoteke;

        public Citac()
        {
        }

        public string[] ProcitajDatoteku(string nazivDatoteke)
        {

            sadrzajDatoteke = File.ReadAllLines(nazivDatoteke);

            return sadrzajDatoteke;
        }


        public void UcitajUlice(string[] sadrzajDatoteke)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Ispis sadržaja datoteke ulica: ");
            Console.WriteLine("---------------------------------------------------");
            foreach (string red in sadrzajDatoteke.Skip(1))
            {
                string[] polje = red.Split(';');
                Console.WriteLine("\t" + red);
                Ulica u = new Ulica(polje);
                ListaUlica.Add(u);
              
            }

            int sifraKorisnika = 1;

            foreach (var item in ListaUlica)
            {
         
                for (int i = 0; i < item.BrojMali; i++)
                {
                    Korisnik k = new Korisnik(sifraKorisnika);
                    item.ListaMalihKorisnika.Add(k);
                    sifraKorisnika++;
                }

                for (int i = 0; i < item.BrojMali; i++)
                {
                    Korisnik k = new Korisnik(sifraKorisnika);
                    item.ListaSrednjihKorisnika.Add(k);
                    sifraKorisnika++;
                }

                for (int i = 0; i < item.BrojMali; i++)
                {
                    Korisnik k = new Korisnik(sifraKorisnika);
                    item.ListaVelikihKorisnika.Add(k);
                    sifraKorisnika++;
                }
            }


            sadrzajDatoteke = null;
        }

        public void UcitajSpremnike(string[] sadrzajDatoteke)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Ispis sadržaja datoteke spremnika: ");
            Console.WriteLine("---------------------------------------------------");
            foreach (string red in sadrzajDatoteke.Skip(1))
            {
                string[] polje = red.Split(';');
                Console.WriteLine("\t" + red);
                VrstaSpremnik s = new VrstaSpremnik(polje);
                ListaVrstaSpremnika.Add(s);
            }
            foreach (var vrsta in ListaVrstaSpremnika)
            {
                foreach (var ulica in ListaUlica)
                {
                    Spremnik s = new Spremnik();
                    foreach (var korisnik in ulica.ListaMalihKorisnika)
                    {
                        s.ListaMalihKorisnika.Add(korisnik);

                    }
                }
            }
        }


    }
}
