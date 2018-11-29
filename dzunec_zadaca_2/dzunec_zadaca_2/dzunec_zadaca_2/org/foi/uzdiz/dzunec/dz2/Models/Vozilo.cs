using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{
    public class Vozilo
    {
        public string Id { get; set; }

        public string Naziv { set; get; }

        public int Tip { get; set; }

        public int Vrsta { get; set; }

        public float Nosivost { get; set; }

        public List<string> Vozaci = new List<string>();

        public Vozilo(string[] input)
        {
            Id = input[0];
            Naziv = input[1];
            Tip = int.Parse(input[2]);
            Vrsta = int.Parse(input[3]);
            Nosivost = float.Parse(input[4]);

            string[] polje = input[5].Split(',');
            foreach (var item in polje)
            {
                Vozaci.Add(item);
            }
        }
    }
}
