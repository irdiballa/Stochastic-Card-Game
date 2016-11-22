using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//The game class for 2 player (1 human and 1 bot)

namespace SeniorProject
{
    class Game3
    {
        private int nrAI;
        private string difficulty;
        public Player player;
        private Deck deck;
        private List<Card> fieldCards;
        private AI bot1;
        private AI bot2;
        private AI bot3;
        private Card card, card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11;
        private int currentFieldCard;
        private Card helpCard, helpCard1, helpCard2;
        private string last;
        private Card nullCard;
        private Card lastCardThrown;

        //constructor
        public Game3(int nrBots, string diff)
        {

            nrAI = nrBots;
            difficulty = diff;
            player = new Player();
            deck = new Deck();
            fieldCards = new List<Card>(52);
            card = new Card();
            card1 = new Card();
            card2 = new Card();
            card3 = new Card();
            card4 = new Card();
            card5 = new Card();
            card6 = new Card();
            card7 = new Card();
            card8= new Card();
            card9 = new Card();
            card10 = new Card();
            card11 = new Card();
            currentFieldCard = 0;
            helpCard = new Card();
            helpCard1 = new Card();
            helpCard2 = new Card();
            last = "player";
            nullCard = new Card("", "");

            if (difficulty == "easy")
            {
                bot1 = new AIEasy();
                bot2 = new AIEasy();
                bot3 = new AIEasy();
            }
            else if (difficulty == "medium")
            {
                bot1 = new AIMedium();
                bot2 = new AIMedium();
                bot3 = new AIMedium();
            }
            else
            {
                bot1 = new AIHard();
                bot2 = new AIHard();
                bot3 = new AIHard();
            }

        }

        //puts the cards in the field and gives cards to all players
        public void layField()
        {
            //Hand hhh = Bot1.Hand;
            //Bot1.Hand = hhh;

            deck.shuffleDeck();
            // place Cards of the field
            card = deck.dealCard();
            bot1.addCardToMemory(card);
            bot2.addCardToMemory(card);
            bot3.addCardToMemory(card);
            fieldCards.Add(card);
            card = deck.dealCard();
            bot1.addCardToMemory(card);
            bot2.addCardToMemory(card);
            bot3.addCardToMemory(card);
            fieldCards.Add(card);
            card = deck.dealCard();
            bot1.addCardToMemory(card);
            bot2.addCardToMemory(card);
            bot3.addCardToMemory(card);
            fieldCards.Add(card);
            card = deck.dealCard();
            bot1.addCardToMemory(card);
            bot2.addCardToMemory(card);
            bot3.addCardToMemory(card);
            fieldCards.Add(card);
            currentFieldCard = 4;
            //fill players hand
            card = deck.dealCard();
            card1 = deck.dealCard();
            card2 = deck.dealCard();
            card3 = deck.dealCard();
            bot1.addCardToMemory(card);
            bot1.addCardToMemory(card1);
            bot1.addCardToMemory(card2);
            bot1.addCardToMemory(card3);
            bot1.fillHand(card, card1, card2, card3);
            card4 = deck.dealCard();
            card5 = deck.dealCard();
            card6 = deck.dealCard();
            card7 = deck.dealCard();
            bot2.addCardToMemory(card4);
            bot2.addCardToMemory(card5);
            bot2.addCardToMemory(card6);
            bot2.addCardToMemory(card7);
            bot2.fillHand(card4, card5, card6, card7);
            card8 = deck.dealCard();
            card9 = deck.dealCard();
            card10 = deck.dealCard();
            card11 = deck.dealCard();
            bot3.addCardToMemory(card8);
            bot3.addCardToMemory(card9);
            bot3.addCardToMemory(card10);
            bot3.addCardToMemory(card11);
            bot3.fillHand(card8, card9, card10, card11);
            player.fillHand(deck.dealCard(), deck.dealCard(), deck.dealCard(), deck.dealCard());
        }

