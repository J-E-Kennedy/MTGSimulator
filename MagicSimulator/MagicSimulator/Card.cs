using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    abstract class Card
    {
        public string Name { get; }
        //for flip cards?
        public string[] Names { get; }

        public Color Color { get; }
        public Color Identity { get; }

        public ManaCost Cost { get; }

        public Supertype Supertype { get; }
        public CardType CardType { get; }// to be set by child classes
        public string[] Subtypes { get; }//too many to be implemented as an enum like the others

        public string Artist { get; }
        public string Number { get; }
        public string Text { get; }


        public string Set { get; }

        public Rarity Rarity { get; }

        public Keyword[] Keywords { get; }

        //layout, could break into seprate abtracts? double-faced etc..

        public int MultiverseID { get; }//what is this

        public string ImageUrl;//how should this be implemented?

        public Ruling[] Rulings { get; }

        //the following types are available but not implemented
        //id, variations, watermark, border, timeshifted (implemented as a rarity), hand (for vanguard), reserved, releaseDate (for promos), starter 
        //foreignNames, printings, originalText, originalType, legalities, source

        public Card(string name, CardType type, string cost = "{0}", Color color = Color.Colorless, Color identity = Color.Colorless, Supertype supertype = Supertype.None,
             string[] subtypes = null, string artist = "", string number = "", string text = "", string set = "", Rarity rarity = Rarity.Common, 
             Keyword[] keywords = null, int multiverseId = 0, string imageUrl = "", Ruling[] rulings = null)
        {
            Name = name;
            Cost = new ManaCost(cost);
            CardType = type;
            Color = color;
            Identity = identity;
            Supertype = supertype;
            Subtypes = subtypes ?? new string[0];
            Artist = artist;
            Number = number;
            Text = text;
            Set = set;
            Rarity = rarity;
            Keywords = keywords ?? new Keyword[0];
            MultiverseID = multiverseId;
            ImageUrl = imageUrl;
            Rulings = rulings ?? new Ruling[0];
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
