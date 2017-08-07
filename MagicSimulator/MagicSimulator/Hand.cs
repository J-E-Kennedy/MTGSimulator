using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }

    }
}
