using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyStorageManagement
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public string GetString(int breakpoint, int breakpointa)
        {
            string a = line.Substring(breakpoint, breakpointa);
            return a;
        }
        static string line, line1, line2, line3, line4, line5, line6, line7, line8, line9, line10;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("FullInfo.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            line=sr.ReadToEnd();
            int b = 0;
            for (int i = 0; i < 11; i++)
            {
                b = line.IndexOf("?");
                if (i == 0)
                {
                    pictureBox1.Load( GetString(0, b));
                    line = line.Remove(0, b + 1);
                }
                else if (i == 1)
                {
                    line1 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                    
                }
                else if (i == 2)
                {
                    line2 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 3)
                {
                    line3 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 4)
                {
                    line4 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 5)
                {
                    line5 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 6)
                {
                    line6 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 7)
                {
                    line7 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 8)
                {
                    line8 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 9)
                {
                    line9 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 10)
                {
                    line10 = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                textBox1.Text = line1;
                textBox2.Text = line2;
                textBox3.Text = line3;
                textBox4.Text = line4;
                textBox5.Text = line5;
                textBox6.Text = line6;
                textBox7.Text = line7;
                label2.Text = line8;
                if (line1 == "Headphones")
                {
                    label16.Text = "Headphone Type:";
                    label15.Text = "Color:";
                    label14.Text = "Loadness:";
                    label13.Text = line9;
                    label12.Text = line10;
                }
                if (line1 == "Camera")
                {
                    label16.Text = "Lens:";
                    label15.Text = "Color:";
                    label14.Text = line8;
                    label13.Text = line9;
                    label12.Text = line10;
                }
                if (line1 == "Smartwatch")
                {
                    label16.Text = "Smartwatch shape:";
                    label15.Text = "Color:";
                    label14.Text = line8;
                    label2.Text = "";
                    label13.Text = line9;
                    label12.Text = line10;
                }
                if (line1 == "Laptop")
                {
                    label16.Text = "Screen size:";
                    label15.Text = "Color:";
                    label14.Text = line8;
                    label13.Text = line9;
                    label12.Text = line10;
                }
                if (line1 == "TV")
                {
                    label16.Text = "Screen size:";
                    label15.Text = "Color:";
                    label14.Text = "Electracity usage(W/ph):";
                    label13.Text = line9;
                    label12.Text = line10;
                }
            }
        }
    }
}