        //bot throws a card
        public void bot1ThrowCard()
        {
            if (fieldCards.Count == 0)
            {
                helpCard = bot1.throwCard(nullCard).ReturnCopy();
            }
            else
            {
                helpCard = bot1.throwCard(fieldCards[fieldCards.Count - 1]).ReturnCopy();
            }
            lastCardThrown = helpCard;
            fieldCards.Add(helpCard);
            bot1.addCardToMemory(helpCard);
            bot2.addCardToMemory(helpCard);
            bot3.addCardToMemory(helpCard);
            if (fieldCards.Count > 1)
            {
                if ((fieldCards[fieldCards.Count - 1].getFace() == fieldCards[fieldCards.Count - 2].getFace()) || (fieldCards[fieldCards.Count - 1].getFace() == "Jack"))
                {
                    foreach (Card card in fieldCards)
                    {
                        bot1.addCardToCollection(card);
                    }
                    fieldCards.Clear();
                    last = "bot1";
                }
            }
        }
        public void bot2ThrowCard()
        {
            if (fieldCards.Count == 0)
            {
                helpCard1 = bot2.throwCard(nullCard).ReturnCopy();
            }
            else
            {
                helpCard1 = bot2.throwCard(fieldCards[fieldCards.Count - 1]).ReturnCopy();
            }
            lastCardThrown = helpCard1;
            fieldCards.Add(helpCard1);
            bot1.addCardToMemory(helpCard1);
            bot2.addCardToMemory(helpCard1);
            bot3.addCardToMemory(helpCard1);
            if (fieldCards.Count > 1)
            {
                if ((fieldCards[fieldCards.Count - 1].getFace() == fieldCards[fieldCards.Count - 2].getFace()) || (fieldCards[fieldCards.Count - 1].getFace() == "Jack"))
                {
                    foreach (Card card in fieldCards)
                    {
                        bot2.addCardToCollection(card);
                    }
                    fieldCards.Clear();
                    last = "bot2";
                }
            }
        }
        public void bot3ThrowCard()
        {
            if (fieldCards.Count == 0)
            {
                helpCard2 = bot3.throwCard(nullCard).ReturnCopy();
            }
            else
            {
                helpCard2 = bot3.throwCard(fieldCards[fieldCards.Count - 1]).ReturnCopy();
            }
            lastCardThrown = helpCard2;
            fieldCards.Add(helpCard2);
            bot1.addCardToMemory(helpCard2);
            bot2.addCardToMemory(helpCard2);
            bot3.addCardToMemory(helpCard2);
            if (fieldCards.Count > 1)
            {
                if ((fieldCards[fieldCards.Count - 1].getFace() == fieldCards[fieldCards.Count - 2].getFace()) || (fieldCards[fieldCards.Count - 1].getFace() == "Jack"))
                {
                    foreach (Card card in fieldCards)
                    {
                        bot3.addCardToCollection(card);
                    }
                    fieldCards.Clear();
                    last = "bot3";
                }
            }
        }

        //starts a new round
        public void round()
        {
            player.fillHand(deck.dealCard(), deck.dealCard(), deck.dealCard(), deck.dealCard());
            bot1.fillHand(deck.dealCard(), deck.dealCard(), deck.dealCard(), deck.dealCard());
            bot2.fillHand(deck.dealCard(), deck.dealCard(), deck.dealCard(), deck.dealCard());
            bot3.fillHand(deck.dealCard(), deck.dealCard(), deck.dealCard(), deck.dealCard());

        }

        //checks if game is over
        public bool isGameOver()
        {
            return deck.isDeckOver();
        }

        //returns the imageName of the top card in the field
        public string getTopFieldCardName()
        {
            if (fieldCards.Count == 0)
            {
                return "empty";
            }
            else
            {
                return fieldCards.Last().getImageLink();
            }
        }

        //player throws a card
        public void playerThrowCard(int i)
        {

            Card helpCard = player.throwCard(i).ReturnCopy();
            fieldCards.Add(helpCard);
            lastCardThrown = helpCard;
            bot1.addCardToMemory(helpCard);
            bot2.addCardToMemory(helpCard);
            bot3.addCardToMemory(helpCard);
            currentFieldCard++;

            if (fieldCards.Count > 1)
            {
                if (fieldCards[fieldCards.Count - 1].getFace() == fieldCards[fieldCards.Count - 2].getFace() || (fieldCards[fieldCards.Count - 1].getFace() == "Jack"))
                {
                    foreach (Card card in fieldCards)
                    {
                        player.addCardToCollection(card);
                    }
                    fieldCards.Clear();
                    last = "player";
                }
            }

        }

