using System;
using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Decorator
{
    public class Decorator
    {
        public Decorator()
        {
        }

        public abstract class BazaKontejner
        {
            protected double mojaCijena;

            public virtual double DajCijenu()
            {
                return this.mojaCijena;
            }
        }

        public abstract class Kontejner : BazaKontejner
        {
            protected BazaKontejner kontejner;
            public Kontejner(BazaKontejner kontejnerDecorator)
            {
                this.kontejner = kontejnerDecorator;
            }

            public override double DajCijenu()
            {
                return (this.kontejner.DajCijenu() + this.mojaCijena);
            }
        }

        public class KontejnerNabava : BazaKontejner
        {
            public KontejnerNabava()
            {
                this.mojaCijena = 8687.99;
            }
        }

        public class Jamstvo5God : Kontejner
        {
            public Jamstvo5God(BazaKontejner kontejner) : base(kontejner)
            {
                this.mojaCijena = 900.32;
            }
        }

        public class Jamstvo10God : Kontejner
        {
            public Jamstvo10God(BazaKontejner kontejner) : base(kontejner)
            {
                this.mojaCijena = 1940.53;
            }
        }

        public class NoznoOtvaranje : Kontejner
        {
            public NoznoOtvaranje(BazaKontejner kontejner) : base(kontejner)
            {
                this.mojaCijena = 832.53;
            }
        }

        public class SenzorOtvaranje : Kontejner
        {
            public SenzorOtvaranje(BazaKontejner kontejner) : base(kontejner)
            {
                this.mojaCijena = 2590.53;
            }
        }

    }
}
