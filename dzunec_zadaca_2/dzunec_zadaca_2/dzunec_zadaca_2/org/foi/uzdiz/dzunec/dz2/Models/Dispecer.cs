using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Models
{
    public class Dispecer
    {
        public string Komanda { get; set; }

        public int BrojCiklusa { get; set; }

        public List<string> ListaVozilaDispecer = new List<string>();

        public Dispecer(string[] input)
        {
            if (input[0].Contains(' '))
            {
                string[] podjela = input[0].Split(' ');
                Komanda = podjela[0];
                BrojCiklusa = int.Parse(podjela[1]);
            }
            else
            {
                Komanda = input[0];
                BrojCiklusa = 0;
                string[] polje = input[1].Split(',');
                foreach (var v in polje)
                {
                    ListaVozilaDispecer.Add(v);
                }
            }


        }
    }
}
