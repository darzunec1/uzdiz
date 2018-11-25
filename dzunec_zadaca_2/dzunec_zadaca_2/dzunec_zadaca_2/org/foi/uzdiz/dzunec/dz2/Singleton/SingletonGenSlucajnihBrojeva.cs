using System;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2
{
    public class SingletonGenSlucajnihBrojeva
    {
        public static SingletonGenSlucajnihBrojeva instancaGeneratora = null;
        Random rnd = null;

        private SingletonGenSlucajnihBrojeva(int sjemeGeneratora)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Pokretanje generatora slučajnih brojeva ... ");
            Console.WriteLine("-----------------------------------------------");
            rnd = new Random(sjemeGeneratora);

        }

        public static SingletonGenSlucajnihBrojeva DohvatiInstancu(int sjemeGeneratora)
        {
            if (instancaGeneratora == null)
            {
                instancaGeneratora = new SingletonGenSlucajnihBrojeva(sjemeGeneratora);
            }
            return instancaGeneratora;
        }

        public int SlucajniBrojInt(int min, int max)
        {
            return rnd.Next(min, max);
        }

        public long SlucajniBrojLong(long min, long max)
        {
            long rezultat = rnd.Next((Int32)(min >> 32), (Int32)(max >> 32));
            rezultat = (rezultat << 32);
            rezultat = rezultat | (long)rnd.Next((Int32)min, (Int32)max);
            return rezultat;
        }

        public float SlucajniBrojFloat(double min, double max, int brojDecimala)
        {
            double rezultat = (rnd.NextDouble() * (max - min) + min);
            return (float)Math.Round(rezultat, brojDecimala);
        }
    }
}
