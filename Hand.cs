using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

//This class creates a hand that
//holds 4 cards

namespace SeniorProject
{
    class Hand
    {
        private Card firstCard, secondCard, thirdCard, fourthCard;    //hold the cards of the hand
        //constructor
        public Hand() { 
           firstCard = new Card();
           secondCard = new Card();
           thirdCard = new Card();
           fourthCard = new Card();
        }
        //set the cards
        public void setFirstCard(Card card){


                   firstCard.setFace(card.getFace());
                   firstCard.setSuit(card.getSuit());
                   firstCard.imageName = card.imageName;
       
           }
        public void setSecondCard(Card card)
           {

                   secondCard.setFace(card.getFace());
                   secondCard.setSuit(card.getSuit());
                   secondCard.imageName = card.imageName;
             
           }
        public void setThirdCard(Card card)
           {
               
                   thirdCard.setFace(card.getFace());
                   thirdCard.setSuit(card.getSuit());
                   thirdCard.imageName = card.imageName;
              
           }
        public void setFourthCard(Card card)
           {
               
                   fourthCard.setFace(card.getFace());
                   fourthCard.setSuit(card.getSuit());
                   fourthCard.imageName = card.imageName;
             
           }

        //return the cards
        public Card getFirstCard()
           {
               return firstCard;
           }
        public Card getSecondCard()
           {
               return secondCard;
           }
        public Card getThirdCard()
           {
               return thirdCard;
           }
        public Card getFourthCard()
           {
               return fourthCard;
           }

        //return the name of the card as FaceSuit combination
        public String getFirstCardName()
           {
               return firstCard.getImageLink();
           }
        public String getSecondCardName()
           {
               return secondCard.getImageLink();
           }
        public String getThirdCardName()
           {
               return thirdCard.getImageLink();
           }
        public String getFourthCardName()
           {
               return fourthCard.getImageLink();
           }

        //checks if a card is thrown
        public bool isFirstThrown()
            {
                if (firstCard.imageName == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        public bool isSecondThrown()
            {
                if (secondCard.imageName == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        public bool isThirdThrown()
            {
                if (thirdCard.imageName == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        public bool isFourthThrown()
            {
                if (fourthCard.imageName == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        //throws a card
        public void throwFirstCard()
            {
                firstCard.imageName = "";
            }
        public void throwSecondCard()
            {
                secondCard.imageName = "";
            }
        public void throwThirdCard()
            {
                thirdCard.imageName = "";
            }
        public void throwFourthCard()
            {
                fourthCard.imageName = "";
            }
            
    }
}
