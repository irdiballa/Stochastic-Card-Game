using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorProject
{
    class AIMedium : AI
    {
        private Hand hand;
        private Card card;
        private Card[] botCards;
        private int MatchedBeautiful, MatchedAny, JackAny;
        private bool[] isCardThrown;
        
        //constructor
        public AIMedium():base()  {
            hand = new Hand();
            card = new Card();
            botCards = new Card[4];
            botCards[0] = hand.getFirstCard();
            botCards[1] = hand.getSecondCard();
            botCards[2] = hand.getThirdCard();
            botCards[3] = hand.getFourthCard();
            MatchedBeautiful =0;
            MatchedAny =0;
            JackAny = 0;
            isCardThrown = new bool[4];
            isCardThrown[0] = false;
            isCardThrown[1] = false;
            isCardThrown[2] = false;
            isCardThrown[3] = false;
                   
        }

        //throws card
        public override Card throwCard(Card topCard)
        {
            if (isCardThrown[0] && isCardThrown[1] && isCardThrown[2] && isCardThrown[3])
            { 
            isCardThrown[0] = false;
            isCardThrown[1] = false;
            isCardThrown[2] = false;
            isCardThrown[3] = false;
            }

            MatchedBeautiful = matchingBeautiful(topCard);
            if ( MatchedBeautiful== 1)
            {
                isCardThrown[0] = true;
                return hand.getFirstCard();
            }
            else if (MatchedBeautiful == 2) 
            {
                isCardThrown[1] = true;
                return hand.getSecondCard();
            }
            else if (MatchedBeautiful == 3) 
            {
                isCardThrown[2] = true;
                return hand.getThirdCard();
            }
            else if (MatchedBeautiful == 4) 
            {
                isCardThrown[3] = true;
                return hand.getFourthCard();
            }
            else
            {
                MatchedAny = matchingAny(topCard);
                if ( MatchedAny == 1)
                {
                    isCardThrown[0] = true;
                    return hand.getFirstCard();
                }
                else if (MatchedAny == 2)
                {
                    isCardThrown[1] = true;
                    return hand.getSecondCard();
                }
                else if (MatchedAny == 3)
                {
                    isCardThrown[2] = true;
                    return hand.getThirdCard();
                }
                else if (MatchedAny == 4)
                {
                    isCardThrown[3] = true;
                    return hand.getFourthCard();
                }
                else
                {
                    JackAny = jackAny(topCard);
                    if (JackAny == 1)
                    {
                        isCardThrown[0] = true;
                        return hand.getFirstCard();
                    }
                    else if (JackAny == 2)
                    {
                        isCardThrown[1] = true;
                        return hand.getSecondCard();
                    }
                    else if (JackAny == 3)
                    {
                        isCardThrown[2] = true;
                        return hand.getThirdCard();
                    }
                    else if (JackAny == 4)
                    {
                        isCardThrown[3] = true;
                        return hand.getFourthCard();
                    }
                    else
                    {
                         return nextCard(topCard);
                    }
                    
                }
            }
        }

        //fills hand
        public override void fillHand(Card first, Card second, Card third, Card fourth)
        {

            hand.setFirstCard(first);
            hand.setSecondCard(second);
            hand.setThirdCard(third);
            hand.setFourthCard(fourth);
         }

        //methods used by throwCard() to determine what card to throw
        public int matchingBeautiful(Card topCard)
        {
            if ((topCard.getFace() == "Two") || (topCard.getFace() == "Ten"))
            {

                for (int i = 0; i < 4; i++)
                {
                    if (!isCardThrown[i] && ((botCards[i].imageName == "TwoClubs") || (botCards[i].imageName == "TenDiamonds")))
                    { return i+1; }
                }
            }           
            return 0;            
        }
        public int matchingAny(Card topCard)
        {
            

                for (int i = 0; i < 4; i++)
                {
                    if ((!isCardThrown[i]) && (botCards[i].getFace() == topCard.getFace()))
                    { return i+1; }
                }
           
            return 0;            
        }
        public int jackAny(Card topCard)
        {
            if (!(topCard.imageName == ""))
            {

                for (int i = 0; i < 4; i++)
                {
                    if ((!isCardThrown[i]) && (botCards[i].getFace() == "Jack"))
                    { return i + 1; }
                }
            }
            return 0;       
        }
        public Card nextCard(Card topCard)
        {
            if ((!isCardThrown[0]) && (!(topCard.imageName == "") && (hand.getFirstCard().getFace() == "Jack")))
            {
                isCardThrown[0] = true;
                return hand.getFirstCard();
            }
            else if (!isCardThrown[1] && (!(topCard.imageName == "") && (hand.getSecondCard().getFace() == "Jack")))
            {
                isCardThrown[1] = true;
                return hand.getSecondCard();
            }
            else if (!isCardThrown[2] && (!(topCard.imageName == "") && (hand.getThirdCard().getFace() == "Jack")))
            {
                isCardThrown[2] = true;
                return hand.getThirdCard();
            }
            else if (!isCardThrown[3] && (!(topCard.imageName == "") && (hand.getFourthCard().getFace() == "Jack")))
            {
                isCardThrown[3] = true;
                return hand.getFourthCard();
            }
            else
            {

                if (!isCardThrown[0])
                {
                    isCardThrown[0] = true;
                    return hand.getFirstCard();
                }
                else if (!isCardThrown[1])
                {
                    isCardThrown[1] = true;
                    return hand.getSecondCard();
                }
                else if (!isCardThrown[2])
                {
                    isCardThrown[2] = true;
                    return hand.getThirdCard();
                }
                else
                {
                    isCardThrown[3] = true;
                    return hand.getFourthCard();
                }
            }
        }
        
    }
}
