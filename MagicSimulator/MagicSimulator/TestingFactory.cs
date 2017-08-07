using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    static class TestingFactory
    {
        public static Creature CreateGrislyBear()
        {
            return new Creature("Grisly Bear", 2, 2, color: Color.Green, cost: "{1}{G}", subtypes: new string[] { "bear" });
        }

        public static Land CreateForest()
        {
            return new Land("Forest", produces: Color.Green, supertype: Supertype.Basic);
        }

        public static Deck GrizzlyDeck()
        {
            List<Card> cards = new List<Card>();
            for(int i = 0; i < 40; i++)
            {
                cards.Add(CreateGrislyBear());
            }
            for (int i = 0; i < 20; i++)
            {
                cards.Add(CreateForest());
            }
            return new Deck(cards);
        }


    }
}
