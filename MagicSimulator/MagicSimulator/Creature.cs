using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    class Creature : Permanent
    {
        public int Power { get; }
        public int Toughness { get; }
        //You don't need to specify card type creature
        public Creature(string name, int power, int toughness, CardType type = CardType.Creature, Color color = Color.Colorless, Color identity = Color.Colorless,
            Supertype supertype = Supertype.None, string[] subtypes = null, string artist = "", string number = "", string text = "", 
            string set = "", Rarity rarity = Rarity.Common, Keyword[] keywords = null, int multiverseId = 0, string imageUrl = "", Ruling[] rulings = null) 
            : base(name, type | CardType.Creature, color, identity, supertype, subtypes, artist, number, text, set, rarity, keywords, multiverseId, imageUrl, rulings)
        {
            Power = power;
            Toughness = toughness;
        }
    }
}
