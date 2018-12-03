using System.Collections.Generic;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{
    class Vozilo
    {
        public string Id { get; set; }

        public string Naziv { set; get; }

        public int Tip { get; set; }

        public int Vrsta { get; set; }

        public float Nosivost { get; set; }

        public float Popunjenost { get; set; }

        public string VrstaSpremnika { get; set; }

        public Iterator Iterator { get; set; }

        public List<string> Vozaci = new List<string>();

        public List<int> redoslijedKretanja = new List<int>();

        

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

        public void DodijeliVrstuSpremnika(Vozilo v)
        {
            if (v.Vrsta == 0)
            {
                v.VrstaSpremnika = "staklo";
            }
            else if (v.Vrsta == 1)
            {
                v.VrstaSpremnika = "papir";
            }

            else if (v.Vrsta == 2)
            {
                v.VrstaSpremnika = "metal";
            }

            else if (v.Vrsta == 3)
            {
                v.VrstaSpremnika = "bio";
            }
            else
            {
                v.VrstaSpremnika = "mješano";
            }

        }
    }
}
