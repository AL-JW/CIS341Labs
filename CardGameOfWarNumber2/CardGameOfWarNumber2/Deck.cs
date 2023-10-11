using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//So we will need to create a deck of cards, add cards to it, and shuffle them 
namespace CardGameOfWarNumber2
{
    internal class Deck
    {

        public List<Card> cards;

        public Deck()
        {

            cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit))) 
            {

                foreach (Value value in Enum.GetValues(typeof(Value)))
                {

                    cards.Add(new Card { CardSuit = suit, CardValue = value });

                }

            }

        }

        public void Shuffle()
        {

            var rng = new Random();
            cards = cards.OrderBy(a => rng.Next()).ToList();  //still unsure how this line of code really works


        }

        public Card DealOneCard()
        {

            if (cards.Count == 0) return null;

            Card cardToDeal = cards.First();

            cards.RemoveAt(0);

            return cardToDeal;

        }

    }
}
