using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class ManaCost
    {
        int Generic;
        int White;
        int Blue;
        int Black;
        int Red;
        int Green;
        int Colorless;

        public ManaCost(int generic = 0, int white = 0, int blue = 0, int black = 0, int red = 0, int green = 0, int colorless = 0)
        {
            Generic = generic;
            White = white;
            Blue = blue;
            Black = black;
            Red = red;
            Green = green;
            Colorless = colorless;
        }

    }
}
