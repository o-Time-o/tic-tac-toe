using System;
using System.Media;
using System.Windows.Forms;

namespace desktopowa
{
    public partial class Form3 : Form
    {
        public static int[] score;
        private char[,] board;
        private int currentPlayer;

        private SoundPlayer soundPlayer = new SoundPlayer();

        public Form3()
        {
            InitializeComponent();
            PlayMusic();
            label1.Text = Form2.nick_1;
            label2.Text = Form2.nick_2;
            pictureBox2.Image = Form2.pfp1;
            pictureBox3.Image = Form2.pfp2;

            score = new int[2];
            board = new char[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
            currentPlayer = 1;
        }

        private void PictureBox_Click(int x, int y, object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;

            if (clickedPictureBox.Tag != null && (bool)clickedPictureBox.Tag == true)
                return;

            clickedPictureBox.Tag = true;

            char currentPlayerSymbol = (currentPlayer == 1) ? 'o' : 'x';

            board[x, y] = currentPlayerSymbol;
            clickedPictureBox.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(currentPlayerSymbol.ToString());

            gameStatus();

            if (score[0] == 1)
            {
                score[0] = 1;
                score[1] = currentPlayer;
                this.Hide();
                new Form4().ShowDialog();
                this.Close();
            }
            else if (score[0] == 2)
            {
                score[0] = 2;
                score[1] = 0;
                this.Hide();
                new Form4().ShowDialog();
                this.Close();
            }

            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox_Click(0, 0, sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox_Click(1, 0, sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox_Click(2, 0, sender, e);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox_Click(0, 1, sender, e);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PictureBox_Click(1, 1, sender, e);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PictureBox_Click(2, 1, sender, e);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            PictureBox_Click(0, 2, sender, e);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            PictureBox_Click(1, 2, sender, e);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            PictureBox_Click(2, 2, sender, e);
        }

        private void gameStatus()
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != ' ' &&
                    board[row, 0] == board[row, 1] &&
                    board[row, 1] == board[row, 2])
                {
                    score[0] = 1;
                    return;
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] != ' ' &&
                    board[0, col] == board[1, col] &&
                    board[1, col] == board[2, col])
                {
                    score[0] = 1;
                    return;
                }
            }

            if (board[0, 0] != ' ' &&
                board[0, 0] == board[1, 1] &&
                board[1, 1] == board[2, 2])
            {
                score[0] = 1;
                return;
            }

            if (board[0, 2] != ' ' &&
                board[0, 2] == board[1, 1] &&
                board[1, 1] == board[2, 0])
            {
                score[0] = 1;
                return;
            }

            bool isBoardFilled = true;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        isBoardFilled = false;
                        break;
                    }
                }
                if (!isBoardFilled)
                    break;
            }

            if (isBoardFilled)
            {
                score[0] = 2;
                return;
            }
        }
        private void PlayMusic()
        {
            soundPlayer.SoundLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_music.wav");
            soundPlayer.PlayLooping();
        }
    }
}