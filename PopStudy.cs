using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PopStudy
{
    public partial class PopStudy : Form
    {

        static int i = 1;

        public PopStudy()
        {
            InitializeComponent();

          

        }

        private void PopStudy_Load(object sender, EventArgs e)
        {
           
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //button that adds new textbox

            //TextBox tb = new TextBox();
            flowLayoutPanel1.Controls.Add(new TextBox() { Width = 249, Height = 100 });
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //randomly selecting card to study
            //odds are terms there reply with definition
            //evens are definition therefore reply with term


            int n;
            Random rand = new Random();
            n = rand.Next(1, 7);

            string s;
            string t;

            if (n % 2 == 0) {
                s = ((TextBox)flowLayoutPanel1.Controls["textBox" + n]).Text;
                MessageBox.Show("                                                Definition"
               + "\n                                                                                                            "
               + "\n                                                                                                            "
               + "\n" + s

               + "\n                                                                                                            ");

                n = n - 1;
                t = ((TextBox)flowLayoutPanel1.Controls["textBox" + n]).Text;
                MessageBox.Show("                                                     Term"
                + "\n                                                                                                            "
                + "\n                                                                                                            "
                + "\n" + t

                + "\n                                                                                                            ");

            }
            else
            {
                s = ((TextBox)flowLayoutPanel1.Controls["textBox" + n]).Text;
                MessageBox.Show("                                                     Term"
               + "\n                                                                                                            "
               + "\n                                                                                                            "

               + "\n" + s
               + "\n                                                                                                            ");

                n = n + 1;
                t = ((TextBox)flowLayoutPanel1.Controls["textBox" + n]).Text;

                MessageBox.Show("                                                Definition"
                + "\n                                                                                                            "
                + "\n                                                                                                            "

               + "\n" + t
                + "\n                                                                                                            ");

            }


        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //pops up a flashcard periodically

            timer1.Enabled = true;
            button1.PerformClick();
            
        }

       
    }
}
