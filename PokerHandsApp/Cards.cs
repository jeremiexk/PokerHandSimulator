using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsApp
{
  public   class Cards
    {                           //spades = S, hearts = H, clubs = C, diamonds =D HERE BELOW ARE THE COMBINATION OF THE CARDS AVAILABLE

       public string[] DeckOfCards = new string[] { "AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS",

                                              "AH", "2H","3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH",
        
                                              "AC", "2C","3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC",

                                              "AD", "2D","3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD" };

       string CardsSelections;


      //public  Cards() //constructor of the class cards

      //                  { //randomisation of the cards

      //                      CardsSelections.Value = DeckOfCards[new Random().Next(0,DeckOfCards.Length)];
      
      //                  }


    }//end of class 
}
