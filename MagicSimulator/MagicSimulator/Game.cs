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

        struct Mulligan
        {
            public Player Player;
            public int Cards;
            public bool Keep;

            public Mulligan(Player player, int cards, bool keep)
            {
                Player = player;
                Cards = cards;
                Keep = keep;
            }

        }

        public Game(List<Player> players)
        {
            Players = players;
        }

        public void Start()
        {
            //to implement decide starting player 

            foreach(var player in Players)
            {
                player.Draw(7);
            }

            var mulligans = Players.Select(x => new Mulligan(x, 7, false) ).ToArray();
            while(mulligans.Any(x => x.Keep = false))
            {
                for (int i = 0; i < mulligans.Length; i++)
                {
                    if(!mulligans[i].Keep)
                    {
                        switch (Choice("Keep", "Mulligan"))
                        {
                            case "Keep":
                                mulligans[i].Keep = true;
                                break;
                        }
                    }

                }
            }
            Play();
        }

        public void Play()
        {
            while(Players.Count(x => x.Alive) > 1)
            {
                foreach(Player player in Players)
                {
                    if(player.Alive)
                    {
                        PlayerActions(player);
                        player.BeginningPhase();
                    }
                }
            }
        }



        //currently for console
        public string Choice(params string[] choices)
        {
            int choice = -1;
            bool validChoice = false;
            do
            {
                Console.WriteLine("Type the number in front of the choice you want");
                for (int i = 0; i < choices.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {choices[i]}");
                }
                int.TryParse(Console.ReadLine(), out choice);
                validChoice = choice > 0 && choice <= choices.Length;
            } while (!validChoice);
            return choices[choice - 1];
        }

        public void PlayerActions(Player activePlayer)
        {
            Console.WriteLine("What do you want to do?");
            string response = Console.ReadLine();
            switch (response)
            {
                case "hand":
                    Console.WriteLine(activePlayer.ShowHand());
                    break;
            }
            Console.ReadKey();


        }




    }
}
