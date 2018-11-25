using System;
using System.Collections.Generic;
using System.Text;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Composite
{
    public class Podrucje
    {
        public virtual string Name { get; set; } = "Grupa";

        public string Id { get; set; }

        private Lazy<List<Podrucje>> dijete = new Lazy<List<Podrucje>>();
        public List<Podrucje> Dijete => dijete.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(Id) ? string.Empty : $"{Id}")
              .Append(Name);

            foreach (var item in Dijete)
            {
                item.Print(sb, depth + 1);
            }

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }

    public class Podpodrucje : Podrucje
    {
        public override string Name => "Podpodrucje";
    }

    public class PUlica : Podrucje
    {
        public override string Name => "Ulica";
    }
}
