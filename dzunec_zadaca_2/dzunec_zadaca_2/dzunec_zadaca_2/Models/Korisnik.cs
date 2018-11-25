using System;
using System.Collections.Generic;

namespace dzunec_zadaca_2.Models
{
    public class Korisnik
    {

        //Factory Method

        public static Korisnik MaliKorisnik(int sifraKorisnika)
        {
            return new Korisnik(sifraKorisnika);
        }

        public static Korisnik SrednjiKorisnik(int sifraKorisnika)
        {
            return new Korisnik(sifraKorisnika);
        }

        public static Korisnik VelikiKorisnik(int sifraKorisnika)
        {
            return new Korisnik(sifraKorisnika);
        }

        public int Id { get; set; }


        public Korisnik(int sifraKorisnika)
        {
            Id = sifraKorisnika;
        }
    }
}
