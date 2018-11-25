using System;
namespace dzunec_zadaca_2.Models
{
    public class Vozilo
    {
        public string Naziv { set; get; }

        public int Tip { get; set; }

        public int Vrsta { get; set; }

        public int Nosivost { get; set; }

        public string Vozaci { get; set; }

        public Vozilo()
        {
        }
    }
}
