using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//The game class for 2 player (1 human and 1 bot)

namespace SeniorProject
{
    class Game
    {
        private int nrAI;
        private string difficulty;
        public Player player;
        private Deck deck;
        private List<Card> fieldCards;
        private AI bot1;
        private Card card, card1, card2, card3;
        private int currentFieldCard;
        private Card helpCard;
        private string last;
        private Card nullCard;
        private Card lastCardThrown;

        //constructor
        public Game(int nrBots, string diff)
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
            currentFieldCard = 0;
            helpCard = new Card();
            last = "player";
            nullCard = new Card("", "");

            if (difficulty == "easy")
            {
                bot1 = new AIEasy();
            }
            else if (difficulty == "medium")
            {
                bot1 = new AIMedium();             
            }
            else
            {
                bot1 = new AIHard();
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
            fieldCards.Add(card);
            card = deck.dealCard();
            bot1.addCardToMemory(card);
            fieldCards.Add(card);
            card = deck.dealCard();
            bot1.addCardToMemory(card);
            fieldCards.Add(card);
            card = deck.dealCard();
            bot1.addCardToMemory(card);
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
            bot1.fillHand(card,card1,card2,card3);
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

        //starts a new round
        public void round()
        {
            player.fillHand(deck.dealCard(), deck.dealCard(), deck.dealCard(), deck.dealCard());
            bot1.fillHand(deck.dealCard(), deck.dealCard(), deck.dealCard(), deck.dealCard());
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
            List<Card> Bot1Collection = bot1.getCollection();
            List<Card> PlayerCollection = player.getCollection();
            int playerPoints = 0;
            int bot1Points = 0;
            int playerClubs = 0;
            int bot1Clubs = 0;

            if(PlayerCollection.Count > Bot1Collection.Count)
            {
                playerPoints++;
                playerPoints++;
            }
            else if(PlayerCollection.Count == Bot1Collection.Count)
            {
                playerPoints++;
                bot1Points++;
            }
            else
            {
                bot1Points++;
                bot1Points++;
            }
            playerClubs = countClubs(PlayerCollection);
            bot1Clubs = countClubs(Bot1Collection);
            if (playerClubs > bot1Clubs)
            {
                playerPoints++;
            }
            else
            {
                bot1Points++;
            }
            playerPoints = playerPoints + beautifulCardPoints(PlayerCollection);
            bot1Points = bot1Points + beautifulCardPoints(Bot1Collection);


            MessageBox.Show("Player - " + playerPoints + "\n Bot - " + bot1Points);

           // System.IO.StreamWriter file = new System.IO.StreamWriter("..\\result.txt", true);
           // file.WriteLine(difficulty + "---Player:" + playerPoints + " -- Bot:" + bot1Points);
            //file.Close();
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
                if((card.imageName == "TwoClubs") || (card.imageName == "TenDiamonds"))
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
            else
            {
                foreach (Card card in fieldCards)
                {
                    bot1.addCardToCollection(card);
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