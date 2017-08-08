using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    class Player
    {
        int Life;
        Deck Deck;
        Hand Hand;
        Graveyard Graveyard;
        Permanents Permanents;
        bool hasPlayedLand;
        public string Name { get; }
        public bool Alive { get; }

        public Player(string name, Deck deck, int life = 20)
        {
            Name = name;
            Deck = deck;
            Life = life;
            Hand = new Hand();
            Graveyard = new Graveyard();
            Permanents = new Permanents();
            hasPlayedLand = false;
            Alive = true;
        }


        public bool Draw(int draws = 1)
        {
            while (draws > 0)
            {
                if (Deck.IsEmpty)
                {
                    return false;
                }
                Hand.Add(Deck.Draw());
                draws--;
            }
            return true;
        }

        public string ShowHand()
        {
            return Hand.ToString();
        }

        public void UntapStep()
        {
            //do untap logic
            Permanents.UntapAll();
        }

        public void UpkeepStep()
        {
            //do whatever upkeep stuff;
        }

        public void DrawStep()
        {
            Draw(1);
        }

        public void BeginningPhase()
        {
            UntapStep();
            UpkeepStep();
            DrawStep();
        }

        public void PrecombatMainPhase()
        {

        }

        public void CombatPhase()
        {

        }

        public void PostcombatMainPhase()
        {

        }

        public void EndingPhase()
        {

        }

    }



}
