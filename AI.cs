using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is the base class from where
// AIEasy, AIMedium nand AIHard inherit
namespace SeniorProject
{
    class AI
    {
        private Hand hand;        //variable for the hand
        private Card card;        //variable for a sample card
        private List<Card> botCollection;   //collection of the bot

        //constructor
        public AI()
        {
            hand = new Hand();
            card = new Card();
            botCollection = new List<Card>();
        }

        //virtual methods that are overriden in the child classes
        public virtual void fillHand(Card first, Card second, Card third, Card fourth)
        {

        }
        public virtual Card throwCard(Card topcard)
        {
            return card;
        }
        public virtual void addCardToMemory(Card card)
        {

        }

        //adds a card to the collection
        public void addCardToCollection(Card card)
        {
            botCollection.Add(card);
        }

        //returns the cards of the collection
        public List<Card> getCollection()
        {
            return botCollection;
        }
    }
   
}
