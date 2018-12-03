using System;
using System.Collections;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Iterator
{
   

        interface IApstraktnaKolekcija
        {
            Iterator KreirajIterator();
        }

        class Kolekcija : IApstraktnaKolekcija
        {
            private ArrayList _spremnik = new ArrayList();

            public Iterator KreirajIterator()
            {
                return new Iterator(this);
            }

            public int Count
            {
                get { return _spremnik.Count; }
            }

            public object this[int indeks]
            {
                get { return _spremnik[indeks]; }
                set { _spremnik.Add(value); }
            }
        }

        interface IAbstractIterator
        {
            Spremnik Prvi();

            Spremnik Sljedeci();

            bool JelGotovo { get; }

            Spremnik TrenutniSpremnik { get; }
        }

        class Iterator : IAbstractIterator
        {
            private Kolekcija _kolekcija;
            private int _trenutno = 0;
            private int _korak = 1;

            public Iterator(Kolekcija kolekcija)
            {
                this._kolekcija = kolekcija;
            }

            public Spremnik Prvi()
            {
                _trenutno = 0;
                return _kolekcija[_trenutno] as Spremnik;
            }

            public Spremnik Sljedeci()
            {
                _trenutno += _korak;
                if (!JelGotovo)
                    return _kolekcija[_trenutno] as Spremnik;
                else
                    return null;
            }

            public int Step
            {
                get { return _korak; }
                set { _korak = value; }
            }

            public Spremnik TrenutniSpremnik
            {
                get { return _kolekcija[_trenutno] as Spremnik; }
            }

            public bool JelGotovo
            {
                get { return _trenutno >= _kolekcija.Count; }
            }
        }
    }


