using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

//This form will be displayed if the radio button
//vs 1 AI is checked

namespace SeniorProject
{
    public partial class GameForm2 : Form
    {
        string diff;                                            //holds the difficulty of the game
        Game game;                                              //instance of game with 1 AI + 1 Human
        Bitmap myImage1, myImage2, myImage3, myImage4, fieldImage, topFieldImage;       //will hold the images that will be displayed
        ResourceManager rm = SeniorProject.Properties.Resources.ResourceManager;        //resource manager
        string filename1, filename2, filename3, filename4, fieldcardname, topfieldcardname;  //will hold the name of the image file that needs to be displayed

        //constructor
        public GameForm2(string difficulty)
        {
            InitializeComponent();
            diff = difficulty;
            game = new Game(1, diff);
        }

        //called when the form is loaded 
        //will lay out the field
        private void GameForm2_Load(object sender, EventArgs e)
        {
            game.layField();
           
        }

        //calls the displayCards method when the form is shown on the screen
        private void GameForm2_Shown(object sender, EventArgs e)
        {
            displayCards();
        }

        //handles events when the player clicks his left-most card
        private void PlayerCard1_Click(object sender, EventArgs e)
        {
            
            
            game.playerThrowCard(1);
            lastCardThrown();

            updateFieldCard(); 
            PlayerCard1.Visible = false;
            this.Refresh();
            MyDelay(1);
            game.bot1ThrowCard();
            lastCardThrown();
            AI1Card3.Visible = false;
            updateFieldCard();

            
            if (game.player.isHandEmpty())
            {
                MessageBox.Show("Turn is Over");
                newRound();
            }
            
            
        }

        //handles events when the player clicks the second card from the left
        private void PlayerCard2_Click(object sender, EventArgs e)
        {
           
            game.playerThrowCard(2);
            lastCardThrown();
            updateFieldCard();
            PlayerCard2.Visible = false;
            this.Refresh();
            MyDelay(1);
            game.bot1ThrowCard();
            lastCardThrown();
            AI1Card1.Visible = false;
            updateFieldCard();
            
            
            if (game.player.isHandEmpty())
            {
                MessageBox.Show("Turn is Over");
                newRound();
            }
            
        }

        //handles events when the player clicks the third card from the left
        private void PlayerCard3_Click(object sender, EventArgs e)
        {
           
            game.playerThrowCard(3);
            lastCardThrown();
            updateFieldCard();
            PlayerCard3.Visible = false;
            this.Refresh();
            MyDelay(1);
            game.bot1ThrowCard();
            lastCardThrown();
            AI1Card4.Visible = false;
            updateFieldCard();
            
            
            
            if (game.player.isHandEmpty())
            {
                MessageBox.Show("Turn is Over");
                newRound();
            }
            
        }

        //handles events when the player clicks his right-most card
        private void PlayerCard4_Click(object sender, EventArgs e)
        {
            
            game.playerThrowCard(4);
            lastCardThrown();
            updateFieldCard();
            PlayerCard4.Visible = false;
            this.Refresh();
            MyDelay(1);
            game.bot1ThrowCard();
            lastCardThrown();
            AI1Card2.Visible = false;
            updateFieldCard();

            
            if (game.player.isHandEmpty())
            {
                MessageBox.Show("Turn is Over");
                newRound();
            }
            
        }

        //will make player cards visible
        //will make the back of computer cards visible
        //will make the field cards visible
        private void displayCards()
        {
            PlayerCard1.Visible = true;
            filename1 = game.player.hand.getFirstCardName();
            myImage1 = new Bitmap((Bitmap)rm.GetObject(filename1));
            PlayerCard1.BackgroundImage = (Image)myImage1;
            

            PlayerCard2.Visible = true;
            filename2 = game.player.hand.getSecondCardName();
            myImage2 = new Bitmap((Bitmap)rm.GetObject(filename2));
            PlayerCard2.BackgroundImage = (Image)myImage2;

            PlayerCard3.Visible = true;
            filename3 = game.player.hand.getThirdCardName();
            myImage3 = new Bitmap((Bitmap)rm.GetObject(filename3 ));
            PlayerCard3.BackgroundImage = (Image)myImage3;

            PlayerCard4.Visible = true;
            filename4 = game.player.hand.getFourthCardName();
            myImage4 = new Bitmap((Bitmap)rm.GetObject(filename4 ));
            PlayerCard4.BackgroundImage = (Image)myImage4;
            AI1Card1.Visible = true;
            AI1Card2.Visible = true;
            AI1Card3.Visible = true;
            AI1Card4.Visible = true;
            updateFieldCard();

        }

        //checks if the game is over
        //if not will start another round
        private void newRound()
        {
            if (game.isGameOver())
            {
                gameOver();
            }
            else
            {
                game.round();
                displayCards();
            }
        }

        //will add the last remaining cards to the player that collected last
        //will calculate the points
        private void gameOver()
        {
            MessageBox.Show("Game Over");
            game.addLastCards();
            game.calculatePoints();
            Application.Exit();
        }

        //will change the cards that are on the field
        private void updateFieldCard()
        {
            FieldCard.Visible = true;
            fieldcardname = game.getTopFieldCardName();
           
            if (fieldcardname == "empty")
            {
                fieldImage = new Bitmap((SeniorProject.Properties.Resources.back_image));
                FieldCard.BackgroundImage = (Image)fieldImage;
            }
            else
            {
                fieldImage = new Bitmap((Bitmap)rm.GetObject(fieldcardname));
                FieldCard.BackgroundImage = (Image)fieldImage;
            }
        }

        //a method that will delay all actions for a certain amount of seconds
        public static void MyDelay(int seconds)
        {
            DateTime ts = DateTime.Now + TimeSpan.FromSeconds(seconds);

            do { } while (DateTime.Now < ts);
        }

        //will end the application when the x (close button) is pressed
        private void GameForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //will change the right image on the field to the last card that was thrown
        private void lastCardThrown()
        {

            topfieldcardname = game.getlastCardThrownName();
            topFieldImage = (Bitmap)rm.GetObject(topfieldcardname);
            topFieldCard.BackgroundImage = (Image)topFieldImage;
          
        }

    }
}

