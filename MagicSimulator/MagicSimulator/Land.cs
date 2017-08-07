using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    class Land : Permanent
    {
        public Color Produces { get; }

        public Land(string name, CardType type = CardType.Land, Color color = Color.Colorless, Color identity = Color.Colorless, Color produces = Color.Colorless, 
            Supertype supertype = Supertype.None, string[] subtypes = null, string artist = "", string number = "", string text = "", string set = "", 
            Rarity rarity = Rarity.Common, Keyword[] keywords = null, int multiverseId = 0, string imageUrl = "", Ruling[] rulings = null)
            : base(name, type | CardType.Land, "{0}", color, identity, supertype, subtypes, artist, number, text, set, rarity, keywords, multiverseId, imageUrl, rulings)
        {
            Produces = produces;
        }
    }
}
