using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{

    public class Spremnik : VrstaSpremnik
    {
        public int Id { get; set; }

        public float KolicinaOtpada { get; set; }

        public string Status { get; set; }

        public string PripadaUlici { get; set; }

        public List<KorisnikB> ListaKorisnika { get; set; } = new List<KorisnikB>();

        public Spremnik()
        {
        }

       
    }
    
}
