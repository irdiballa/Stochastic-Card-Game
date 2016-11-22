using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//this form is the first form shown
//where the user can select the 
//options he wants his gaem with
namespace SeniorProject
{
    
    public partial class NewGameForm : Form
    {
        int nrPlayers=0;                                                        //holds the number of AI players chosen
        //form constructor
        public NewGameForm()
        {
            InitializeComponent();
            
        }
        //starts a game when Easy is selected
        private void Easy_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();

            if (nrPlayers == 1)
            {
                GameForm2 frm = new GameForm2("easy");
                frm.Show();
            }
            else if (nrPlayers == 2)
            {
                GameForm3 frm = new GameForm3("easy");
                frm.Show();
            }
            else
            {
                GameForm4 frm = new GameForm4("easy");
                frm.Show();
            }
        }
        //starts a game when Medium is selected
        private void Medium_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();

            if (nrPlayers == 1)
            {
                GameForm2 frm = new GameForm2("medium");
                frm.Show();
            }
            else if (nrPlayers == 2)
            {
                GameForm3 frm = new GameForm3("medium");
                frm.Show();
            }
            else
            {
                GameForm4 frm = new GameForm4("medium");
                frm.Show();
            }
        }
        //starts a game when Hard is selected
        private void Hard_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();

            if (nrPlayers == 1)
            {
                GameForm2 frm = new GameForm2("hard");
                frm.Show();
            }
            else if (nrPlayers == 2)
            {
                GameForm3 frm = new GameForm3("hard");
                frm.Show();
            }
            else
            {
                GameForm4 frm = new GameForm4("hard");
                frm.Show();
            }
        }
        //sets the number of players to 1 AI + 1 Human
        private void VS1AI_CheckedChanged(object sender, EventArgs e)
        {
            nrPlayers = 1;
        }
        //sets the number of players to 2 AI + 1 Human
        private void VS2AI_CheckedChanged(object sender, EventArgs e)
        {
            nrPlayers = 2;
        }
        //sets the number of players to 3 AI + 1 Human
        private void VS3AI_CheckedChanged(object sender, EventArgs e)
        {
            nrPlayers = 3;
        }
          }
}
