using System;
using System.Collections.Generic;

namespace dzunec_zadaca_2.Models
{

    public class Spremnik:VrstaSpremnik
    {
        public int Id { get; set; }

        public List<Korisnik> ListaKorisnika { get; set; } = new List<Korisnik>();

        public Spremnik()
        {
        }
    }
}
