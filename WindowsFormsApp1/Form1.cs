using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        
        int counter = 0;

        Label firsttClicked, secondClicked;

        public Form1()
        {

            InitializeComponent();
            AssignIconsToSquares();
            

        }

        private void label_Click(object sender, EventArgs e)
        {
            if (firsttClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.White)
                return;

            if (firsttClicked == null)
            {
                firsttClicked = clickedLabel;
                firsttClicked.ForeColor = Color.White;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.White;

            

            if (firsttClicked.Text == secondClicked.Text)
            {
                firsttClicked = null;
                secondClicked = null;
                counter++;

            }
            else
            timer1.Start();

            CheckForWinner();
        }
        public void CheckForWinner()
        {        
            if (counter == 8)
            {
                MessageBox.Show("You matched all the icons!", "Congratulations");
                Close();
            }              
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          timer1.Stop();

            firsttClicked.ForeColor = firsttClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firsttClicked = null;
            secondClicked = null;
        }

        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
          
            }

        }

       
       
    }
}
