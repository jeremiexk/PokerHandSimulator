//APPLICATION GENERATING POKER HANDS RANDOMLY AND DISTRIBUTING IT TO DIFFERENT PLAYERS AND IDENTIFYING THE WINNING HANDS.
//This is the Hand class of my poker application it will contain all the usefull data and methods needed for the player 
// Object of my application  
//Author: jeremie kipeleka S12795522
// Date: 23/11/2013
//File: Hand.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsApp
{
    class Hand
    {

        //    *** variables that will be used to manipulate the players Cards *** 

        private int fullhouseMark = 0; // this variable will be used as a marker to determin if the player cards is a full house or not 
        private int FourOfaKindMark = 0; // this variable will be used as a marker to determin if the player cards is of Four of a Kind or not 
        private int StraighFlushMark = 0; // this variable will be used as a marker to determin if the player cards has a straight flush or not 
        private int RoyalFlushMark = 0; // this variable will be used as a marker to determin if the player cards Has a royal Flush or not  
        //the following arrays i will use to compare agains the player cards to determin if the have higher cards
        // and if so which category of High cards The players cards Belongs too
        private int[] HighCardsLower = new int[5] { 8, 9, 10, 11, 12 }; // High cards Grade 3
        private int[] HighCardsMedium = new int[5] { 9, 10, 11, 12, 13 };  // High cards Grade 2
        private int[] HighCardStrong = new int[5] { 10, 11, 12, 13, 14 }; // High Cards Grade 1
        private int HightCardsPoint = 0; // will determin who has the Highest High cards
        private int pair = 0; // will hold the numbers of pairs the players cards Contains
        private string Q; // will be used to temporaraly hold string arrays values before it foward its value to another variable

        //    *** Variable that will be used to manipulate the players details ***

        private int PlayerScore = 0; 
        private string playerName;       
        private string[] CardsOnHands = new string[5]; // this is the number of cards that each playyer will recieve 
        private string[] Checker = new String[5]; //i will be coppying the strings on the card on this variable so i dont permanatly mess up the original card on hand variable because it will use it refference and change data
        private int[] StraightCardsArray = new int[5]; // the int array that will hold the flush card array 
        private int StraightCounter = 0;

        //constructor for class hands
        public Hand() { }
        
       // method to Set The Player name
        public void SetPlayerName(string x)
        { //method of setting the player name
            playerName = x;
        } 

       // getting the player score
         public int GetScore() 
        {
             return this.PlayerScore; // a return method that get the player score 
        } // END of Get score method      

        // Method that Gets the player Name 
        public string GetPlayerName()
        {
            return playerName;
        }
               
        //method to set players cards 

        public void SetPlayerCardsOnHands(string[] Cards)
        {
            //we coppy the value of Cards to the cardsOn Hands Variable
            Cards.CopyTo(this.CardsOnHands, 0);           
        }

        //method to get Cards on Hands of the player

        public string[] GetPlayerCardsOnHands()
        {
            return this.CardsOnHands;
        }

        //Method to set checker 
        public void SetChecker(string[] C)
        {
            this.Checker = C;
        }

        //method to get Checker

        public string[] GetChecker()
        {
            return this.Checker;
        }

 

        
//*************************************CARDS*ANALYSER*METHODS*****************************************************

          // in this section lies all the method that will be analysing the player Poker Hands

        //method to count the number of pairs in the player cards on Hands

        public void HasPairs(string[] IsP)
        {
            string[] HasPairsCardHolder = new string[5];

            IsP.CopyTo(HasPairsCardHolder, 0);

            //now im we are going to remove the suit of each card to leave us with just the cards ranks
            //and then count the number of times the item has appear in the array 
            //if the item has appear more than once but less than 4 then its a pair 
            // if the item appear 4 times or More then we have 2 pair

            for (int i = 0; i < 5; i++)
            {  //removing the suit loop

                Q = HasPairsCardHolder[i].Remove(HasPairsCardHolder[i].Length - 1); // this will renove the last character of each aray value
                HasPairsCardHolder[i] = Q;
            }//end of removing suit looop

            //counting the number of item to determin the number of pair the item has 
            var CountingPairs = HasPairsCardHolder.GroupBy(v => v); // im using the enumerator to Groups the number of time each element has appear whith the players hand.
            foreach (var count in CountingPairs)
            { //counting the number of time an item has appear loop
                if (count.Count() > 1 && count.Count() < 4) { pair = pair + 1; PlayerScore = 4; }; // if the count variable whith the hand player is = to 2 or 3 then it the player hands has ONE pair
                if (count.Count() >= 4) { pair = pair + 2; FourOfaKindMark = FourOfaKindMark + 1; PlayerScore = 5; };  // if the count variable whith the hand player is = to 4 or 5 then the player hands has has TWO pair

                Console.WriteLine("Value {0} has {1} items", count.Key, count.Count());//**note to self***** this line need to deleted once testing is over
            }
            
            //Console.WriteLine("Value {0} has {1} items", count.Key, count.Count());

            Console.WriteLine("{0}'Cards [ {1}, {2}, {3}, {4}, {5} ] has {6} pairs", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4], pair);

        }// end of is Has pair method

        //Method to Analyse the player Cards On hand to spot if their cards Contains a 3 of a Kind
        public void IS3OfAkind(string[] aKIND)
        {
            string[] IS3OfAkindCardsHolder = new string[5];// the variable that will hold the 3of a kind 

          // we are copying the user cast array to a NEW refference so it doesn't chnage the original value of akind[]
            aKIND.CopyTo(IS3OfAkindCardsHolder, 0);
          // suit removal loop
            for (int i = 0; i < 5; i++)
            { //we are removing all the suit of the array 
                Q = IS3OfAkindCardsHolder[i].Remove(IS3OfAkindCardsHolder[i].Length - 1); 
                IS3OfAkindCardsHolder[i] = Q;
            }//end of removing suit looop


            int Result_ThreeOf_A_Kind = 0; //variable to determin if the player cards contain 3 of a Kind
            // here we are cheking if the player has a 3 of a kind  
            var CountingPairs = IS3OfAkindCardsHolder.GroupBy(v => v); // im using the enumerator to Groups the number of time each element has appear whith the players hand.
            foreach (var count in CountingPairs)
            {
                //if the the cards has appear 3 times or more then the player hands contain a 3 Of a Kind
                if (count.Count() >= 3)
                {
                    Result_ThreeOf_A_Kind = Result_ThreeOf_A_Kind + 1; //so we add 1 to this variable

                    //because having a fullHouse in poker will require to have 3 of a kind so 
                    //in the FullhouseMark we add 1 
                    fullhouseMark = fullhouseMark + 1;
                    //my scoring system 
                    //if player has a 3 of a kind the their score is 6
                    PlayerScore = 6;
                }

                //Console.WriteLine("Value {0} has {1} items", count.Key, count.Count());
            }//end of counting loop

            if (Result_ThreeOf_A_Kind >= 1)
            {  // if player Result_ThreeOf_A_kind is greter than 0 then they Do have 3 of a kind
              //so a message is displayed 
                
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] Does HAVE  A 3 of a Kind", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

            else if (Result_ThreeOf_A_Kind == 0)
            {
                //if player Result_ThreeOf_A_Kind variable is 0 then they do not have a 3 of a Kind
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] Does  NOT HAVE  A 3 of a Kind", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }
           
        }// end of is 3 of a kind Analyser Method


        // Method checking for a straight 
        // First we will subtitute the value of J Q K and place it with 11, 12, 13,
        // then convert the string array to int array 
        // then were going to SORT the array in order 
        // then test if the number are going up in 1 then it is a flush 
        // so we return the flush result
        public void IsStraight(string[] S)
        {
            //declaire the string array that will hold the clone of the player cards on hand
            string[] IsStraightCardHolder = new string[5]; 

            S.CopyTo(IsStraightCardHolder, 0); //we then copy the S[] to the is straight cardHolder 
            //so whatever changes we make to the IsStraightcardHolder won't affect the ORIGINAL array of the Player
            // because the array is coppied to a New reference In memory

            for (int i = 0; i < 5; i++)
            {  //suit removal loop
                Q = IsStraightCardHolder[i].Remove(IsStraightCardHolder[i].Length - 1); //we are removing all the suit of the array 
                IsStraightCardHolder[i] = Q;
            }//end of removing suit looop

            //then we proceed to the subtitution stage 
            //replacing the J Q K A with 11, 12, 13, 1
            IsStraightCardHolder = IsStraightCardHolder.Select(s => s.Replace("J", "11")).ToArray();
            IsStraightCardHolder = IsStraightCardHolder.Select(s => s.Replace("Q", "12")).ToArray();
            IsStraightCardHolder = IsStraightCardHolder.Select(s => s.Replace("K", "13")).ToArray();
            IsStraightCardHolder = IsStraightCardHolder.Select(s => s.Replace("A", "1")).ToArray();

            Console.WriteLine(); //giving white space for clarity viewings

            // After subtituting the array element with their coresponding numbers 
            // we then convert the array first into an interger type array
            int[] StraightCardsArray = IsStraightCardHolder.Select(x => int.Parse(x)).ToArray();
            
            // AFTER The convertion into the int array 
            // Now we can proceed and sort out the array in order

            Array.Sort(StraightCardsArray);
            
            // now we must place the condition that will spot that the array is a flush 
            //this is the condition

            //this algorithm is a nested loop 
            //and is looking to spot a pattern  
            // we first look at the value of the array index [0]
            //then we add 1 to the value of array[0] cast it to a NEW variable "calcul"
            // if the array [1] is equal to the value of calcul
            // that would mean the array is going up by 1
            // then we add 1 to the straight counter 
            // we then do the same for the next array 
            //untill the straight counter is == 4 
            // then we know that the counter is going up by one for all the value of the array 
            // if that so we have a flush
            for (int x = 0; x < 5; x++)
            {

                for (int z = 1; z < 5; z++)
                {
                    int calcul = 0; //the variable that will hold the array value +1
                    calcul = StraightCardsArray[x] + 1;
                    if (calcul.Equals(StraightCardsArray[z]))
                    { // now if the value of the next array is = to calcul then we know it is incrementing by 1
                        StraightCounter = StraightCounter + 1;
                        calcul = 0;
                    }
                }

            } // END of Straight condition analyser

            // what to display when the computer has found the straight
            if (StraightCounter == 4)
            {
                StraighFlushMark = StraighFlushMark + 1;// ad add one to the straight flush mark
                PlayerScore = 7; // in my scoring system a straight has a value of 7
                // we then display a message on screen 
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] Does HAVE  A Straight", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

            else if (StraightCounter != 4)//if the counter is not 4 then we don't have a straight
            { 
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] does NOT HAVE  A Straight", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]); 
            }
            
        } // END of is Straight Analyser


        //Method to check if the Player cards on hand is A flush (i.e. five cards of the same suit)

        public void ISFlush(string[] IsF)
        {
            string[] IsFlushCardHolder = new string[5]; // the array that we will manipulate on this method

            IsF.CopyTo(IsFlushCardHolder, 0); //pass the value of ISf array to a new reference location of IsFlushCardsHolder

            //now we are removing the numbers and ranks of each card to leave us with just the suits of the cards 
            for (int i = 0; i < 5; i++)
            {
                //if the length of the flush card holder is 3 then we remove the first and second character leaving us with just the suit alone
                if (IsFlushCardHolder[i].Length == 3)
                {
                    Q = IsFlushCardHolder[i].Remove(0, 2);

                    IsFlushCardHolder[i] = Q;

                    continue; // this will skip the current itteration
                }

                //if the length of the flush card holder is 2 the we remove the first character leaving us with the suit alone
                if (IsFlushCardHolder[i].Length == 2)
                {
                    Q = IsFlushCardHolder[i].Remove(0, 1); //we are removing all the ranks of the array so i can compare for flush 
                    IsFlushCardHolder[i] = Q;
                }

            }//end of removing ranks looop


            int Resultflush = 0;//variable that will determine the flush result

            //counting the number of item to determine the number of suits
            var CountingSuits = IsFlushCardHolder.GroupBy(v => v); // im using the enumerator to Groups the number of time each element has appear whith the players hand.
            foreach (var Suits in CountingSuits) //count is the variable that  will represent a suit  
            {   
                // if the suit count is 5 then we have a flush
                if (Suits.Count() == 5)
                {
                    Resultflush = Resultflush + 1;//we add 1 to the result flush 
                    // we add 1 to the straight flush mark
                    // because Straight Flush will require the cards to be a flush and a straight
                    StraighFlushMark = StraighFlushMark + 1; 
                    //we add 1 to the royal flush mark
                    // because Royal Flush Will require The cards to include a Flush
                    RoyalFlushMark = RoyalFlushMark + 1; 
                    //my scoring system a Flush has a value of 8;
                    PlayerScore = 8;
                };                
            } // END of counting suit loop

            

            if (Resultflush == 1) 
            {  // if the resultflush variable is = 1 then the player cards on cards does contain a flush 
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] does Have a Flush", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]); 
            }

            
            else if (Resultflush == 0)
            { // if the resultflush variable is not = 1 then the player cards does not contain a flush
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] does Not Have a Flush", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

        }//end of is a flush Method Analyser 

