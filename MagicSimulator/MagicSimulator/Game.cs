using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Game
    {
        List<Player> Players;

        public Game(List<Player> players)
        {
            Players = players;
        }

        public void Start()
        {
            var mulligans = Players.Select(x => (player: x, cards: 7, keep: false));
            while(mulligans.Any(x => x.keep = false))
            {
                foreach(var person in mulligans.Where(x => x.keep == false))
                {
                    
                }
            }
        }
    }
}