        //THe following methods calculate the points and display them
        public void calculatePoints()
        {
            List<Card> bot1Collection = bot1.getCollection();
            List<Card> playerCollection = player.getCollection();
            List<Card> bot2Collection = bot2.getCollection();
            List<Card> bot3Collection = bot3.getCollection();
            double playerPoints = 0;
            double bot1Points = 0;
            double bot2Points = 0;
            double bot3Points = 0;
            int playerClubs = 0;
            int bot1Clubs = 0;
            int bot2Clubs = 0;
            int bot3Clubs = 0;

            if ((playerCollection.Count > bot1Collection.Count) && (playerCollection.Count > bot2Collection.Count) && (playerCollection.Count > bot3Collection.Count))
            {
                playerPoints++;
                playerPoints++;
            }
            else if ((playerCollection.Count == bot1Collection.Count) && (playerCollection.Count > bot2Collection.Count) && (playerCollection.Count > bot3Collection.Count))
            {
                playerPoints++;
                bot1Points++;
            }
            else if ((playerCollection.Count > bot1Collection.Count) && (playerCollection.Count == bot2Collection.Count) && (playerCollection.Count > bot3Collection.Count))
            {
                playerPoints++;
                bot2Points++;
            }
            else if ((playerCollection.Count > bot1Collection.Count) && (bot1Collection.Count > bot2Collection.Count) && (playerCollection.Count == bot3Collection.Count))
            {
                playerPoints++;
                bot3Points++;
            }
            else if ((playerCollection.Count == bot1Collection.Count) && (bot1Collection.Count == bot2Collection.Count) && (playerCollection.Count > bot3Collection.Count))
            {
                playerPoints += 0.66;
                bot1Points += 0.66;
                bot2Points += 0.66;
            }
            else if ((playerCollection.Count == bot1Collection.Count) && (playerCollection.Count > bot2Collection.Count) && (playerCollection.Count == bot3Collection.Count))
            {
                playerPoints += 0.66;
                bot1Points += 0.66;
                bot3Points += 0.66;
            }
            else if ((playerCollection.Count > bot1Collection.Count) && (playerCollection.Count == bot2Collection.Count) && (playerCollection.Count == bot3Collection.Count))
            {
                playerPoints += 0.66;
                bot2Points += 0.66;
                bot3Points += 0.66;
            }
            else if ((playerCollection.Count < bot1Collection.Count) && (bot1Collection.Count > bot2Collection.Count) && (bot1Collection.Count > bot3Collection.Count))
            {
                bot1Points++;
                bot1Points++;
            }
            else if ((playerCollection.Count < bot1Collection.Count) && (bot1Collection.Count == bot2Collection.Count) && (bot1Collection.Count > bot3Collection.Count))
            {
                bot1Points++;
                bot2Points++;
            }
            else if ((playerCollection.Count < bot1Collection.Count) && (bot1Collection.Count > bot2Collection.Count) && (bot1Collection.Count == bot3Collection.Count))
            {
                bot1Points++;
                bot3Points++;
            }
            else if ((playerCollection.Count < bot1Collection.Count) && (bot1Collection.Count == bot2Collection.Count) && (bot1Collection.Count == bot3Collection.Count))
            {
                bot1Points += 0.66;
                bot2Points += 0.66;
                bot3Points += 0.66;
            }
            else if ((playerCollection.Count < bot2Collection.Count) && (bot1Collection.Count < bot2Collection.Count) && (bot2Collection.Count > bot3Collection.Count))
            {
                bot2Points++;
                bot2Points++;
            }
            else if ((playerCollection.Count < bot2Collection.Count) && (bot1Collection.Count < bot2Collection.Count) && (bot2Collection.Count == bot3Collection.Count))
            {
                bot2Points++;
                bot3Points++;
            }
            else if ((playerCollection.Count == bot2Collection.Count) && (bot1Collection.Count == bot2Collection.Count) && (bot2Collection.Count == bot3Collection.Count))
            {
                playerPoints += 0.5;
                bot1Points += 0.5;
                bot2Points += 0.5;
                bot3Points += 0.5;
            }
            else
            {
                bot3Points++;
                bot3Points++;
            }
            playerClubs = countClubs(playerCollection);
            bot1Clubs = countClubs(bot1Collection);
            bot2Clubs = countClubs(bot2Collection);
            bot3Clubs = countClubs(bot3Collection);

            if ((playerClubs > bot1Clubs) && (playerClubs > bot2Clubs) && (playerClubs > bot3Clubs))
            {
                playerPoints++;
            }
            else if ((playerClubs == bot1Clubs) && (playerClubs > bot2Clubs) && (playerClubs > bot3Clubs))
            {
                bot1Points += 0.5;
                playerPoints += 0.5;
            }
            else if ((playerClubs > bot1Clubs) && (playerClubs == bot2Clubs) && (playerClubs > bot3Clubs))
            {
                bot2Points += 0.5;
                playerPoints += 0.5;
            }
            else if ((playerClubs > bot1Clubs) && (playerClubs > bot2Clubs) && (playerClubs == bot3Clubs))
            {
                bot3Points += 0.5;
                playerPoints += 0.5;
            }
            else if ((playerClubs == bot1Clubs) && (playerClubs == bot2Clubs) && (playerClubs > bot3Clubs))
            {
                playerPoints += 0.34;
                bot1Points += 0.34;
                bot2Points += 0.34;
            }
            else if ((playerClubs == bot1Clubs) && (playerClubs > bot2Clubs) && (playerClubs == bot3Clubs))
            {
                playerPoints += 0.34;
                bot1Points += 0.34;
                bot3Points += 0.34;
            }
            else if ((playerClubs > bot1Clubs) && (playerClubs == bot2Clubs) && (playerClubs == bot3Clubs))
            {
                playerPoints += 0.34;
                bot2Points += 0.34;
                bot3Points += 0.34;
            }
            else if ((playerClubs < bot1Clubs) && (bot1Clubs > bot2Clubs) && (bot1Clubs > bot3Clubs))
            {               
                bot1Points++;
            }
            else if ((playerClubs < bot1Clubs) && (bot1Clubs == bot2Clubs) && (bot1Clubs > bot3Clubs))
            {
                bot1Points += 0.5;
                bot2Points += 0.5;
            }
            else if ((playerClubs < bot1Clubs) && (bot1Clubs > bot2Clubs) && (bot1Clubs == bot3Clubs))
            {
                bot1Points += 0.5;
                bot3Points += 0.5;
            }
            else if ((playerClubs < bot1Clubs) && (bot1Clubs == bot2Clubs) && (bot1Clubs == bot3Clubs))
            {
                bot1Points += 0.34;
                bot2Points += 0.34;
                bot3Points += 0.34;
            }
            else if ((playerClubs < bot2Clubs) && (bot1Clubs < bot2Clubs) && (bot2Clubs > bot3Clubs))
            {              
                bot2Points ++;
            }
            else if ((playerClubs < bot2Clubs) && (bot1Clubs < bot2Clubs) && (bot2Clubs == bot3Clubs))
            {               
                bot2Points += 0.5;
                bot3Points += 0.5;
            }
            else
            {
                bot3Points++;
            }

            playerPoints = playerPoints + beautifulCardPoints(playerCollection);
            bot1Points = bot1Points + beautifulCardPoints(bot1Collection);
            bot2Points = bot2Points + beautifulCardPoints(bot2Collection);
            bot3Points = bot3Points + beautifulCardPoints(bot3Collection);


            MessageBox.Show("Player - " + playerPoints + "\n Bot1 - " + bot1Points + "\n Bot2 - " + bot2Points + "\n Bot3 - " + bot3Points);
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\result.txt", true);
            file.WriteLine(difficulty + "---Player:" + playerPoints + " -- Bot1:" + bot1Points + " -- Bot2:" + bot2Points + " -- Bot3:" + bot3Points);
            file.Close();
        }
        private int countClubs(List<Card> list)
        {
            int spades = 0;

            foreach (Card card in list)
            {
                if (card.getSuit() == "Clubs")
                {
                    spades++;
                }
            }

            return spades;
        }
        private int beautifulCardPoints(List<Card> list)
        {
            int points = 0;
            foreach (Card card in list)
            {
                if ((card.imageName == "TwoClubs") || (card.imageName == "TenDiamonds"))
                {
                    points++;
                }
            }


            return points;
        }

        //This adds any cards that remained on the field to the collection of the player that collected last
        public void addLastCards()
        {
            if (last == "player")
            {
                foreach (Card card in fieldCards)
                {
                    player.addCardToCollection(card);
                }
            }
            else if (last == "bot1")
            {
                foreach (Card card in fieldCards)
                {
                    bot1.addCardToCollection(card);
                }
            }
            else if (last == "bot2")
            {
                foreach (Card card in fieldCards)
                {
                    bot2.addCardToCollection(card);
                }
            }
            else
            {
                foreach (Card card in fieldCards)
                {
                    bot3.addCardToCollection(card);
                }
            }

            fieldCards.Clear();
        }

        //This returns the imageName of the last card that was thrown
        public string getlastCardThrownName()
        {
            return lastCardThrown.imageName;
        }
    }
}
