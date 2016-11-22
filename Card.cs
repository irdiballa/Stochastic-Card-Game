using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorProject
{
    class Card
    {
          public string imageName;

        //most used variables with get and set methods
        private string face, suit;

        public void setFace(string f)
        {
            face = f;
        }
        public string getFace()
        {
            return face;
        }
        public void setSuit(string s)
        {
            suit = s;
        }
        public string getSuit()
        {
            return suit;
        }

        //constructor for a known card
        public Card(string cardFace, string cardSuit){
            this.face = cardFace;
            this.suit = cardSuit;
            imageName = getFace() + suit;
    }

        //constructor for a null card
        public Card()
        {

        }

        
        
        //returns the imageName
        public string getImageLink(){
            return imageName;
        }

        //returns a copy of the card instead of the real one
        public Card ReturnCopy()
{
    Card newItem = new Card();

    newItem.face = getFace();
    newItem.suit = suit;
    newItem.imageName = imageName;
    return newItem;

}
    }
}
