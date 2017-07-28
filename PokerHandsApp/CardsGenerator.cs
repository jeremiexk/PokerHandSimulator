//APPLICATION GENERATING POKER HANDS RANDOMLY AND DISTRIBUTING IT TO DIFFERENT PLAYERS AND IDENTIFYING THE WINNING HANDS.
//This is the Cards Generator class of my poker application, it wil be a static class and will be used to randomly shuffle cards   
//Author: jeremie kipeleka S12795522
// Date: 23/11/2013
//File: CardsGenerator.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsApp
{
    static class CardsGenerator // i've declaire this class static because i dont want this class to be instantiated
    {
        static Random Shuffle = new Random();

        // the code below will store each card(value) with a Key "KeyValue Pairs 
        public static string[] shufflingCards(string[] DeckOfCards)
        {
            
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            // Add all strings from array
            // Add new random int each time
            foreach (string C in DeckOfCards)
            {
                list.Add(new KeyValuePair<int, string>(Shuffle.Next(), C));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            string[] result = new string[DeckOfCards.Length];
            // Copy values to array
            int index = 0;

            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        
        }
    }
}
