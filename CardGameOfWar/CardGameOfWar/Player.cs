using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameOfWar
{
    internal class Player
    {


        public string Name { get; set; }
        public List<Card> Hand { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }


        public void DrawCard( Deck deck)
        {
            Hand.Add(deck.DealOneCard());
        }

        public void ShowHand()
        {
            foreach (var card in Hand)
            {
                Console.WriteLine(Hand);
            }
        }
    }
}
