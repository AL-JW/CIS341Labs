namespace CardGameOfWar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Initialize a card deck 

            Deck cardDeck = new Deck();

            cardDeck.Shuffle();


            //Player 1

            Player player1 = new Player("Alex");

            //Player 2
            Player player2 = new Player("Johnny");

            //Rounds to play

            int rounds = 10;


            for (int i = 0; i < rounds; i++)
            {
                Console.WriteLine($"Round {i + 1}:");


                player1.DrawCard(cardDeck);
                player2.DrawCard(cardDeck); 


                Card card1 = player1.Hand[player1.Hand.Count - 1];
                Card card2 = player2.Hand[player2.Hand.Count - 1];


                Console.WriteLine($"{player1.Name} drew {card1}");
                Console.WriteLine($"{player2.Name} drew {card2}");


                //compare cards and declare the winner

                if (card1.CardValue > card2.CardValue)
                {
                    Console.WriteLine($"{player1.Name} wins this round!\n");
                }

                else if (card1.CardValue < card2.CardValue)
                {
                    Console.WriteLine($"{player2.Name} wins this round!\n");
                }

                else
                {
                    Console.WriteLine("It's a tie!\n");
                }


                // End of game ( you can add more logic to declare the overall winner. 

                Console.WriteLine("Game Over!");


            }






            Console.WriteLine("Hello, World!");
        }
    }
}