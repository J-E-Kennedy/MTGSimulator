using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    public class Game
    {
        static bool debugMode = true;
        
        List<Player> Players;
        Player activePlayer;
        Player currentTurnPlayer;
        Phase currentPhase;
        bool turnOneSingleplayer;

        List<Phase> turnStructure = new List<Phase>()
        {
            Phase.Untap,
            Phase.Upkeep,
            Phase.PreCombatMain,
            Phase.BeginningCombat,
            Phase.Attackers,
            Phase.Blockers,
            Phase.Damage,
            Phase.EndingCombat,
            Phase.PostCombatMain,
            Phase.End,
            Phase.Cleanup
        };

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

            turnOneSingleplayer = players.Count < 3;
        }

        public void Start()
        {
            //to implement decide starting player 

            foreach (var player in Players)
            {
                player.Draw(7);
            }

            var mulligans = Players.Select(x => new Mulligan(x, 7, false)).ToArray();
            while (mulligans.Any(x => x.Keep = false))
            {
                for (int i = 0; i < mulligans.Length; i++)
                {
                    if (!mulligans[i].Keep)
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
            currentPhase = Phase.Untap;
            Play();
        }

        public void Play()
        {
            while (Players.Count(x => x.Alive) > 1)
            {
                foreach (Player player in Players)
                {
                    if (player.Alive)
                    {
                        currentTurnPlayer = player;
                        activePlayer = player;
                        var priority = PriorityOrder(activePlayer);
                        foreach (Phase phase in turnStructure)
                        {
                            currentPhase = phase;
                            switch (phase)
                            {
                                case Phase.Untap:
                                    currentTurnPlayer.UntapStep();
                                    break;
                                case Phase.Upkeep:
                                    currentTurnPlayer.UpkeepStep();
                                    CyclePriority(currentTurnPlayer);
                                    break;
                                case Phase.Draw:
                                    if(turnOneSingleplayer)
                                    {
                                        turnOneSingleplayer = false;
                                    }
                                    else
                                    {
                                        currentTurnPlayer.Draw();
                                    }
                                    break;
                                case Phase.PreCombatMain:
                                    currentTurnPlayer.PrecombatMainPhase();
                                    CyclePriority(currentTurnPlayer);
                                    break;
                                case Phase.BeginningCombat:
                                    currentTurnPlayer.BeginningPhase();
                                    CyclePriority(currentTurnPlayer);
                                    break;
                                case Phase.Attackers:
                                    if(currentTurnPlayer.Attackers.Count > 0)
                                    {
                                        CyclePriority(currentTurnPlayer);
                                    }
                                    break;
                                case Phase.Blockers:
                                    if (currentTurnPlayer.Attackers.Count > 0)
                                    {
                                        CyclePriority(currentTurnPlayer);
                                    }
                                    break;
                                case Phase.Damage:
                                    if (currentTurnPlayer.Attackers.Count > 0)
                                    {
                                        CyclePriority(currentTurnPlayer);
                                    }
                                    break;
                                case Phase.EndingCombat:
                                    if (currentTurnPlayer.Attackers.Count > 0)
                                    {
                                        CyclePriority(currentTurnPlayer);
                                    }
                                    break;
                                case Phase.PostCombatMain:
                                    CyclePriority(currentTurnPlayer);
                                    break;
                                case Phase.End:
                                    CyclePriority(currentTurnPlayer);
                                    break;
                                case Phase.Cleanup:
                                    currentTurnPlayer.CleanupStep();
                                    break;
                            }

                        }



                        //PlayerActions(player);
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
            if(debugMode)
            {
                if(activePlayer.Name == "Isaac")
                {
                    return;
                }
            }

            Console.WriteLine($"{activePlayer.Name}, what do you want to do? (Phase: {currentTurnPlayer.Name}'s {currentPhase})");
            string response = Console.ReadLine();
            switch (response)
            {
                case "hand":
                    Console.WriteLine(activePlayer.ShowHand());
                    PlayerActions(activePlayer);
                    break;
                case "board":
                    Console.WriteLine(ShowAllPermanents());
                    PlayerActions(activePlayer);
                    break;
                case "deck":
                    Console.WriteLine(activePlayer.CheckDeck());
                    PlayerActions(activePlayer);
                    break;
                case "cast":
                    goto case "play";
                case "play":
                    //Console.WriteLine(activePlayer.ShowCastable(currentTurnPlayer, currentPhase));
                    var castable = activePlayer.GetPlayable(currentTurnPlayer, currentPhase);
                    if(castable.Count == 0)
                    {
                        Console.WriteLine("You have nothing to play!");
                        PlayerActions(activePlayer);
                    }
                    else
                    {
                        string backChoice = "wait go back please";
                        var choice = Choice(castable.Select(x => x.ToString()).Concat( new string[] { backChoice }).ToArray());
                        if(choice == backChoice)
                        {
                            PlayerActions(activePlayer);
                        }
                        else
                        {
                            activePlayer.Play(choice);
                            PlayerActions(activePlayer);
                        }
                    }
                    break;
                case "skip":
                    break;
                case "pass":
                    break;
                default:
                    Console.WriteLine("I don't understand");
                    PlayerActions(activePlayer);
                    break;
            }
            //Console.ReadKey();

        }

        public string ShowAllPermanents()
        {
            StringBuilder permanents = new StringBuilder();
            foreach(var player in Players)
            {
                permanents.Append($"{player.Name} controls:\n");
                permanents.Append(player.ShowPermanents());
            }
            return permanents.ToString();
        }

        List<Player> PriorityOrder(Player active)
        {
            List<Player> players = new List<Player>();
            int indexOfCurrent = Players.IndexOf(active);
            var playersBefore = Players.Take(indexOfCurrent);
            var playersAfter = Players.Skip(indexOfCurrent + 1);
            players.Add(currentTurnPlayer);
            players.AddRange(playersAfter);
            players.AddRange(playersBefore);
            return players;
        }



        void CyclePriority(Player active)
        {
            foreach(Player player in PriorityOrder(active))
            {
                PlayerActions(player);
            }
        }

        

    }
}
