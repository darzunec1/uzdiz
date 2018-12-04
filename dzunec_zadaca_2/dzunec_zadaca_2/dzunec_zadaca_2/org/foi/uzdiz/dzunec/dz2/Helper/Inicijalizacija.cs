using System;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class Inicijalizacija
    {
        public Inicijalizacija()
        {
        }

        public static void Inicijaliziraj(SingletonParametri parametri, string putanjaDatoteke)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Log.Init(parametri.DohvatiParametar("izlaz"), putanjaDatoteke);
            Console.WriteLine("Inicijalizirana datoteka za izlaz");
        }

    }
}
