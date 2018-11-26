using System;
namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    class DodjelaOtpada
    {
        public static void DodijeliOtpadMalim(SingletonParametri singletonParametri, SingletonGenSlucajnihBrojeva genSlucajnihBrojeva)
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaMalihKorisnika)
                {
                    double maliMinS = double.Parse(singletonParametri.DohvatiParametar("maliStaklo"));
                    double maliMaxS = double.Parse(singletonParametri.DohvatiParametar("maliStaklo")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Staklo = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinS, maliMaxS, 2);

                    double maliMinP = double.Parse(singletonParametri.DohvatiParametar("maliPapir"));
                    double maliMaxP = double.Parse(singletonParametri.DohvatiParametar("maliPapir")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Papir = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinP, maliMaxP, 2);

                    double maliMinM = double.Parse(singletonParametri.DohvatiParametar("maliMetal"));
                    double maliMaxM = double.Parse(singletonParametri.DohvatiParametar("maliMetal")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Metal = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinM, maliMaxM, 2);

                    double maliMinB = double.Parse(singletonParametri.DohvatiParametar("maliBio"));
                    double maliMaxB = double.Parse(singletonParametri.DohvatiParametar("maliBio")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Bio = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinB, maliMaxB, 2);

                    double maliMinMj = double.Parse(singletonParametri.DohvatiParametar("maliMješano"));
                    double maliMaxMj = double.Parse(singletonParametri.DohvatiParametar("maliMješano")) * double.Parse(singletonParametri.DohvatiParametar("maliMin")) / 100;
                    korisnik.Mjesano = genSlucajnihBrojeva.SlucajniBrojFloat(maliMinMj, maliMaxMj, 2);

                }

            }

        }

        public static void DodijeliOtpadSrednjim(SingletonParametri singletonParametri, SingletonGenSlucajnihBrojeva genSlucajnihBrojeva)
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaSrednjihKorisnika)
                {
                    double srednjiMinS = double.Parse(singletonParametri.DohvatiParametar("srednjiStaklo"));
                    double srednjiMaxS = double.Parse(singletonParametri.DohvatiParametar("srednjiStaklo")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Staklo = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinS, srednjiMaxS, 2);

                    double srednjiMinP = double.Parse(singletonParametri.DohvatiParametar("srednjiPapir"));
                    double srednjiMaxP = double.Parse(singletonParametri.DohvatiParametar("srednjiPapir")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Papir = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinP, srednjiMaxP, 2);

                    double srednjiMinM = double.Parse(singletonParametri.DohvatiParametar("srednjiMetal"));
                    double srednjiMaxM = double.Parse(singletonParametri.DohvatiParametar("srednjiMetal")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Metal = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinM, srednjiMaxM, 2);

                    double srednjiMinB = double.Parse(singletonParametri.DohvatiParametar("srednjiBio"));
                    double srednjiMaxB = double.Parse(singletonParametri.DohvatiParametar("srednjiBio")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Bio = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinB, srednjiMaxB, 2);

                    double srednjiMinMj = double.Parse(singletonParametri.DohvatiParametar("srednjiMješano"));
                    double srednjiMaxMj = double.Parse(singletonParametri.DohvatiParametar("srednjiMješano")) * double.Parse(singletonParametri.DohvatiParametar("srednjiMin")) / 100;
                    korisnik.Mjesano = genSlucajnihBrojeva.SlucajniBrojFloat(srednjiMinMj, srednjiMaxMj, 2);

                }

            }

        }

        public static void DodijeliOtpadVelikim(SingletonParametri singletonParametri, SingletonGenSlucajnihBrojeva genSlucajnihBrojeva)
        {
            foreach (var ulica in Citac.ListaUlica)
            {
                foreach (var korisnik in ulica.ListaVelikihKorisnika)
                {
                    double velikiMinS = double.Parse(singletonParametri.DohvatiParametar("velikiStaklo"));
                    double velikiMaxS = double.Parse(singletonParametri.DohvatiParametar("velikiStaklo")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Staklo = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinS, velikiMaxS, 2);

                    double velikiMinP = double.Parse(singletonParametri.DohvatiParametar("velikiPapir"));
                    double velikiMaxP = double.Parse(singletonParametri.DohvatiParametar("velikiPapir")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Papir = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinP, velikiMaxP, 2);

                    double velikiMinM = double.Parse(singletonParametri.DohvatiParametar("velikiMetal"));
                    double velikiMaxM = double.Parse(singletonParametri.DohvatiParametar("velikiMetal")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Metal = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinM, velikiMaxM, 2);

                    double velikiMinB = double.Parse(singletonParametri.DohvatiParametar("velikiBio"));
                    double velikiMaxB = double.Parse(singletonParametri.DohvatiParametar("velikiBio")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Bio = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinB, velikiMaxB, 2);

                    double velikiMinMj = double.Parse(singletonParametri.DohvatiParametar("velikiMješano"));
                    double velikiMaxMj = double.Parse(singletonParametri.DohvatiParametar("velikiMješano")) * double.Parse(singletonParametri.DohvatiParametar("velikiMin")) / 100;
                    korisnik.Mjesano = genSlucajnihBrojeva.SlucajniBrojFloat(velikiMinMj, velikiMaxMj, 2);

                }

            }

        }


    }
}
