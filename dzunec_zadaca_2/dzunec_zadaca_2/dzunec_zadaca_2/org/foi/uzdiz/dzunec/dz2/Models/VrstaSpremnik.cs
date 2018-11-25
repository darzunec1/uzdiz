using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{
    public class VrstaSpremnik
    {

        public string Naziv { get; set; }

        public int Vrsta { get; set; }

        public int BrojMalih { get; set; }

        public int BrojSrednjih { get; set; }

        public int BrojVelikih { get; set; }

        public int Nosivost { get; set; }

        public VrstaSpremnik()
        {
        }

        public VrstaSpremnik(string[] input)
        {
            Naziv = input[0];
            Vrsta = int.Parse(input[1]);
            BrojMalih = int.Parse(input[2]);
            BrojSrednjih = int.Parse(input[3]);
            BrojVelikih = int.Parse(input[4]);
            Nosivost = int.Parse(input[5]);
        }
    }
}
