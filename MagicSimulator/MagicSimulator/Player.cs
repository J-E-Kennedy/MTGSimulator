using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Player
    {
        int life;
        Deck deck;
        Hand hand;
        Graveyard graveyard;

        public bool Draw(int draws = 1)
        {
            while (draws > 0)
            {
                if (deck.IsEmpty)
                {
                    return false;
                }
                hand.Add(deck.Draw());
                draws--;
            }
            return true;
        }
    }



}
