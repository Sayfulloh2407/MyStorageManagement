﻿using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this .Close();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        static string filename="Camera.jpg";
        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                string line;
                FileStream fs = new FileStream("AddProduct.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                line = sr.ReadLine();
                sr.Close();
                fs.Close();
                FileStream fs1 = new FileStream("ProductList.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1);
                line = line + $"images\\{filename}" + "?" + comboBox1.Text + "?" + textBox1.Text + "?" ;
                if (checkBox1.Checked)
                {
                    line = line + "Touchscreen" + "?";
                }
                else
                {
                    line = line + "Not touchscreen";
                }
                if (checkBox2.Checked)
                {
                    line = line + "Camerabag included" + "?";
                }
                else
                {
                    line = line + "Camerabag not included"+"?";
                }
                    if (checkBox2.Checked)
                    {
                        line = line + "Charger included" + "?";
                    }
                    else
                    {
                        line = line + "Charger not included"+"?";
                    }

                    sw.WriteLine(line);
                sw.Close();
                fs1.Close();
                comboBox1.Text = textBox1.Text = "";
                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
                {
                    checkBox2.Checked = checkBox1.Checked = checkBox3.Checked = false;
                }
                pictureBox1.Image = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog f7ofdp = new OpenFileDialog();
                f7ofdp.Filter = "jpg Image | * .jpg|png Image|*.png";
                if (f7ofdp.ShowDialog() == DialogResult.OK)
                {
                    string imgloc = f7ofdp.FileName;
                    filename = imgloc.Substring(imgloc.LastIndexOf('\\') + 1);

                    if (!Directory.Exists(@"./images"))
                    {
                        Directory.CreateDirectory(@"./images");
                    }
                    File.Copy(imgloc, $"images\\{filename}", true);
                    pictureBox1.Load(imgloc);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
