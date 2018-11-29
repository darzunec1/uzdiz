using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{
    public class KorisnikB 
    {
        public int Id { get; set; }

        public float Staklo { get; set; }

        public float Papir { get; set; }

        public float Metal { get; set; }

        public float Bio { get; set; }

        public float Mjesano { get; set; }


        public KorisnikB()
        {
        }

    }
    public class KorisnikBuilder
    {
        protected KorisnikB korisnik = new KorisnikB();

        public static implicit operator KorisnikB(KorisnikBuilder kb)
        {
            return kb.korisnik;
        }
    }

    public class KorisnikSmeceBuilder : KorisnikBuilder
    {
    

        public KorisnikSmeceBuilder (KorisnikB korisnik)
        {
            this.korisnik = korisnik;
        }

        public KorisnikSmeceBuilder DodajStaklo (float staklo)
        {
            korisnik.Staklo = staklo;
            return this;
        }

        public KorisnikSmeceBuilder DodajPapir(float papir)
        {
            korisnik.Papir = papir;
            return this;
        }

        public KorisnikSmeceBuilder DodajBio(float bio)
        {
            korisnik.Bio = bio;
            return this;
        }

        public KorisnikSmeceBuilder DodajMetal(float metal)
        {
            korisnik.Metal = metal;
            return this;
        }
        public KorisnikSmeceBuilder DodajMjesano(float mjesano)
        {
            korisnik.Mjesano = mjesano;
            return this;
        }
    }

}
