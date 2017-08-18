using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSimulator
{
    public static class TheStack
    {
        static Stack<Effect> GameStack = new Stack<Effect>();

        static Game ActiveGame;
        public static int Count => GameStack.Count;

        public static bool IsEmpty => Count == 0;

        public static void SetActiveGame(Game game)
        {
            ActiveGame = game;
        }

        public static void Add(Player controller, Card card, List<ITargetable> targets = null)
        {
            var effect = new Effect(controller, card, targets);
            GameStack.Push(effect);
        }

        public static void Resolve()
        {
            if(!IsEmpty)
            {
                var currentEffect = GameStack.Pop();
                currentEffect.Resolve();
            }
        }
            
    }
}
