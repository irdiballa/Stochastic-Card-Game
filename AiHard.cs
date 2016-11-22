using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorProject
{
    class AIHard : AI
    {
        private Hand hand;
        private Card card;
        private Card[] botCards;
        private int MatchedBeautiful, MatchedAny, JackAny, matchedClubs;
        private bool[] isCardThrown;
        private int[] memory;
        
        //constructor
        public AIHard(): base()  {
            hand = new Hand();
            card = new Card();
            botCards = new Card[4];
            botCards[0] = hand.getFirstCard();
            botCards[1] = hand.getSecondCard();
            botCards[2] = hand.getThirdCard();
            botCards[3] = hand.getFourthCard();
            MatchedBeautiful = 0;
            MatchedAny = 0;
            JackAny = 0;
            isCardThrown = new bool[4];
            isCardThrown[0] = false;
            isCardThrown[1] = false;
            isCardThrown[2] = false;
            isCardThrown[3] = false;
            memory = new int[13] {0,0,0,0,0,0,0,0,0,0,0,0,0};
                      
        }

        //throw card
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
            if (MatchedBeautiful == 1)
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
                matchedClubs = matchingClubs(topCard);
                if (matchedClubs == 1)
                {
                    isCardThrown[0] = true;
                    return hand.getFirstCard();
                }
                else if (matchedClubs == 2)
                {
                    isCardThrown[1] = true;
                    return hand.getSecondCard();
                }
                else if (matchedClubs == 3)
                {
                    isCardThrown[2] = true;
                    return hand.getThirdCard();
                }
                else if (matchedClubs == 4)
                {
                    isCardThrown[3] = true;
                    return hand.getFourthCard();
                }
                else
                {

                    MatchedAny = matchingAny(topCard);
                    if (MatchedAny == 1)
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
                            return highestIndex();
                        }

                    }
                }
            }
        }

        //fill hand
        public override void fillHand(Card first, Card second, Card third, Card fourth)
        {

            hand.setFirstCard(first);
            hand.setSecondCard(second);
            hand.setThirdCard(third);
            hand.setFourthCard(fourth);
        }

        //these methods are used from the fillHand() method to check if any of the priorities is met
        public int matchingBeautiful(Card topCard)
        {
            if ((topCard.getFace() == "Two") || (topCard.getFace() == "Ten"))
            {

                for (int i = 0; i < 4; i++)
                {
                    if (!isCardThrown[i] && ((botCards[i].imageName == "TwoClubs") || (botCards[i].imageName == "TenDiamonds")))
                    { return i + 1; }
                }
            }
            return 0;
        }
        public int matchingClubs(Card topCard)
        {
            if (topCard.getSuit() != "Clubs")
            {

                for (int i = 0; i < 4; i++)
                {
                    if (!isCardThrown[i] && (botCards[i].getFace() == topCard.getFace()))
                    { return i + 1; }
                }
            }
            return 0;
        }
        public int matchingAny(Card topCard)
        {


            for (int i = 0; i < 4; i++)
            {
                if ((!isCardThrown[i]) && (botCards[i].getFace() == topCard.getFace()))
                { return i + 1; }
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

        //this will return the card with the highest index if no match is possible
        public Card highestIndex()
        {
            int[] cardIndex;
            cardIndex = new int[4] { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                if (!(isCardThrown[i]))
                {
                    switch (botCards[i].getFace())
                    {
                        case "Ace":
                            cardIndex[i] = memory[0];
                            break;
                        case "Two":
                            cardIndex[i] = memory[1];
                            break;
                        case "Three":
                            cardIndex[i] = memory[2];
                            break;
                        case "Four":
                            cardIndex[i] = memory[3];
                            break;
                        case "Five":
                            cardIndex[i] = memory[4];
                            break;
                        case "Six":
                            cardIndex[i] = memory[5];
                            break;
                        case "Seven":
                            cardIndex[i] = memory[6];
                            break;
                        case "Eight":
                            cardIndex[i] = memory[7];
                            break;
                        case "Nine":
                            cardIndex[i] = memory[8];
                            break;
                        case "Ten":
                            cardIndex[i] = memory[9];
                            break;
                        case "Jack":
                            cardIndex[i] = -1;
                            break;
                        case "Queen":
                            cardIndex[i] = memory[11];
                            break;
                        case "King":
                            cardIndex[i] = memory[12];
                            break;
                    }
                }
                else
                {
                    cardIndex[i] = -2;
                }
            }
            if((cardIndex[0]>=cardIndex[1]) &&(cardIndex[0]>=cardIndex[2]) &&(cardIndex[0]>=cardIndex[3]))
            {
                isCardThrown[0] = true;
                return hand.getFirstCard();
            }
            if ((cardIndex[1] >= cardIndex[2]) && (cardIndex[1] >= cardIndex[3]))
            {
                isCardThrown[1] = true;
                return hand.getSecondCard();
            }
            if ((cardIndex[2] >= cardIndex[3]))
            {
                isCardThrown[2] = true;
                return hand.getThirdCard();
            }
            else {
                isCardThrown[3] = true;
                return hand.getFourthCard(); 
            }           
        }

        //this methods adds any card that the cbot "sees"
        public override void addCardToMemory(Card card)
        {
            string face = card.ReturnCopy().getFace();

            switch (face)
            {
                case "Ace":
                    memory[0]++;
                    break;
                case "Two":
                    memory[1]++;
                    break;
                case "Three":
                    memory[2]++;
                    break;
                case "Four":
                    memory[3]++;
                    break;
                case "Five":
                    memory[4]++;
                    break;
                case "Six":
                    memory[5]++;
                    break;
                case "Seven":
                    memory[6]++;
                    break;
                case "Eight":
                    memory[7]++;
                    break;
                case "Nine":
                    memory[8]++;
                    break;
                case "Ten":
                    memory[9]++;
                    break;
                case "Jack":
                    memory[10]++;
                    break;
                case "Queen":
                    memory[11]++;
                    break;
                case "King":
                    memory[12]++;
                    break;
            }

        }
    }
}
