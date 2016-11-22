using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorProject
{
    class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int NUMBER_OF_CARDS = 52;
        private Random randNum;

        //constructor
        public Deck()
        {
            string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] suits = {"Hearts","Clubs","Diamonds","Spades"};

            deck = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            randNum = new Random();
            for (int i =0 ; i<deck.Length ; i++){
                deck[i] = new Card(faces[i%13], suits[i/13]);
            }}

        //shuffles deck
        public void shuffleDeck(){
                currentCard = 0;
                for(int first =0 ; first<deck.Length; first++){
                    int second = randNum.Next(NUMBER_OF_CARDS);
                    Card temp = deck[first];
                    deck[first] = deck[second];
                    deck[second] = temp;
                } }

        //deals the next card
        public Card dealCard(){
            if (currentCard < deck.Length ){
                currentCard++;
        return deck[currentCard-1];
        }
            else{
                return null;
        }
        }

        // returns the next card in the deck without dealing it
        public string getCurrentCard() {
            string kot = deck[currentCard - 1].getFace() + deck[currentCard - 1].getSuit() + currentCard;
            return kot;
        }

        //checks if deck is over. This is used when ending the game
        public bool isDeckOver()
        {
            if (currentCard > 51)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        }
    }

