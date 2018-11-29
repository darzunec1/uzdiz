using System.Collections.Generic;
using System.Linq;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;



namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class GeneriranjeSpremnikaOtpada
    {
        public GeneriranjeSpremnikaOtpada()
        {
        }

        internal static void GeneriranjeSpremnika(Citac citac)
        {
            List<Spremnik> listaSpremnikaMali = citac.GenerirajSpremnikeMali();
            List<Spremnik> listaSpremnikaSrednji = citac.GenerirajSpremnikeSrednji();
            List<Spremnik> listaSpremnikaVeliki = citac.GenerirajSpremnikeVeliki();

            Citac.ListaSvihSpremnika = listaSpremnikaMali.Concat(listaSpremnikaSrednji)
                                                       .Concat(listaSpremnikaVeliki)
                                                       .ToList();
        }

        internal static void DodjelaOtpadaKorisnicima(SingletonParametri singletonParametri, SingletonGenSlucajnihBrojeva genSlucajnihBrojeva)
        {
            DodjelaOtpada.DodijeliOtpadMalim(singletonParametri, genSlucajnihBrojeva);
            DodjelaOtpada.DodijeliOtpadSrednjim(singletonParametri, genSlucajnihBrojeva);
            DodjelaOtpada.DodijeliOtpadVelikim(singletonParametri, genSlucajnihBrojeva);

        }
    }
}
