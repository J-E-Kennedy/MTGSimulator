using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Graveyard
    {
        public List<Card> Cards { get; private set; }

        public Graveyard()
        {
            Cards = new List<Card>();
        }
    }
}
