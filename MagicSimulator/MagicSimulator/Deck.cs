using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Deck
    {
        Stack<Card> Cards;
        Random Random;
        public Deck(List<Card> cards, Random random = null)
        {
            Random = random ?? new Random();
            while(cards.Count > 0)
            {
                int randomIndex = Random.Next(cards.Count);
                Cards.Push(cards[randomIndex]);
                cards.RemoveAt(randomIndex);
            }
        }

        public void Shuffle()
        {
            throw new NotImplementedException;
        }

    }
}
