using System;
using System.Collections.Generic;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Composite
{
    public class CompositePodrucja
    {
        public CompositePodrucja()
        {

        }

        public abstract class PodrucjeK
        {
            public string PodrucjeID;

            public string Naziv;

            public PodrucjeK(string Id, string naziv)
            {
                PodrucjeID = Id;
                Naziv = naziv;
            }

            public abstract void Dodijeli(PodrucjeK podrucje);

            public abstract void Odbaci(PodrucjeK podrucje);

            public abstract void Ispis(int uvlaka);

        }

        public class UlicaPodrucja : PodrucjeK
        {
            Ulica Ulica;

            public UlicaPodrucja(string Id, string Naziv, Ulica ulica) : base(Id, Naziv)
            {
                Ulica = ulica;
            }

            public override void Dodijeli(PodrucjeK podrucje) => throw new NotImplementedException();

            public override void Ispis(int uvlaka)
            {
                Console.WriteLine(new String('-', uvlaka) + " " + Naziv);

            }
            public List<float> DajSmece()
            {
                return Ulica.ListaOtpadaUlica;
            }

            public override void Odbaci(PodrucjeK podrucje) => throw new NotImplementedException();


        }

        public class PodrucjeCom : PodrucjeK
        {
            public List<PodrucjeK> podrucja = new List<PodrucjeK>();

            public List<UlicaPodrucja> ulicaPodrucja = new List<UlicaPodrucja>();

            public PodrucjeCom(string Id, string Naziv) : base(Id, Naziv)
            {

            }

            public override void Dodijeli(PodrucjeK podrucje)
            {
                podrucja.Add(podrucje);
            }

            public override void Ispis(int uvlaka)
            {


                Console.WriteLine(new String('-', uvlaka) + "+ " + Naziv);

                // Display each child element on this node
                foreach (PodrucjeK d in podrucja)
                {
                    d.Ispis(uvlaka + 2);
                }
            }

            public override void Odbaci(PodrucjeK podrucje)
            {
                podrucje.Odbaci(podrucje);
            }
        }
    }
}
