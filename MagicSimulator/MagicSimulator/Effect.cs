using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    public class Effect : ITargetable
    {
        public Card Card { get; }
        public List<ITargetable> Targets { get; }

        public Effect(Card card, List<ITargetable> targets = null)
        {
            Card = card;
            Targets = targets ?? new List<ITargetable>();
        }

    }
}
