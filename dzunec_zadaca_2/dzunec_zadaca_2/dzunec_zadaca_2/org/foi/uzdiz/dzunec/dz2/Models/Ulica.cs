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

        public List<Korisnik> ListaMalihKorisnika { get; set; } = new List<Korisnik>();

        public List<Korisnik> ListaSrednjihKorisnika { get; set; } = new List<Korisnik>();

        public List<Korisnik> ListaVelikihKorisnika { get; set; } = new List<Korisnik>();


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


        public Ulica()
        {
        }
    }
}
