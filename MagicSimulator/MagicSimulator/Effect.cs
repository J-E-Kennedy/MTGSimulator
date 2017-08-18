using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    public class Effect : ITargetable
    {
        public Player Controller { get; }
        public Card Card { get; }
        public List<ITargetable> Targets { get; }

        public Effect(Player controller, Card card, List<ITargetable> targets = null)
        {
            Controller = controller;
            Card = card;
            Targets = targets ?? new List<ITargetable>();
        }

        public void Resolve()
        {
            if(Card.Is(CardType.Permanent))
            {
                Controller.AddPermanent(Card as Permanent);
            }
        }

    }
}
