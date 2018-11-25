using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2
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

                for (int i = 0; i < item.BrojSrednji; i++)
                {
                    Korisnik k = new Korisnik(sifraKorisnika);
                    item.ListaSrednjihKorisnika.Add(k);
                    sifraKorisnika++;
                }

                for (int i = 0; i < item.BrojVeliki; i++)
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
        }

        public List<Spremnik> GenerirajSpremnikeMali ()
        {
            List<Spremnik> listaSpremnika = new List<Spremnik>();
            int spremnikId = 1;
            foreach (var ulica in ListaUlica)
            {
                foreach (var vrstaSpremnika in ListaVrstaSpremnika)
                {
                    for (int i = 0; i < ulica.ListaMalihKorisnika.Count;)
                    {
                        if (vrstaSpremnika.BrojMalih == 0)
                        {
                            break;
                        }

                        Spremnik s = new Spremnik();
                        s.Id = spremnikId++;
                        s.Naziv = vrstaSpremnika.Naziv;
                        int brojac = 1;

                        while (brojac <= vrstaSpremnika.BrojMalih && i < ulica.ListaMalihKorisnika.Count)
                        {
                            Korisnik k = ulica.ListaMalihKorisnika[i];
                            s.ListaKorisnika.Add(k);
                            brojac++;
                            i++;
                        }
                        listaSpremnika.Add(s);
                    }

                }
            }
            return listaSpremnika;
        }

        public List<Spremnik> GenerirajSpremnikeSrednji()
        {
            List<Spremnik> listaSpremnika = new List<Spremnik>();
            int spremnikId = 1;
            foreach (var ulica in ListaUlica)
            {
                foreach (var vrstaSpremnika in ListaVrstaSpremnika)
                {
                    for (int i = 0; i < ulica.ListaSrednjihKorisnika.Count;)
                    {
                        if (vrstaSpremnika.BrojSrednjih == 0)
                        {
                            break;
                        }

                        Spremnik s = new Spremnik();
                        s.Id = spremnikId++;
                        s.Naziv = vrstaSpremnika.Naziv;
                        int brojac = 1;

                        while (brojac <= vrstaSpremnika.BrojSrednjih && i < ulica.ListaSrednjihKorisnika.Count)
                        {
                            Korisnik k = ulica.ListaSrednjihKorisnika[i];
                            s.ListaKorisnika.Add(k);
                            brojac++;
                            i++;
                        }
                        listaSpremnika.Add(s);
                    }

                }
            }
            return listaSpremnika;
        }

        public List<Spremnik> GenerirajSpremnikeVeliki()
        {
            List<Spremnik> listaSpremnika = new List<Spremnik>();
            int spremnikId = 1;
            foreach (var ulica in ListaUlica)
            {
                foreach (var vrstaSpremnika in ListaVrstaSpremnika)
                {
                    for (int i = 0; i < ulica.ListaVelikihKorisnika.Count;)
                    {
                        if (vrstaSpremnika.BrojVelikih == 0)
                        {
                            break;
                        }

                        Spremnik s = new Spremnik();
                        s.Id = spremnikId++;
                        s.Naziv = vrstaSpremnika.Naziv;
                        int brojac = 1;

                        while (brojac <= vrstaSpremnika.BrojVelikih && i < ulica.ListaVelikihKorisnika.Count)
                        {
                            Korisnik k = ulica.ListaVelikihKorisnika[i];
                            s.ListaKorisnika.Add(k);
                            brojac++;
                            i++;
                        }
                        listaSpremnika.Add(s);
                    }

                }
            }
            return listaSpremnika;
        }


    }
}
