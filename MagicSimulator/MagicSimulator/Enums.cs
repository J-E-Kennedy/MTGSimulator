using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    public static class Enums
    {
        [Flags]
        public enum Color
        {
            Colorless = 0,
            White = 1,
            Blue = 2 << 1,
            Black = 4,
            Red = 8,
            Green = 16,

            Azorius = White | Blue,
            //..etc

            Esper = White | Blue | Black,
            //..etc

        }
        [Flags]
        public enum Supertype
        {
            None = 0,
            Basic = 1,
            Legendary = 2,
            Snow = 4,
            World = 8,
            Ongoing = 16,//Archenemy
        }

        [Flags]
        public enum CardType// the name Type creates ambiguity with System.Type
        {
            Permanent = 1,
            Land = 2 + Permanent,
            Creature = 4 + Permanent,
            Artifact = 8 + Permanent,
            Instant = 16,
            Sorcery = 32,
            Enchantment = 64 + Permanent,
            Planeswalker = 128 + Permanent,
            Tribal = 256,
            Phenomenon = 512, // planechase
            Vanguard = 1024, // vanguard
            Scheme = 2048, // Archenemy
        }

        public enum Rarity
        {
            Common,
            Uncommon,
            Rare,
            MythicRare,
            Timeshifted,
            Special
        }

        public enum Phase
        {
            //Beginning Phase
            Untap,
            Upkeep,
            Draw,
            //Main 1
            PreCombatMain,
            //Combat Phase
            BeginningCombat,
            Attackers,
            Blockers,
            Damage,
            EndingCombat,
            //Main 2
            PostCombatMain,
            //End Phase
            End,
            Cleanup
        }
        


    }
}
