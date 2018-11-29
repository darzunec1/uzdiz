using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{
    public class Ulica
    {
        public string Id { get; set; }

        public string Naziv { get; set; }

        public int BrojMjesta { get; set; }

        public int UdioMali { get; set; }

        public int UdioSrednji { get; set; }

        public int UdioVeliki { get; set; }

        public double BrojMali { get; set; }

        public double BrojSrednji { get; set; }

        public double BrojVeliki { get; set; }

        public List<KorisnikB> ListaMalihKorisnika { get; set; } = new List<KorisnikB>();

        public List<KorisnikB> ListaSrednjihKorisnika { get; set; } = new List<KorisnikB>();

        public List<KorisnikB> ListaVelikihKorisnika { get; set; } = new List<KorisnikB>();

        public List<Spremnik> ListaSpremnikaUlice { get; set; } = new List<Spremnik>();

        public List<float> ListaOtpadaUlica { get; set; } = new List<float>();


        public Ulica(string[] input)
        {
            Id = input[0];
            Naziv = input[1];
            BrojMjesta = int.Parse(input[2]);
            UdioMali = int.Parse(input[3]);
            UdioSrednji = int.Parse(input[4]);
            UdioVeliki = int.Parse(input[5]);
            
            BrojMali = Math.Round(BrojMjesta * (double) UdioMali / 100 , MidpointRounding.AwayFromZero);
            BrojSrednji = Math.Round(BrojMjesta * (double) UdioSrednji / 100, MidpointRounding.AwayFromZero);
            BrojVeliki = Math.Round(BrojMjesta * (double) UdioVeliki / 100, MidpointRounding.AwayFromZero);

        }
        public List<float> UlicaOtpad(Ulica u)
        {
            float ukupnoStaklo = 0;
            float ukupnoPapir = 0;
            float ukupnoMetal = 0;
            float ukupnoBio = 0;
            float ukupnoMjesano = 0;



            foreach (var ulica in u.ListaSpremnikaUlice)
            {

                foreach (var spremnik in ListaSpremnikaUlice)
                {
                    if (spremnik.Naziv == "staklo")
                    {
                        ukupnoStaklo += spremnik.KolicinaOtpada;
                    }
                    else if (spremnik.Naziv == "bio")
                    {
                        ukupnoBio += spremnik.KolicinaOtpada;
                    }
                    else if (spremnik.Naziv == "metal")
                    {
                        ukupnoMetal += spremnik.KolicinaOtpada;
                    }
                    else if (spremnik.Naziv == "papir")
                    {
                        ukupnoPapir += spremnik.KolicinaOtpada;
                    }
                    else if (spremnik.Naziv == "mješano")
                    {
                        ukupnoMjesano += spremnik.KolicinaOtpada;
                    }
                }
            }

            List<float> listaOtpadUlica = new List<float>();
            listaOtpadUlica.Add(ukupnoStaklo);
            listaOtpadUlica.Add(ukupnoPapir);
            listaOtpadUlica.Add(ukupnoMetal);
            listaOtpadUlica.Add(ukupnoBio);
            listaOtpadUlica.Add(ukupnoMjesano);

            ListaOtpadaUlica = listaOtpadUlica;
            return listaOtpadUlica;
        }

        public Ulica()
        {
        }
    }
}
