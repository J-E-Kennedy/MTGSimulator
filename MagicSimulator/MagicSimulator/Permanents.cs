using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Permanents
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

    }
}
