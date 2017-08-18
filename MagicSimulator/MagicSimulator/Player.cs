using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    public class Player : ITargetable
    {
        int Life;
        Deck Deck;
        public Hand Hand { get; }
        Graveyard Graveyard;
        Permanents Permanents;
        public bool HasPlayedLand;
        public string Name { get; }
        public bool Alive { get; }
        public List<Creature> Attackers { get; private set; }

        public Player(string name, Deck deck, int life = 20)
        {
            Name = name;
            Deck = deck;
            Life = life;
            Hand = new Hand(this);
            Graveyard = new Graveyard();
            Permanents = new Permanents();
            Attackers = new List<Creature>();
            HasPlayedLand = false;
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
            Attackers = new List<Creature>();
        }

        public void PostcombatMainPhase()
        {

        }

        public void EndingPhase()
        {

        }

        public void CleanupStep()
        {
            HasPlayedLand = false;
        }

        public string CheckDeck()
        {
            return Deck.ToString();
        }
        public string ShowPermanents()
        {
            return Permanents.ToString();
        }

        public string ShowPlayable(Player currentTurnPlayer, Phase currentPhase)
        {
            StringBuilder builder = new StringBuilder();
            foreach(Card c in Hand.PlayableCards(currentTurnPlayer, currentPhase))
            {
                builder.AppendLine(c.ToString());
            }
            if(builder.Length == 0)
            {
                return "You have no playable cards!";
            }
            return builder.ToString();
        }

        public List<Card> GetPlayable(Player currentTurnPlayer, Phase currentPhase)
        {
            return Hand.PlayableCards(currentTurnPlayer, currentPhase);
        }

        public void Play(string card)
        {
            var toPlay = Hand.Cards.FirstOrDefault(x => x.ToString() == card);
            if (toPlay == null)
            {
                throw new Exception("hand does not contain the given card (should not reach this point)");
            }
            if (toPlay.Is(CardType.Land))
            {
                if(!HasPlayedLand)
                {
                    HasPlayedLand = true;
                    Debug.WriteLine($"{Name} plays an {toPlay.Name}");
                    Hand.Remove(toPlay);
                    Permanents.Add(toPlay as Permanent);
                }
            }
            else
            {
                Debug.WriteLine ($"{Name} casts an {toPlay.Name}");
                Cast(toPlay);
            }
        }

        public void Cast(Card card)
        {
            //To implement: Choose targets here
            Hand.Remove(card);
            TheStack.Add(this, card);
        }

        public void AddPermanent(Permanent card)
        {
            Permanents.Add(card);
        }

        public void PayCosts(Card card)
        {
            var cost = card.Cost;
            while(cost > 0)
        }

    }



}
