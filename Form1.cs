using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe_Game.Properties;

namespace TicTacToe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblPlayerName.Text = getCurrentPlayerName();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.White;

            Pen myPen = new Pen(white);
            myPen.Width = 10;

            myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            int startx = 700;
            int starty = 150;
            int endx = 700;
            int endy = 600;

            //                          (700, 100)    (700, 550)
            e.Graphics.DrawLine(myPen, startx, starty, endx, endy);

            //                          (850, 100)     (850, 550)
            e.Graphics.DrawLine(myPen, startx + 150, starty, endx + 150, endy);

            //                         (550, 300)        (1000, 850) 
            e.Graphics.DrawLine(myPen, startx - 150, starty + 150, endx + 300, starty + 150);

            //                         (550, 450)        (1000, 1000) 
            e.Graphics.DrawLine(myPen, startx - 150, starty + 300, endx + 300, starty + 300);




        }

        private bool checkWinner(string player = "x")
        {
            bool iswinner = false;
            Color winnerColor = Color.LightGreen;

            // Check rows, columns, and diagonals for player 1
            if (pictureBox1.Tag == player && pictureBox2.Tag == player && pictureBox3.Tag == player)
            {
                pictureBox1.BackColor = winnerColor;
                pictureBox2.BackColor = winnerColor;
                pictureBox3.BackColor = winnerColor;
                iswinner = true;
            }
            else if(pictureBox4.Tag == player && pictureBox5.Tag == player && pictureBox6.Tag == player)
            {
                pictureBox4.BackColor = winnerColor;
                pictureBox5.BackColor = winnerColor;
                pictureBox6.BackColor = winnerColor;
                iswinner = true;
            }
            else if(pictureBox7.Tag == player && pictureBox8.Tag == player && pictureBox9.Tag == player)
            {
                pictureBox7.BackColor = winnerColor;
                pictureBox8.BackColor = winnerColor;
                pictureBox9.BackColor = winnerColor;
                iswinner = true;
            }
            else if(pictureBox1.Tag == player && pictureBox4.Tag == player && pictureBox7.Tag == player)
            {
                pictureBox1.BackColor = winnerColor;
                pictureBox4.BackColor = winnerColor;
                pictureBox7.BackColor = winnerColor;
                iswinner = true;
            }
            else if(pictureBox2.Tag == player && pictureBox5.Tag == player && pictureBox8.Tag == player)
            {
                pictureBox2.BackColor = winnerColor;
                pictureBox5.BackColor = winnerColor;
                pictureBox8.BackColor = winnerColor;
                iswinner = true;
            }
            else if(pictureBox3.Tag == player && pictureBox6.Tag == player && pictureBox9.Tag == player)
            {
                pictureBox3.BackColor = winnerColor;
                pictureBox6.BackColor = winnerColor;
                pictureBox9.BackColor = winnerColor;
                iswinner = true;
            }
            else if(pictureBox1.Tag == player && pictureBox5.Tag == player && pictureBox9.Tag == player)
            {
                pictureBox1.BackColor = winnerColor;
                pictureBox5.BackColor = winnerColor;
                pictureBox9.BackColor = winnerColor;
                iswinner = true;
            }
            else if(pictureBox3.Tag == player && pictureBox5.Tag == player && pictureBox7.Tag == player)
            {
                pictureBox3.BackColor = winnerColor;
                pictureBox5.BackColor = winnerColor;
                pictureBox7.BackColor = winnerColor;
                iswinner = true;
            }

            return iswinner;
        }

        private string currentPlayer = "x";

        private bool gameOver = false;

        private Single count = 0;



        private void pictureBox_Click(object sender, EventArgs e)
        {
            playATurn((PictureBox)sender);
        }

        private void changePlayer()
        {
            currentPlayer = currentPlayer == "x" ? "o" : "x";
            if (gameOver)
            {
                lblPlayerName.Text = "Game Over!";
            }
            else
            {
                lblPlayerName.Text = getCurrentPlayerName();
            }
        }

        private string getCurrentPlayerName()
        {
            return currentPlayer == "x" ? "Player 1 (X)" : "Player 2 (O)";
        }

        private void ResetPictureBox(PictureBox pb)
        {
            pb.BackColor = Color.Transparent;
            pb.Tag = null;
            pb.Image = Resources.question_mark_96;
        }
        private void resetGame()
        {
            count = 0;
            gameOver = false;
            currentPlayer = "x";
            lblPlayerName.Text = getCurrentPlayerName();
            lblWinnerName.Text = "In Progress...";
            ResetPictureBox(pictureBox1);
            ResetPictureBox(pictureBox2);
            ResetPictureBox(pictureBox3);
            ResetPictureBox(pictureBox4);
            ResetPictureBox(pictureBox5);
            ResetPictureBox(pictureBox6);
            ResetPictureBox(pictureBox7);
            ResetPictureBox(pictureBox8);
            ResetPictureBox(pictureBox9);
        }


        private void endGameAndShowWinner()
        {
            gameOver = true;
            string winner = currentPlayer == "x" ? "Player 1 (X)" : "Player 2 (O)";
            lblWinnerName.Text = $"{winner} Wins!";
        }


        private void endGameAndShowDarw()
        {
            gameOver = true;
            lblWinnerName.Text = "Draw!";
        }

        private void playATurn(PictureBox sender)
        {
            if (sender.Tag == null && !gameOver)
            {
                count++;
                sender.Tag = currentPlayer;

                if (currentPlayer == "x")
                {
                    sender.Image = Properties.Resources.X;
                }
                else
                {
                    sender.Image = Properties.Resources.O;
                }


                if (checkWinner(currentPlayer))
                {
                    endGameAndShowWinner();
                }
                else if (count == 9)
                {
                    endGameAndShowDarw();
                }

                changePlayer();
            } else if(count == 9 && !gameOver)
            {
                endGameAndShowDarw();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetGame();
        }
    }
}
