namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.State
{
    public class State
    {
        public State()
        {
        }

        abstract class StateVozila
        {
            protected StateVozila stanjeVozila;

            public void PostavljanjeStateVozila(StateVozila stanje)
            {
                this.stanjeVozila = stanje;
            }

            public abstract void StanjeVozilaZahtjev(int request);
        }
    }
}
