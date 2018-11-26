using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{

    public class Spremnik : VrstaSpremnik
    {
        public int Id { get; set; }

        public float KolicinaOtpada { get; set; }

        public List<Korisnik> ListaKorisnika { get; set; } = new List<Korisnik>();

        public Spremnik()
        {
        }

       
    }
    
}
