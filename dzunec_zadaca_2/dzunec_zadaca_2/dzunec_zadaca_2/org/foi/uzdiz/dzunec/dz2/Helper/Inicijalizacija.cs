using System;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class Inicijalizacija
    {
        public Inicijalizacija()
        {
        }

        public static void Inicijaliziraj()
        {
            InicijalizacijaLoga();
        }

        private static void InicijalizacijaLoga()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Log.Init("Log.txt");
            Console.WriteLine("Inicijalizirana datoteka za izlaz");
        }
    }
}
