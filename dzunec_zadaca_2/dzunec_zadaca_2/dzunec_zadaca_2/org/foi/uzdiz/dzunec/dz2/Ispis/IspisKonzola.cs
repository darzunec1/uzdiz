using System;
using System.Collections.Generic;
using System.Linq;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper;
using static org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Composite.CompositePodrucja;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.IspisKonzola.IspisKonzola.IspisKonzola.IspisKonzola
{
    public class IspisKonzola
    {
        public IspisKonzola()
        {
        }

        public static void IspisKorisnikaOtpad()
        {

                foreach (var ulica in Citac.ListaUlica)
                {
                    IspisKonzola.IspisUvjetni("");
                    IspisKonzola.IspisUvjetni("ID ulice: " + ulica.Id + " Naziv ulice: " + ulica.Naziv);
                    IspisKonzola.IspisUvjetni("---------------------------------------------------------------------------------");
                    foreach (var korisnik in ulica.ListaMalihKorisnika)
                    {

                        IspisKonzola.IspisUvjetni("++++++++++++++++++++++++++ MALI KORISNIK +++++++++++++++++++++++++++");
                        IspisKonzola.IspisUvjetni($"  Sifra korisnika: {korisnik.Id} ");
                        IspisKonzola.IspisUvjetni($"  Staklo:{korisnik.Staklo}kg Papir:{korisnik.Papir}kg Metal:{korisnik.Metal}kg Bio:{korisnik.Bio}kg Mješano:{korisnik.Mjesano}kg");
                        IspisKonzola.IspisUvjetni("");
                    }

                    foreach (var korisnik in ulica.ListaSrednjihKorisnika)
                    {
                        IspisKonzola.IspisUvjetni("++++++++++++++++++++++++++ SREDNJI KORISNIK ++++++++++++++++++++++++++");
                        IspisKonzola.IspisUvjetni($"  Sifra korisnika: {korisnik.Id} ");
                        IspisKonzola.IspisUvjetni($"  Staklo:{korisnik.Staklo}kg Papir:{korisnik.Papir}kg Metal:{korisnik.Metal}kg Bio:{korisnik.Bio}kg Mješano:{korisnik.Mjesano}kg");
                        IspisKonzola.IspisUvjetni("");
                    }
                    foreach (var korisnik in ulica.ListaVelikihKorisnika)
                    {
                        IspisKonzola.IspisUvjetni("++++++++++++++++++++++++++ VELIKI KORISNIK ++++++++++++++++++++++++++");
                        IspisKonzola.IspisUvjetni($"  Sifra korisnika: {korisnik.Id} ");
                        IspisKonzola.IspisUvjetni($"  Staklo:{korisnik.Staklo}kg Papir:{korisnik.Papir}kg Metal:{korisnik.Metal}kg Bio:{korisnik.Bio}kg Mješano:{korisnik.Mjesano}kg");
                        IspisKonzola.IspisUvjetni("");
                    }

            }

        }

        public static void IspisUvjetni(string tekst)
        {
            if (Program.vrstaIspisa == 0)
            {
                Console.WriteLine(tekst);
            }
        }
        public static void IspisSpremnika()
        {
            foreach (var spr in Citac.ListaSvihSpremnika)
            {
                IspisKonzola.IspisUvjetni($"    Id spremnika: {spr.Id} Naziv spremnika: {spr.Naziv} Nosivost: {spr.Nosivost}kg KOLICINA OTPADA: {spr.KolicinaOtpada}kg");
                IspisKonzola.IspisUvjetni("        Status: " + spr.Status);
                IspisKonzola.IspisUvjetni("     ------------------------------------------------------------------------------");
            }
        }

        public static void IspisSpremnikaPoUlicama()
        {

                foreach (var ulica in Citac.ListaUlica)
                {
                    IspisKonzola.IspisUvjetni("");
                    IspisKonzola.IspisUvjetni("Ulica: " + ulica.Id + " Naziv ulice: " + ulica.Naziv );
                    IspisKonzola.IspisUvjetni("-----------------------------------------------------------------------------------------------------------------------");
                    foreach (var spremnik in ulica.ListaSpremnikaUlice)
                    {
                        IspisKonzola.IspisUvjetni($"   Id spremnika: {spremnik.Id} Naziv spremnika: {spremnik.Naziv} Nosivost: {spremnik.Nosivost}kg KOLICINA OTPADA: {spremnik.KolicinaOtpada}kg");
                        IspisKonzola.IspisUvjetni("    ------------------------------------------------------------------------------");
                    }

                }
        }

        public static void IspisPodrucjaComposite()
        {
                IspisKonzola.IspisUvjetni("");
                IspisKonzola.IspisUvjetni("Ispis područja: ");

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
                IspisKonzola.IspisUvjetni("");

        }

        public static void DodajPodrucjaUUlice()
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
        
            String heder = String.Format("|{0,30}|{1,30}|{2,30}|{3,30}|{4,30}|{5,30},|{6,30},", "ID", "Područje", "Staklo", "Papir", "Metal", "Bio", "Mješano");
            Console.WriteLine(heder);
            Console.WriteLine("");
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
                String ispis = String.Format("|{0,30}|{1,30}|{2,30}|{3,30}|{4,30}|{5,30},|{6,30},|", pod.PodrucjeID, pod.Naziv, staklo + "kg", papir + "kg", metal + "kg", bio + "kg", mjesano + "kg");

                Console.WriteLine(ispis);

            }
            Console.WriteLine("");
        }
        public static void IspisUlicaOtpad()
        {

                foreach (var ulica in Citac.ListaUlica)
                {
                    List<float> listaOtpadaUlice = ulica.UlicaOtpad(ulica);
                    var polje = new string[] { "Staklo: ", "Papir: ", "Metal: ", "Bio: ", "Mješano: " };


                    IspisKonzola.IspisUvjetni("Otpad u ulici " + ulica.Id + " " + ulica.Naziv);
                    IspisKonzola.IspisUvjetni("+++++++++++++++++++++++++++++++++++++");
                    int i = 0;
                    foreach (var otpad in listaOtpadaUlice)
                    {
                        IspisKonzola.IspisUvjetni("  " + polje[i] + otpad + "kg");
                        i++;
                    }
                        IspisKonzola.IspisUvjetni("");
                }
            

        }
    }
}
