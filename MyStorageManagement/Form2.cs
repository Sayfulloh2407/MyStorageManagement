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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        enum message
        {
             Check,
             Greate
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("AddProduct.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(comboBox1.Text + "?"+textBox3.Text+"?" + textBox1.Text + "?" + textBox2.Text + "?" + numericUpDown1.Value + "?");
                sw.Close();
                fs.Close();
                checkBox1.Checked = false;
                textBox3.Enabled = true;
                if (comboBox1.Text == "Headphones")
                {
                    Form3 form = new Form3();
                    form.ShowDialog();
                }
                else if (comboBox1.Text == "Camera")
                {
                    Form4 form = new Form4();
                    form.ShowDialog();
                }
                else if (comboBox1.Text == "Smartwatch")
                {
                    Form5 form = new Form5();
                    form.ShowDialog();
                }
                else if (comboBox1.Text == "Laptop")
                {
                    Form6 form = new Form6();
                    form.ShowDialog();
                }
                else if (comboBox1.Text == "TV")
                {
                    Form7 form = new Form7();
                    form.ShowDialog();
                }

                      comboBox1.Text = textBox3.Text = textBox1.Text = textBox2.Text = "";
                  numericUpDown1.Value = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please "+message.Check+" the type of Product!");
                    checkBox1.Checked=false;
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        MessageBox.Show(message.Greate + " ");
                        string m = comboBox1.Text;
                        textBox3.Enabled = false;
                        IdGenerator ID = new IdGenerator();
                        textBox3.Text = ID.IDLetter(m)+ ID.RandomNumber(4);
                    }
                    else
                    {
                        textBox3.Enabled = true;
                        textBox3.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
