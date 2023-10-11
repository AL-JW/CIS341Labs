namespace CardGameOfWarNumber2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck();
            deck.Shuffle();


            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            //Distribute the cards

            while (deck.cards.Count > 0)

            {
                player1.AddCardsToBottom(deck.DealOneCard());
                player2.AddCardsToBottom(deck.DealOneCard());
            }

            //Play the game

            while (player1.Hand.Count > 0 && player2.Hand.Count > 0)
            {
                Card player1Card = player1.PlayCard();
                Card player2Card = player2.PlayCard();


                Console.WriteLine($"{player1.Name} plays {player1Card}, {player2.Name} plays {player2Card}");

                if (player1Card.CardValue > player2Card.CardValue) 
                {

                    player1.AddCardsToBottom(player1Card, player2Card);
                
                }

                else if (player1Card.CardValue < player2Card.CardValue)
                {
                    player2.AddCardsToBottom(player2Card, player1Card);
                }
                else
                {
                    //War logic goes here

                    Console.WriteLine("War!");


                    List<Card> warCards = new List<Card>() { player1Card, player2Card };

                    bool warEnded = false;

                   
                    while (!warEnded && player1.Hand.Count > 2 && player2.Hand.Count > 2)
                    {
                        //Each player places three cards face-down 
                        for (int i = 0; i < 3; i++)
                        {
                            warCards.Add(player1.PlayCard());
                            warCards.Add(player2.PlayCard());
                        }

                        //Then one card face-up

                        Card player1WarCard = player1.PlayCard();
                        Card player2WarCard = player2.PlayCard();


                        Console.WriteLine($"{player1.Name} plays {player1WarCard}, {player2.Name} plays {player2WarCard}");

                        if (player1WarCard.CardValue > player2WarCard.CardValue)
                        {
                            player1.AddCardsToBottom(warCards.ToArray());
                            warEnded = true;
                        }

                        else if (player1WarCard.CardValue < player2WarCard.CardValue)
                        {
                            player2.AddCardsToBottom(warCards.ToArray());
                            warEnded = true;
                        }

                    }

                    //IN case a player doesn't have enough cards for another war

                    if (!warEnded)
                    {
                        if (player1.Hand.Count < player2.Hand.Count)
                        {
                            player2.AddCardsToBottom(warCards.ToArray());
                        }
                        else
                        {
                            player1.AddCardsToBottom();
                        }
                    }


                    if (player1Card.CardValue == player2Card.CardValue)
                    {
                        player1.PlayCard();
                        player2.PlayCard();
                        continue;
                    }
                }
            }

            if (player1.Hand.Count == 0)
            {
                Console.WriteLine($"{player2.Name} wins!");
            }

            else
            {
                Console.WriteLine($"{player1.Name} wins!");
            }



            Console.WriteLine("Hello, World!");
        }
    }
}


// So we need a player class, a card class, a deck class, and 