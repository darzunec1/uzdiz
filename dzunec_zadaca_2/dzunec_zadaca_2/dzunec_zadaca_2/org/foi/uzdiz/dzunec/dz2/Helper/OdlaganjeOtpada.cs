using System;
namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class OdlaganjeOtpada
    {
        public OdlaganjeOtpada()
        {
        }

        public static void KorisniciOdlazuOtpad()
        {
            //Korisnici stavljaju otpad u spremnike
            foreach (var spremnik in Citac.ListaSvihSpremnika)
            {

                if (spremnik.Naziv == "staklo")
                {
                    float dostupnoStaklo = spremnik.Nosivost - spremnik.KolicinaOtpada;
                    foreach (var korisnik in spremnik.ListaKorisnika)
                    {
                        if (dostupnoStaklo > korisnik.Staklo)
                        {
                            spremnik.KolicinaOtpada += korisnik.Staklo;
                            korisnik.Staklo = 0;
                        }
                        else
                        {
                            spremnik.KolicinaOtpada = spremnik.Nosivost;
                            korisnik.Staklo = korisnik.Staklo - dostupnoStaklo;
                            Console.WriteLine("Spremnik " + spremnik.Id + " je puni!");
                        }
                    }
                }

                else if (spremnik.Naziv == "papir")
                {
                    float dostupnoPapir = spremnik.Nosivost - spremnik.KolicinaOtpada;

                    foreach (var korisnik in spremnik.ListaKorisnika)
                    {
                        if (dostupnoPapir > korisnik.Papir)
                        {
                            spremnik.KolicinaOtpada += korisnik.Papir;
                            korisnik.Papir = 0;
                        }
                        else
                        {
                            spremnik.KolicinaOtpada = spremnik.Nosivost;
                            korisnik.Papir = korisnik.Papir - dostupnoPapir;
                            Console.WriteLine("Spremnik " + spremnik.Id + " je puni!");
                        }
                    }
                }

                else if (spremnik.Naziv == "metal")
                {
                    float dostupnoMetal = spremnik.Nosivost - spremnik.KolicinaOtpada;
                    foreach (var korisnik in spremnik.ListaKorisnika)
                    {
                        if (dostupnoMetal > korisnik.Metal)
                        {
                            spremnik.KolicinaOtpada += korisnik.Metal;
                            korisnik.Metal = 0;
                        }
                        else
                        {
                            spremnik.KolicinaOtpada = spremnik.Nosivost;
                            korisnik.Metal = korisnik.Metal - dostupnoMetal;
                            Console.WriteLine("Spremnik " + spremnik.Id + " je puni!");
                        }

                    }
                }
                else if (spremnik.Naziv == "bio")
                {
                    float dostupnoBio = spremnik.Nosivost - spremnik.KolicinaOtpada;
                    foreach (var korisnik in spremnik.ListaKorisnika)
                    {
                        if (dostupnoBio > korisnik.Bio)
                        {
                            spremnik.KolicinaOtpada += korisnik.Bio;
                            korisnik.Bio = 0;
                        }
                        else
                        {
                            spremnik.KolicinaOtpada = spremnik.Nosivost;
                            korisnik.Bio = korisnik.Bio - dostupnoBio;
                            Console.WriteLine("Spremnik " + spremnik.Id + " je puni!");
                        }
                    }
                }
                else if (spremnik.Naziv == "mješano")
                {
                    float dostupnoMjesano = spremnik.Nosivost - spremnik.KolicinaOtpada;
                    foreach (var korisnik in spremnik.ListaKorisnika)
                    {
                        if (dostupnoMjesano > korisnik.Mjesano)
                        {
                            spremnik.KolicinaOtpada += korisnik.Mjesano;
                            korisnik.Mjesano = 0;
                        }
                        else
                        {
                            spremnik.KolicinaOtpada = spremnik.Nosivost;
                            korisnik.Mjesano = korisnik.Mjesano - dostupnoMjesano;
                            Console.WriteLine("Spremnik " + spremnik.Id + " je puni!");
                        }

                    }
                }

            }
        }

    }
}
