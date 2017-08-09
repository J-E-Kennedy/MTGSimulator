using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    public class Permanents
    {
        List<Permanent> ControlledPermanents;

        public Permanents(List<Permanent> permanents = null)
        {
            ControlledPermanents = permanents ?? new List<Permanent>();
        }

        public void UntapAll()
        {
            foreach (var permanent in ControlledPermanents)
            {
                permanent.Untap();
            }
        }

        public override string ToString()
        {
            string permanents = "";
            foreach(var permanent in ControlledPermanents)
            {
                permanents += permanent.ToString() + "\n";
            }
            return permanents;
        }

        public void Add(Permanent permanent)
        {
            ControlledPermanents.Add(permanent);
        }

    }
}
