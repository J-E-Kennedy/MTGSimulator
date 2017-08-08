using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Game testGame = new Game(
                new List<Player>()
                {
                    new Player("Jon", TestingFactory.GrizzlyDeck()),
                    new Player("Isaac", TestingFactory.GrizzlyDeck())
                }
                );
            testGame.Start();

            Console.ReadKey();
        }
    }
}
