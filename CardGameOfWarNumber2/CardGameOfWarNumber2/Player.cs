using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameOfWarNumber2
{
    internal class Player
    {
        public string Name {  get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public Card PlayCard()
        {
            if (Hand.Count == 0) return null;

            Card cardToPlay = Hand.First();
            Hand.RemoveAt(0);
            return cardToPlay;
        }

        public void AddCardsToBottom(params Card[] cards)
        {
            Hand.AddRange(cards);
        }


    }
}
