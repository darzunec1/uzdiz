using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Ispis;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Decorator;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;
using static org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Decorator.Decorator;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2
{
    class Program
    {
        private static readonly Random rnd = new Random();

        internal static void Main(string[] args)
        {

            string datotekaParametra = args[0];
            if (args.Length != 1)
            {
                Console.WriteLine("Program mora imati jedan parametar: DZ_1_parametri.txt");

            }

            //inicijalizacija
            //dohvaćanje instance i putanje
            string putanjaDatoteke = Path.GetDirectoryName(datotekaParametra);
            SingletonParametri singletonParametri = SingletonParametri.DohvatiInstancu(datotekaParametra);

            //Generiranje slučajnog broja!
            int sjemeGeneratora = int.Parse(singletonParametri.DohvatiParametar("sjemeGeneratora"));
            SingletonGenSlucajnihBrojeva genSlucajnihBrojeva = SingletonGenSlucajnihBrojeva.DohvatiInstancu(sjemeGeneratora);
            int brojDecimala = int.Parse(singletonParametri.DohvatiParametar("brojDecimala"));

            //Inicijalizacija datoteke za logiranje izlaznih podataka


            //Citanje datoteke
            Citac citac = new Citac();
            string cijelaPutanjaUlice = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("ulice"));
            citac.UcitajUlice(citac.ProcitajDatoteku(cijelaPutanjaUlice));

            string cijelaPutanjaSpremnici = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("spremnici"));
            citac.UcitajSpremnike(citac.ProcitajDatoteku(cijelaPutanjaSpremnici));

            string cijelaPutanjaPodrucja = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("područja"));
            citac.UcitajPodrucja(citac.ProcitajDatoteku(cijelaPutanjaPodrucja));

            string cijelaPutanjaVozila = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("vozila"));
            citac.UcitajVozila(citac.ProcitajDatoteku(cijelaPutanjaVozila));

            string cijelaPutanjaDispecer = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("dispečer"));
            citac.UcitajDispecer(citac.ProcitajDatoteku(cijelaPutanjaDispecer));

            GeneriranjeSpremnikaOtpada.GeneriranjeSpremnika(citac);

            GeneriranjeSpremnikaOtpada.DodjelaOtpadaKorisnicima(singletonParametri, genSlucajnihBrojeva);

            //Generiranje otpada korisnicima

            Ispis.IspisKorisnikaOtpad();

            OdlaganjeOtpada.KorisniciOdlazuOtpad();

            Ispis.IspisSpremnikaPoUlicama();
            Ispis.IspisUlicaOtpad();



            DodjelaPodrucja.DodijeliPotpodrucja();

            Ispis.OtpadPoPodrucju();
            Ispis.DododajPodrucjaUUlice();
            Ispis.IspisOtpadaPoPodrucju();

            Odvoz.ProvediNaredbe();

            //ispis podrucja

            PonudaKontejnera.Ponuda();

            System.Console.ReadKey();

        }


    }

}
