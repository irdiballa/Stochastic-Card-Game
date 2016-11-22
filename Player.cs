using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

/* This class creates human player and
   holds all the methods needed for that player*/

namespace SeniorProject
{
   
    class Player
    {   
        public Hand hand;                                                          //holds the had of the player
        private List<Card> playerCollection;                                        //holds the collected cards of the player
        private bool isFirst, isSecond, isThird, isFourth;                          //hold true if the player still has that card

        //player constructor
        public Player() {
            hand = new Hand();
            isFirst = false;
            isSecond = false;
            isThird = false;
            isFourth = false;
            playerCollection = new List<Card>();
        }

        //fills the hand of the player with 4 cards
        public void fillHand(Card first, Card second, Card third, Card fourth)
        {
            hand.setFirstCard(first);
            isFirst = true; 
            hand.setSecondCard(second);
            isSecond = true;
            hand.setThirdCard(third);
            isThird = true;
            hand.setFourthCard(fourth);
            isFourth = true;

        }

        //throws a card
        public Card throwCard(int i)
        {
            
                if (i==1)
                {
                    isFirst = false;
                    
                    return hand.getFirstCard();

                }
                else if (i==2)
                {
                    isSecond = false;
                    return hand.getSecondCard();
                }
                else if (i==3)
                {
                    isThird = false;
                    return hand.getThirdCard();
                }
                else 
                {
                    isFourth = false;               
                    return hand.getFourthCard();
                }
            
            }

        //checks if the hand is empty
        public bool isHandEmpty()
        {
            if(!isFirst && !isSecond && !isThird && !isFourth)
            {
                return true;
            }
            else
            { return false; }
        }

        //adds a card to the collection
        public void addCardToCollection(Card card)
        {
            playerCollection.Add(card);
        }

        //returns the players collection
        public List<Card> getCollection()
        {
            return playerCollection;
        }
    }
}
