using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopowa
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            if (Form3.score[0] == 1)
            {
                label2.Text = "Wygrywa";
                if (Form3.score[1] == 1)
                {
                    label3.Text = Form2.nick_1;
                    pictureBox1.Image = Form2.pfp1;
                }
                else
                {
                    label3.Text = Form2.nick_2;
                    pictureBox1.Image = Form2.pfp2;
                }
            }
            else
            {
                label2.Text = "Remis";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
