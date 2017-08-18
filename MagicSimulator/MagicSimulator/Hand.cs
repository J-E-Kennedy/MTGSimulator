using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicSimulator.Enums;

namespace MagicSimulator
{
    public class Hand
    {
        public Player Controller {get;}
        public List<Card> Cards { get; private set; }

        public Hand(Player controller)
        {
            Controller = controller;
            Cards = new List<Card>();
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }

        public void Remove(Card card)
        {
            Cards.Remove(card);
        }

        public override string ToString()
        {
            StringBuilder hand = new StringBuilder();
            foreach(Card c in Cards)
            {
                hand.AppendLine(c.ToString());
            }
            return hand.ToString();
        }

        public List<Card> PlayableCards(Player turnPlayer,  Phase currentPhase)
        {
            var playableCards = new List<Card>();

            foreach(Card c in Cards)
            {
                if(c.Is(CardType.Instant))
                {
                    playableCards.Add(c);
                }
                else if(CanCastSorcerySpeed(turnPlayer, currentPhase))
                {
                    if(c.Is(CardType.Artifact) || c.Is(CardType.Creature) || c.Is(CardType.Enchantment) || c.Is(CardType.Sorcery))
                    {
                        playableCards.Add(c);
                    }
                    else if(c.Is(CardType.Land) && !Controller.HasPlayedLand)
                    {
                        playableCards.Add(c);
                    }
                }
            }
            return playableCards;
        }
        
        bool CanCastSorcerySpeed(Player turnPlayer, Phase currentPhase)
        {
            return TheStack.IsEmpty && turnPlayer == Controller && (currentPhase == Phase.PreCombatMain || currentPhase == Phase.PostCombatMain);
        }


        
        
    }
}
