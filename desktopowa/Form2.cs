using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopowa
{
    public partial class Form2 : Form
    {
        public static string nick_1 = string.Empty;
        public static string nick_2 = string.Empty;
        public static Image pfp1 = null;
        public static Image pfp2 = null;
        private static int pfp_1 = 1;
        private static int pfp_2 = 1;
        private bool ready_1 = false;
        private bool ready_2 = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!ready_1)
            {
                if (pfp_1 == 1)
                {
                    pfp_1 = 9;
                }

                pfp_1--;
                pictureBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("cat" + pfp_1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!ready_1)
            {
                if (pfp_1 == 8)
                {
                    pfp_1 = 0;
                }

                pfp_1++;
                pictureBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("cat" + pfp_1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!ready_2)
            {
                if (pfp_2 == 1)
                {
                    pfp_2 = 9;
                }

                pfp_2--;
                pictureBox2.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("cat" + pfp_2);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(!ready_2)
            {
                if (pfp_2 == 8)
                {
                    pfp_2 = 0;
                }

                pfp_2++;
                pictureBox2.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("cat" + pfp_2);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(!ready_1)
            {
                ready_1 = true;
                button5.BackColor = Color.Green;
            }
            else
            {
                ready_1 = false;
                button5.BackColor = Color.Black;
            }

            ready();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!ready_2)
            {
                ready_2 = true;
                button6.BackColor = Color.Green;
            }
            else
            {
                ready_2 = false;
                button6.BackColor = Color.Black;
            }

            ready();
        }

        private async void ready()
        {
            if (ready_1 && ready_2)
            {
                nick_1 = textBox1.Text;
                nick_2 = textBox2.Text;

                pfp1 = pictureBox1.Image;
                pfp2 = pictureBox2.Image;

                await Task.Delay(1000);
                this.Hide();
                new Form3().ShowDialog();
                this.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
