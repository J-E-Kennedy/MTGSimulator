﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    abstract class Permanent : Card
    {
        //tapped , counters, etc


        public Permanent(string name, CardType type, Color color = Color.Colorless, Color identity = Color.Colorless, Supertype supertype = Supertype.None, 
            string[] subtypes = null, string artist = "", string number = "", string text = "", string set = "", Rarity rarity = Rarity.Common, 
            Keyword[] keywords = null, int multiverseId = 0, string imageUrl = "", Ruling[] rulings = null) 
            : base(name, type, color, identity, supertype, subtypes, artist, number, text, set, rarity, keywords, multiverseId, imageUrl, rulings)
        {
        }
    }
}