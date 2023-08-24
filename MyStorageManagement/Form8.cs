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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            byproducttype = new Dictionary<string, string>();
            byproductid = new Dictionary<string, string>();
            byproductproducer = new Dictionary<string, string>();
            bynumber = new Dictionary<int, string>();

        }
        Dictionary<string, string> byproducttype;
        Dictionary<string, string> byproductid;
        Dictionary<string, string> byproductproducer;
        Dictionary<int, string> bynumber;
        List<string> keys;
        List<string> keys1;
        static string dic,line,pic;
        static int x,y,dicn;
        
        private void Form8_Load(object sender, EventArgs e)
        {
            try {
                FileStream fs = new FileStream("ProductList.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                x = 0;
                while (!sr.EndOfStream)
                {
                    string p, o;
                    x++;
                    line = sr.ReadLine();
                    int a =line.IndexOf("?");
                    string b = GetString(0, a);
                    string z = line;
                    z = z.Remove(0, z.IndexOf("?") + 1);
                    p= z.Substring(0, z.IndexOf("?"));
                    byproducttype.Add(b+p, line);
                    keys = new List<string>(byproducttype.Keys);
                    bynumber.Add(x, b+p);
                    b=z.Substring(0,z.IndexOf("?"));
                    byproductid.Add(b, line);
                    z = z.Remove(0, z.IndexOf("?")+1);
                    b = z.Substring(0, z.IndexOf("?"));
                    byproductproducer.Add(b+p, line);
                    keys1 = new List<string>(byproductproducer.Keys);

                }
                sr.Close();
                fs.Close();
                if (x != 0)
                {
                    dicn = 1;
                    dic = bynumber[dicn];
                    line = byproducttype[dic];
                    InfoSeparator();
                    buttonleft.Enabled = false;
                    if (x == 1)
                    {
                        buttonright.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("There is no product available." +
                        "Please enter a product to the system first!!!") ;
                }
                label3.Text = Convert.ToString(dicn) + "OUT OF" + Convert.ToString(x);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetString(int breakpoint, int breakpointa)
        {
            string a = line.Substring(breakpoint, breakpointa);
            return a;
        }

        private void InfoSeparator()
        {
            int b = 0;
            for (int i = 0; i < 10; i++)
            {

                b = line.IndexOf("?");
                if (i == 0)
                {
                    label13.Text = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 1)
                {
                    label12.Text = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 2)
                {
                    label11.Text = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 3)
                {
                    label10.Text = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 4)
                {
                    label9.Text = GetString(0, b);
                    line = line.Remove(0, b + 1);
                }
                else if (i == 5)
                {
                    pic = GetString(0, b);
                    pictureBox1.Load( GetString(0, b));
                    line = line.Remove(0, b + 1);
                }
            }
        }

        private void buttonright_Click(object sender, EventArgs e)
        {
            buttonleft.Enabled = true;
            dicn++;
            dic = bynumber[dicn];
            line = byproducttype[dic];
            InfoSeparator();
            if (dicn == x)
            {
                buttonright.Enabled = false;
            }
            label3.Text = Convert.ToString(dicn) + "OUT OF" + Convert.ToString(x);
        }

        private void buttonleft_Click(object sender, EventArgs e)
        {
            dicn--;
            dic = bynumber[dicn];
            line = byproducttype[dic];
            InfoSeparator();
            if (dicn == 1)
            {
                buttonleft.Enabled = false;
            }
                buttonright.Enabled = true;
            label3.Text = Convert.ToString(dicn) + "OUT OF" + Convert.ToString(x);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileStream fs= new FileStream("ProductList.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            keys.Remove(label13.Text+label12);
            foreach (string key in keys)
            {
                sw.WriteLine(byproducttype[key]);
            }
            sw.Close();
            fs.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream("FullInfo.txt", FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(pic+"?"+label13.Text+"?"+ label12.Text+"?"+ label11.Text+"?"+ label10.Text+"?"+ label9.Text+"?"+line);
            sw.Close();
            file.Close();
            Form9 form = new Form9();
            form.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "_______________";
                buttonright.Enabled = false;
                buttonleft.Enabled = false;
                string a = "";
                if (radioButton1.Checked == true)
                {
                    foreach(string s in keys)
                    {
                        if (s.Contains(textBox1.Text))
                        {
                            dic = s;
                            line = byproducttype[dic];
                            InfoSeparator();
                        }
                    }
                    
                }
                else if (radioButton2.Checked == true)
                {
                    dic = textBox1.Text;
                    line = byproductid[dic];
                    InfoSeparator();
                }
                else if (radioButton3.Checked == true)
                {
                    foreach (string s in keys1)
                    {
                        if (s.Contains(textBox1.Text))
                        {
                            dic = s;
                            line = byproductproducer[dic];
                            InfoSeparator();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please choose one of 3 choices below!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true || radioButton1.Checked == true || radioButton3.Checked == true||textBox1.Text!="")
            {
                radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
                textBox1.Text = "";
            }
            bynumber.Clear();
            byproductid.Clear();
            byproductproducer.Clear();
            byproducttype.Clear();  
            Form8_Load(sender, e);
            buttonright.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
                this.Close();
                byproducttype.Clear();
        }
        
    }
}
