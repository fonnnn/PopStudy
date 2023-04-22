using PopStudy.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;
namespace PopStudy
{
    public partial class PopStudy : Form
    {
        static int i = 1; //keeps track of the flash card number
        static int defIndex = 1; //keep track of the definition card number
        static int termIndex = 1; //keep tract of the term card number
        int fontSize = 8; //font size of delete button
        public int timerIntervalMin;


        public PopStudy()
        {
            InitializeComponent();

        }

        private void PopStudy_Load(object sender, EventArgs e)
        {
            timerIntervalMin = 60000 * 20;
            timer1.Enabled = true;
            label1.Text = ("Every " + timerIntervalMin / 60000 + "-ish min");

            while (defIndex < 7)
            {
                Button button = new Button() { Name = "deleteButton_" + i, Text = "Delete" };    //creates button
                button.Font = new Font(button.Font.FontFamily, fontSize); //change size of font of button to fit word
                button.Click += new System.EventHandler(this.button2_Click); //what happens when button is clicked, calls button2_click function

                //creates and displays controls
                flowLayoutPanel1.Controls.AddRange(new Control[] { button, new RichTextBox() { Width = 249, Height = 100, Name = "richTextBox" + i, Text = "Term " + termIndex } });
                termIndex++;
                i++;
                flowLayoutPanel1.Controls.Add(new RichTextBox() { Width = 249, Height = 100, BackColor = Color.Azure, Name = "richTextBox" + i, Text = "Definition " + defIndex });
                defIndex++;
                i++;
            }
        }

        private void PopStudy_FormClosing(object sender, FormClosingEventArgs e) { }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            //button that adds 2 new textbox and a delete button that deletes both flashcards
            //int i = 7;
            Button button = new Button() { Name = "deleteButton_" + i, Text = "Delete" };  //creates button
            button.Font = new Font(button.Font.FontFamily, fontSize);
            button.Click += new System.EventHandler(this.button2_Click); //what happens when button is clicked, calls button2_click function

            //creates and displays controls
            flowLayoutPanel1.Controls.AddRange(new Control[] { button, new RichTextBox() { Width = 249, Height = 100, Name = "richTextBox" + i, Text = "Term " + termIndex } });
            termIndex++;
            i++;
            flowLayoutPanel1.Controls.Add(new RichTextBox() { Width = 249, Height = 100, BackColor = Color.Azure, Name = "richTextBox" + i, Text = "Definition " + defIndex });
            defIndex++;
            i++;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.flowLayoutPanel1.Controls.Count == 0) //if all cards are deleted, displays a disappointing message
            {
                MessageBox.Show("                                  WhY yOu NoT sTuDyInG???"
                     + "\n                                                                                                            "
                     + "\n                                                                                                            "
                     + "\n" + "Let's study something!"

                     + "\n                                                                                                            ");
            }
            else
            {
                //randomly selecting card to study
                //odds are terms there reply with definition
                //evens are definition therefore reply with term
                Random rand = new Random();
                int n = rand.Next(1, this.flowLayoutPanel1.Controls.Count); //randomly gets the card number to choose from
                int m = rand.Next(1, 3); //randomize whether def comes up first or term
                string s;
                string t;

                //pops up message box called string from richtextbox by index and not name because (names + def/termindex) can get deleted which causes error
                //using n as index of control on the panel
                //index divisible by 3 are deinition cards
                if (n % 3 == 0) //displays definition first
                {
                    if (m == 1)
                    {
                        t = flowLayoutPanel1.Controls[(n - 1)].Text;
                        MessageBox.Show("                                                Definition"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + t

                         + "\n                                                                                                            ");
                        s = flowLayoutPanel1.Controls[(n - 2)].Text;
                        MessageBox.Show("                                                   Term"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + s

                         + "\n                                                                                                            ");
                    }
                    else
                    {
                        t = flowLayoutPanel1.Controls[(n - 2)].Text;
                        MessageBox.Show("                                                   Term"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + t

                         + "\n                                                                                                            ");
                        s = flowLayoutPanel1.Controls[(n - 1)].Text;
                        MessageBox.Show("                                                Definition"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + s

                         + "\n                                                                                                            ");
                    }
                }

                else //the either delete button or term cards indexes
                {
                    if ((n + 1) % 3 == 0) //means this is term card which are one less than def cards
                    {
                        if (m == 1)
                        {
                            t = flowLayoutPanel1.Controls[n].Text;
                            MessageBox.Show("                                                Definition"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + t

                         + "\n                                                                                                            ");
                            s = flowLayoutPanel1.Controls[(n - 1)].Text;
                            MessageBox.Show("                                                   Term"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + s

                         + "\n                                                                                                            ");
                        }
                        else
                        {
                            t = flowLayoutPanel1.Controls[(n - 1)].Text;
                            MessageBox.Show("                                                   Term"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + t

                         + "\n                                                                                                            ");
                            s = flowLayoutPanel1.Controls[n].Text;
                            MessageBox.Show("                                                Definition"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + s

                         + "\n                                                                                                            ");
                        }
                    }

                    else //delete buttons
                    {
                        if (m == 1)
                        {
                            t = flowLayoutPanel1.Controls[(n + 1)].Text;
                            MessageBox.Show("                                                Definition"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + t

                         + "\n                                                                                                            ");
                            s = flowLayoutPanel1.Controls[(n)].Text;
                            MessageBox.Show("                                                   Term"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + s

                         + "\n                                                                                                            ");
                        }
                        else
                        {
                            t = flowLayoutPanel1.Controls[(n)].Text;
                            MessageBox.Show("                                                   Term"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + t

                         + "\n                                                                                                            ");
                            s = flowLayoutPanel1.Controls[(n + 1)].Text;
                            MessageBox.Show("                                                Definition"
                         + "\n                                                                                                            "
                         + "\n                                                                                                            "
                         + "\n" + s

                         + "\n                                                                                                            ");
                        }
                    }

                }
            }

        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            //pops up a flashcard randomly
            timer1.Enabled = true;
            int n;
            Random rand = new Random();
            n = rand.Next(timerIntervalMin / 2, timerIntervalMin);
            timer1.Interval = n;
            button1.PerformClick();
            Console.WriteLine(n);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button); //reference the button that was clicked
            int buttonIndex = int.Parse(button.Name.Split('_')[1]); //gets index of button

            //remove the delete button and 2 associated flashcards
            if (flowLayoutPanel1.Controls.Contains(button))
            {
                button.Click -= new System.EventHandler(this.button3_Click);
                flowLayoutPanel1.Controls.Remove(button);
                button.Dispose();
                flowLayoutPanel1.Controls.RemoveByKey("richTextBox" + (buttonIndex));
                termIndex--;
                flowLayoutPanel1.Controls.RemoveByKey("richTextBox" + (buttonIndex + 1));
                defIndex--;
                i--;

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timerIntervalMin += 60000; //default almost every 20 minutes
            label1.Text = ("Every " + timerIntervalMin / 60000 + "-ish min");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (timerIntervalMin <= 60000) { timerIntervalMin = 60000; } //timer interval cannot be 0 min
            else { timerIntervalMin -= 60000; }//default almost every 20 minutes

            label1.Text = ("Every " + timerIntervalMin / 60000 + "-ish min");
        }

        private void label1_Click(object sender, EventArgs e) { }
    }


}
