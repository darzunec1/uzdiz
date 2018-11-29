using System;
namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Decorator
{
    public class Decorator
    {
        public interface IKamion
        {
            string DajOpis();
            double DajCijenu();
        }

        public Decorator()
        {
        }

        public abstract class KamionDecorator : IKamion
        {
            IKamion _kamion;

            protected string _ime = "Nedefinirano";
            protected double _cijena = 0.0;

            public KamionDecorator(IKamion kamion)
            {
                _kamion = kamion;
            }

            public string DajOpis()
            {
                return string.Format("{0}, {1}", _kamion.DajOpis(), _ime);
            }
            public double DajCijenu()
            {
                return _kamion.DajCijenu() + _cijena;
            }
        }
    }
}
