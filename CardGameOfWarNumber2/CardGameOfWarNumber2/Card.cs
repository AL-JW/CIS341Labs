using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameOfWarNumber2
{

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Value
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Jack, Queen, King, Ace
    }


    internal class Card
    {

        public Suit CardSuit { get; set; }
        public Value CardValue { get; set; }

        public override string ToString()
        {
            return $"{CardValue} of {CardSuit}";
        }


    }
}