// Method to check if the player cards on hand is a Full House ( i.e i.e. three cards of the same rank with apair of cards of another rank )        
                      
        public void ISaFullHouse(string[] IsFull)
        {
            // a full house consist of a 3of a kind an a pair 

            string[] ISaFullHouseCardHolder = new string[5]; // the array that we will manipulate on this method
           
            // copy the values of the player cards array to ISaFullHouseCardHolder
            // so we dont accidently change the value of the original cards
             IsFull.CopyTo(ISaFullHouseCardHolder, 0); 
           
            for (int i = 0; i < 5; i++) 
            {    // Removing the Suit Loop
                Q = ISaFullHouseCardHolder[i].Remove(ISaFullHouseCardHolder[i].Length - 1); // we are removing all the suit of the array  
                ISaFullHouseCardHolder[i] = Q;
            }//end of removing suit looop

            //counting the number of item to determine the number of pair the item has 
            var CountingFullhouse = ISaFullHouseCardHolder.GroupBy(v => v); // im using the enumerator to Groups the number of time each element has appear whith the players hand.
            foreach (var count in CountingFullhouse)
            {
                if (count.Count() == 3) { fullhouseMark = fullhouseMark + 1; }; // if the count variable whith the hand player is = to 3 we add 1 to full house mark 
                if (count.Count() == 2) { fullhouseMark = fullhouseMark + 1; };  // if the count variable whith the hand player is = to 2 we add 1 to full house mark
            }

            // if the fullhouse mark is equal to 3 then we do have a full house 
            
            if (fullhouseMark == 3) 
            {  
                PlayerScore = 9; //my scoring system player score = 9 if cards on hands has a full house
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] IS a FullHouse", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

            if (fullhouseMark < 3)
            { // if the fullhouse mark is less than 3 then we dont have a full house 
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] IS NOT A FullHouse", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

        } //END of ISFullHouse Method

        //Method that will check if the player hands contains a Four of a Kind  ( i.e four cards of one rank and any other (unmatched) card)
        public void ISFourOfAkind()
        {
            if (FourOfaKindMark > 0)               
            {   //if the four of a kind mark is greater than 0 then the players cards is FOUR OF A KIND
                
                PlayerScore = 10;//player score is = to 10 if they have a Four of a Kind
                
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] IS Four Of a Knd", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);

            }

            else //if the four of a kind mark is NOT greater than 0 then The player cards is NOt Four Of A kind 

                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] IS NOT A Four Of a KInd", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
        }

        // method to check if player Hands contain a Straight flush (i.e. five consecutively ranked cards of the same suit)    
                          
        public void IsStraightFlush()
        {
            if (StraighFlushMark > 1)
            { //If the StraightFlush Mark > than 0 then the player hands is a straight Flush
                PlayerScore = 11; // player score = 11 if they obtain a Stright flush
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] IS A straight Flush", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

            else //if the player cards is not a straight flush 

                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] IS NOT A straight Flush", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);

        }

        //Method to check if the player cards on hands is Of High cards, 
        public void IsHighCards(string[] Magna)
        {

            string[] IsHighCardsHolder = new string[5];

            Magna.CopyTo(IsHighCardsHolder, 0); // copy the player cards to a new referece so we dont loose the original value of the player cards


            //now we are going to remove the suit of the player card
            //leaving us with just the ranks of each of the five cards 
            for (int i = 0; i < 5; i++)
            {

                Q = IsHighCardsHolder[i].Remove(IsHighCardsHolder[i].Length - 1); //we are removing all the suit of the array so i can compare for the pairs 
                IsHighCardsHolder[i] = Q;
            }//end of removing suit looop


            // now we will subtitute the ranks J, Q K A with their equivalant number ( 11,12,13,14,15)


            //the subtitutioon stage replace the J Q K A with 11, 12, 13, 14
            IsHighCardsHolder = IsHighCardsHolder.Select(s => s.Replace("J", "11")).ToArray();
            IsHighCardsHolder = IsHighCardsHolder.Select(s => s.Replace("Q", "12")).ToArray();
            IsHighCardsHolder = IsHighCardsHolder.Select(s => s.Replace("K", "13")).ToArray();
            IsHighCardsHolder = IsHighCardsHolder.Select(s => s.Replace("A", "14")).ToArray();

            //after subtituting the letters with their equivalent in number we now need to converit to a int array 

            int[] HighCardsIntArray = IsHighCardsHolder.Select(x => int.Parse(x)).ToArray();

            //now we need to sort the array in order to determin which cards is the highest 

            Array.Sort(HighCardsIntArray);


            //now we need condition to determin if the the level of high cards the user has 

            // now we are going to compare the first and last values of the sorted highcardint array to the default highcardslower array 
            //if they match then we have a lower high cards
            if (HighCardsIntArray[0].Equals(HighCardsLower[0]) && HighCardsIntArray[4].Equals(HighCardsLower[4]))
            {
                HightCardsPoint = HightCardsPoint + 1;
                RoyalFlushMark = RoyalFlushMark + 1; //we add 1 to the royal flush mark
                PlayerScore = 1; //this is the score of the player who matches high cards grade 3
                // Console.WriteLine("{0} Hands [ {1}, {2}, {3}, {4}, {5} ] Has High Cards", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }
            //if the highcardsIntArray = to highcards Medium just checking the first and last index
            else if (HighCardsIntArray[0].Equals(HighCardsMedium[0]) && HighCardsIntArray[4].Equals(HighCardsMedium[4]))
            {
                HightCardsPoint = HightCardsPoint + 2;
                RoyalFlushMark = RoyalFlushMark + 1; //we add 1 to the royal flush mark 
                PlayerScore = 2; //this is the score of the player who matches high cards grade 2 
            }

                //if the highcardsIntArray = to highcards STRONG just checking the first and last index
            else if (HighCardsIntArray[0].Equals(HighCardStrong[0]) && HighCardsIntArray[4].Equals(HighCardStrong[4]))
            {
                HightCardsPoint = HightCardsPoint + 3;
                RoyalFlushMark = RoyalFlushMark + 1; //we add 1 to the royal flush mark 
                PlayerScore = 3; //this is the score of the player who matches high cards grade 1 
            }

            //consition outputting the result whether or not the player hand contain high cards or not 
            if (HightCardsPoint > 0)
            {
                Console.WriteLine("{0} Hands [ {1}, {2}, {3}, {4}, {5} ] Has High Cards", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);

            }

            if (HightCardsPoint < 1)//if it doesnt contain high cards
            {
                Console.WriteLine("{0} Hands [ {1}, {2}, {3}, {4}, {5} ] Does Not Have High Cards", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

        }//end of is hight cards

// Method to determin if the Player cards On hands IS a Royal Flush (i.e A straight and Highcards)

        public void IsRoyalFlush()
        {

            if (RoyalFlushMark > 1)
            {
                PlayerScore = 12;//player score if they got a royal flush
                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] Has a Royal Flush", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
            }

            else

                Console.WriteLine("{0} Cards [ {1}, {2}, {3}, {4}, {5} ] Does not Have a Royal Flush", playerName, Checker[0], Checker[1], Checker[2], Checker[3], Checker[4]);
       
        } // END of Is royal flush 


        
    }//end of class hands
}
//ranking order from the strongest hand to the weakest hand
// 1) ROYAL FLUSH
// 2) STRAIGHT FLUSH
// 3) FOUR OF A KIND
// 4) FULL HOUSE
// 5) FLUSH
// 6) STRAIGHT
// 7) THREE OF A KIND
// 8) TWO PAIR
// 9) ONE PAIR
// 10) HIGH CARDS

//inventory codes for testing purposes 
//****************************************************Testing code purposes*******************************************
//foreach (string suit in IsFlushCardHolder)
//{

//    Console.Write(suit.ToString() + ","); //to see what the value of suit is 

//}
//*********************************************************************************************************************