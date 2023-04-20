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

            //when progrtam starts, preload 3 sets of flashcards

            while(i < 7)
            {
                flowLayoutPanel1.Controls.Add(new RichTextBox() { Width = 249, Height = 100, BackColor = Color.LavenderBlush, Name = "richTextBox" + i });
                i++;
                flowLayoutPanel1.Controls.Add(new RichTextBox() { Width = 249, Height = 100, Name = "richTextBox" + i });
                i++;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            //button that adds 2 new textbox

            //int i = 7;

            flowLayoutPanel1.Controls.Add(new RichTextBox() { Width = 249, Height = 100, BackColor = Color.LavenderBlush, Name = "richTextBox" + i });
            i++;
            flowLayoutPanel1.Controls.Add(new RichTextBox() { Width = 249, Height = 100, Name = "richTextBox" + i });
            i++;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //randomly selecting card to study
            //odds are terms there reply with definition
            //evens are definition therefore reply with term

            //string s = ((RichTextBox)flowLayoutPanel1.Controls["richTextBox" + n]).Text;
            //MessageBox.Show(s);


            
            int n;
            Random rand = new Random();
            n = rand.Next(1, i);

            string s;
            string t;

            if (n % 2 == 0) {
                s = ((RichTextBox)flowLayoutPanel1.Controls["richTextBox" + n]).Text;
                MessageBox.Show("                                                Definition"
               + "\n                                                                                                            "
               + "\n                                                                                                            "
               + "\n" + s

               + "\n                                                                                                            ");

                n = n - 1;
                t = ((RichTextBox)flowLayoutPanel1.Controls["richTextBox" + n]).Text;
                MessageBox.Show("                                                     Term"
                + "\n                                                                                                            "
                + "\n                                                                                                            "
                + "\n" + t

                + "\n                                                                                                            ");

            }
            else
            {
                s = ((RichTextBox)flowLayoutPanel1.Controls["richTextBox" + n]).Text;
                MessageBox.Show("                                                     Term"
               + "\n                                                                                                            "
               + "\n                                                                                                            "

               + "\n" + s
               + "\n                                                                                                            ");

                n = n + 1;
                t = ((RichTextBox)flowLayoutPanel1.Controls["richTextBox" + n]).Text;

                MessageBox.Show("                                                Definition"
                + "\n                                                                                                            "
                + "\n                                                                                                            "

               + "\n" + t
                + "\n                                                                                                            ");

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //pops up a flashcard periodically

            timer1.Enabled = true;

            int n;
            Random rand = new Random();
            n = rand.Next(100000, 4000000);

            timer1.Interval = n;

            button1.PerformClick();
            
        }

    }
}
