using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2
{
    class Citac
    {
        public static List<Ulica> ListaUlica { get; set; } = new List<Ulica>();

        public static List<VrstaSpremnik> ListaVrstaSpremnika { get; set; } = new List<VrstaSpremnik>();

        public static List<Spremnik> ListaSpremnika { get; set; } = new List<Spremnik>();

        public static List<Podrucje> ListaPodrucja { get; set; } = new List<Podrucje>();

        public static List<Spremnik> ListaSvihSpremnika { get; set; } = new List<Spremnik>();

        public static List<Vozilo> ListaVozila { get; set; } = new List<Vozilo>();

        public static List<Dispecer> ListaDispecer { get; set; } = new List<Dispecer>();
 

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
            foreach (string red in sadrzajDatoteke.Skip(1))
            {
                try
                {
                    string[] polje = red.Split(';');
                    if (polje.Length == 6)
                    {
                        Ulica u = new Ulica(polje);
                        ListaUlica.Add(u);
                    }
                    else IspisKonzola.IspisUvjetni("Nesipravan redak! " + red);
                }
                catch (Exception ex)
                {
                    IspisKonzola.IspisUvjetni("Neispravan redak!!!! " + red + ex.Message);
                }

              
            }

            int sifraKorisnika = 1;

            foreach (var item in ListaUlica)
            {
         
                for (int i = 0; i < item.BrojMali; i++)
                {
                    KorisnikB k = new KorisnikB();
                    k.Id = sifraKorisnika;
                    KorisnikSmeceBuilder korisnikSmece = new KorisnikSmeceBuilder(k);
                    item.ListaMalihKorisnika.Add(korisnikSmece);
                    sifraKorisnika++;
                }

                for (int i = 0; i < item.BrojSrednji; i++)
                {
                    KorisnikB k = new KorisnikB();
                    k.Id = sifraKorisnika;
                    KorisnikSmeceBuilder korisnikSmece = new KorisnikSmeceBuilder(k);
                    item.ListaSrednjihKorisnika.Add(korisnikSmece);
                    sifraKorisnika++;
                }

                for (int i = 0; i < item.BrojVeliki; i++)
                {
                    KorisnikB k = new KorisnikB();
                    k.Id = sifraKorisnika;
                    KorisnikSmeceBuilder korisnikSmece = new KorisnikSmeceBuilder(k);
                    item.ListaVelikihKorisnika.Add(korisnikSmece);
                    sifraKorisnika++;
                }
            }


            sadrzajDatoteke = null;
        }

        public void UcitajVozila(string[] sadrzajDatoteke)
        {
            foreach (string red in sadrzajDatoteke.Skip(1))
            {
                try
                {
                    string[] polje = red.Split(';');
                    if (polje.Length == 6)
                    {
                        Vozilo vozilo = new Vozilo(polje);
                        ListaVozila.Add(vozilo);
                    }
                    else IspisKonzola.IspisUvjetni("Neispravan redak! " + red);
                }
                catch (Exception ex)
                {
                    IspisKonzola.IspisUvjetni("Neispravan redak!!!! " + red + ex.Message);
                }

            }
        }

        public void UcitajDispecer(string[] sadrzajDatoteke)
        {
            foreach (string red in sadrzajDatoteke.Skip(1))
            {
                string[] polje = red.Split(';');
                try
                {
                    if (polje.Length == 2)
                    {
                        Dispecer dispecer = new Dispecer(polje);
                        ListaDispecer.Add(dispecer);

                    }
                    else IspisKonzola.IspisUvjetni("Neispravan redak! " + red);

                }
                catch (Exception ex)
                {
                    IspisKonzola.IspisUvjetni("Neispravan redak!!!! " + red + " " + ex.Message);
                }

            }
        }

        public void UcitajSpremnike(string[] sadrzajDatoteke)
        {
            foreach (string red in sadrzajDatoteke.Skip(1))
            {
                try
                {
                    string[] polje = red.Split(';');
                    if (polje.Length == 6)
                    {
                        VrstaSpremnik s = new VrstaSpremnik(polje);
                        ListaVrstaSpremnika.Add(s);
                    }
                    else
                    {
                        IspisKonzola.IspisUvjetni("Neispravan redak! " + red);
                    }
                }
                catch (Exception ex)
                {
                    IspisKonzola.IspisUvjetni("Neispravan redak! " + red + " " + ex.Message);
                }

            }
        }

        public void UcitajPodrucja(string[] sadrzajDatoteke)
        {
            foreach (string red in sadrzajDatoteke.Skip(1))
            {
                try
                {
                    string[] polje = red.Split(';');
                    if (polje.Length == 3)
                    {
                        Podrucje podrucje = new Podrucje(polje);
                        ListaPodrucja.Add(podrucje);
                    }
                    else IspisKonzola.IspisUvjetni("Neispravan redak! " + red);
                }
                catch (Exception ex)
                {
                    IspisKonzola.IspisUvjetni("Neispravan redak!!!! "+ red + ex.Message);
                }

            }
        }


        int spremnikId = 1;

        public List<Spremnik> GenerirajSpremnikeMali ()
        {
            List<Spremnik> listaSpremnika = new List<Spremnik>();

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
                        s.Nosivost = vrstaSpremnika.Nosivost;
                        s.PripadaUlici = ulica.Id;

                        int brojac = 1;

                        while (brojac <= vrstaSpremnika.BrojMalih && i < ulica.ListaMalihKorisnika.Count)
                        {
                            KorisnikB k = ulica.ListaMalihKorisnika[i];
                            s.ListaKorisnika.Add(k);
                            brojac++;
                            i++;
                        }
                        listaSpremnika.Add(s);
                        ulica.ListaSpremnikaUlice.Add(s);
                    }

                }
            }
            return listaSpremnika;
        }

        public List<Spremnik> GenerirajSpremnikeSrednji()
        {
            List<Spremnik> listaSpremnika = new List<Spremnik>();
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
                        s.Nosivost = vrstaSpremnika.Nosivost;
                        s.PripadaUlici = ulica.Id;
                        int brojac = 1;

                        while (brojac <= vrstaSpremnika.BrojSrednjih && i < ulica.ListaSrednjihKorisnika.Count)
                        {
                            KorisnikB k = ulica.ListaSrednjihKorisnika[i];
                            s.ListaKorisnika.Add(k);
                            brojac++;
                            i++;
                        }
                        listaSpremnika.Add(s);
                        ulica.ListaSpremnikaUlice.Add(s);
                    }

                }
            }
            return listaSpremnika;
        }

        public List<Spremnik> GenerirajSpremnikeVeliki()
        {
            List<Spremnik> listaSpremnika = new List<Spremnik>();

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
                        s.Nosivost = vrstaSpremnika.Nosivost;
                        s.PripadaUlici = ulica.Id;
                        int brojac = 1;

                        while (brojac <= vrstaSpremnika.BrojVelikih && i < ulica.ListaVelikihKorisnika.Count)
                        {
                            KorisnikB k = ulica.ListaVelikihKorisnika[i];
                            s.ListaKorisnika.Add(k);
                            brojac++;
                            i++;
                        }
                        listaSpremnika.Add(s);
                        ulica.ListaSpremnikaUlice.Add(s);
                    }

                }
            }
            return listaSpremnika;
        }


    }
}
