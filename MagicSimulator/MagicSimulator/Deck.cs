using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    public class Deck
    {
        public bool IsEmpty => Cards.Count == 0;

        Stack<Card> Cards;
        Random Random;
        
        public Deck(List<Card> cards, Random random = null)
        {
            Cards = new Stack<Card>();
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
            throw new NotImplementedException();
        }

        public Card Draw()
        {
            if(IsEmpty)
            {
                return null;
            }
            return Cards.Pop();
        }

        public void Mulligan()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"There are {Cards.Count} cards left.";
        }

    }
}
