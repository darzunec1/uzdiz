using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
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

        public float Staklo { get; set; }

        public float Papir { get; set; }

        public float Metal { get; set; }

        public float Bio { get; set; }

        public float Mjesano { get; set; }

        public Korisnik(int sifraKorisnika)
        {
            Id = sifraKorisnika;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
