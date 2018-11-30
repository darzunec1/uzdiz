using System;
using System.Collections.Generic;
using static org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Composite.CompositePodrucja;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite
{
    public class Podrucje
    {
        public string Id { get; set; }

        public string Naziv { get; set; }

        public List<string> Dio { get; set; } = new List<string>();

        public List<UlicaPodrucja> listaUlica = new List<UlicaPodrucja>();

        public Podrucje(string[] input)
        {
            Id = input[0];
            Naziv = input[1];

            string[] polje = input[2].Split(',');
            foreach (var item in polje)
            {
                Dio.Add(item);
            }
        }


    }
}
