//APPLICATION GENERATING POKER HANDS RANDOMLY AND DISTRIBUTING IT TO DIFFERENT PLAYERS AND IDENTIFYING THE WINNING HANDS.
   
//Author: jeremie kipeleka S12795522
// Date: 23/11/2013
//File: Program.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfPlayers = 5;
            string PName;//variable for name of player
            int WinningScore = 0; // will hold the player score 
            string WinningName = ""; // will hold the winners name 
            string[] WinningCards = new string[5]; // willl hold the winning cards 
            string[] CardsGenerated = new string[5]; //the random cards that will be generated and distribute to each player 
            

            Hand[] PlayersHands = new Hand[NumberOfPlayers]; //playerhands of type Hands

            for (int n = 0; n < NumberOfPlayers; n++)

            // here im going to give each player a name and instatiate the hand of each player
            {
                Console.WriteLine("Please enter the name of the player {0} \n", n + 1);
                PName = Console.ReadLine();

                // this is the loop that will be used to intaite each player cards 

                string[] SetOfcards = new string[]
                    //these are all the 52 cards thats available 
        { "2S", "2S", "2S", "5S","10S"};//"6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS",

      //"AH", "2H","3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH",
        
      //"AC", "2C","3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC",

      //"AD", "2D","3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD" };

                string[] shuffle = CardsGenerator.shufflingCards(SetOfcards); // created an array thats being 
                // shufled by the card generator class

                //foreach (string s in shuffle)
                for (int i = 0; i < 5; i++)// this line will generate the 5 set of cards 
                {
                    for (int k = 0; k < 5; k++) //this is a nested loop that will be populating 
                    //the value of shuffle into the array of player 1
                    {
                        CardsGenerated[k] = shuffle[i];
                        //Console.WriteLine(Player1[k]);
                        i++;// were moving on to the next card
                    }

                    //  Console.ReadLine();


                    // Console.WriteLine(Player1[0]); // this line is temp just for me to check something will be deleted 
                    Console.WriteLine("\n");


                }


                // iniatiating the players hand class
                PlayersHands[n] = new Hand();
                //PlayersHands[n].CardsOnHands=Player1;// tryuing to coppy the elelemt of player1 to playersHands
                // CardsGenerated.CopyTo(PlayersHands[n].CardsOnHands,0); // this line is copying all the element of player1 array to the 

                PlayersHands[n].SetPlayerCardsOnHands(CardsGenerated); //seting the players cardsOnHands variable

                PlayersHands[n].SetPlayerName(PName);//calling a method to set the player name
                Console.WriteLine("{0}'s Hands Contain the folowing Cards:  {1} {2} {3} {4} {5} \n ", PlayersHands[n].GetPlayerName(), CardsGenerated[0], CardsGenerated[1], CardsGenerated[2], CardsGenerated[3], CardsGenerated[4]); // this line will print out the cards for each player 
            } // this is the loop that will be used to intaite each player cards 
     
            //   code below is used to display all the cards that is on the table 

            //foreach (var C in PlayersHands)
            //{
            //    C.GetCardsOnHands();
            //    Console.WriteLine("-");
            //}
            // this loop will report back to the user regarding each player hand
            for (int i = 0; i < 5; i++)
            {
                //PlayersHands[i].GetPlayerCardsOnHands().CopyTo(PlayersHands[i].Checker, 0);//we are coppying the player hands to the checker variable so we can do some work on it 
                //testing the player hands to determin which poker hand they got
                PlayersHands[i].SetChecker(PlayersHands[i].GetPlayerCardsOnHands());
                PlayersHands[i].HasPairs(PlayersHands[i].GetPlayerCardsOnHands());

                PlayersHands[i].IsStraight(PlayersHands[i].GetPlayerCardsOnHands());
                PlayersHands[i].ISFlush(PlayersHands[i].GetPlayerCardsOnHands());
                PlayersHands[i].IS3OfAkind(PlayersHands[i].GetPlayerCardsOnHands());
                PlayersHands[i].ISaFullHouse(PlayersHands[i].GetPlayerCardsOnHands());
                PlayersHands[i].ISFourOfAkind();
                PlayersHands[i].IsStraightFlush();
                PlayersHands[i].IsHighCards(PlayersHands[i].GetPlayerCardsOnHands());
                PlayersHands[i].IsRoyalFlush();

                //record the winning player and keep track of them

                if (PlayersHands[i].GetScore() >= WinningScore)
                {
                    WinningScore = PlayersHands[i].GetScore();

                    // retain a copy of the winning cards
                    PlayersHands[i].GetPlayerCardsOnHands().CopyTo(WinningCards, 0);
                    WinningName = PlayersHands[i].GetPlayerName();

                }

                //we need to determin the ending of the game displaying the winner 

                if (i == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("{0} is the winner of the game with the following cards [ {1} {2} {3} {4} {5} ]", WinningName, WinningCards[0], WinningCards[1], WinningCards[2], WinningCards[3], WinningCards[4]);


                }

                Console.ReadLine();

               
            }


        }//end of main 
    }//end of class Program 
}//end of Name Space
