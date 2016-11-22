using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this is the class for the easy-level bot
namespace SeniorProject
{
    class AIEasy : AI
    {
      private  Hand hand;
      private Card card;  
 
        public AIEasy():base() {
            hand = new Hand();
            card = new Card();
                      
        }

        //throws card
            public override Card throwCard(Card topCard){
                if(hand.isFirstThrown() )
                {
                    if (hand.isSecondThrown())
                    {
                        if (hand.isThirdThrown())
                        {
                            card.imageName = hand.getFourthCard().imageName;
                            card.setFace(hand.getFourthCard().getFace());
                            card.setSuit(hand.getFourthCard().getSuit());                           
                            hand.throwFourthCard();
                            return card;
                        }
                        else
                        {
                            card.imageName = hand.getThirdCard().imageName;
                            card.setFace(hand.getThirdCard().getFace());
                            card.setSuit(hand.getThirdCard().getSuit());
                            hand.throwThirdCard();
                            return card;
                        }
                    }
                    else
                    {
                        card.imageName = hand.getSecondCard().imageName;
                        card.setFace(hand.getSecondCard().getFace());
                        card.setSuit(hand.getSecondCard().getSuit());                  
                        hand.throwSecondCard();
                        return card;

                    }
                }
                else
                {
                    
                    card.imageName = hand.getFirstCard().imageName;
                    card.setFace(hand.getFirstCard().getFace());
                    card.setSuit(hand.getFirstCard().getSuit());
                    hand.throwFirstCard();                  
                    return card;
                }

                
               
            
            }

        //fills the hand
            public override void fillHand(Card first, Card second, Card third, Card fourth)
            {

                hand.setFirstCard(first);
                hand.setSecondCard(second);
                hand.setThirdCard(third);
                hand.setFourthCard(fourth);
            }
            
    }
    }

