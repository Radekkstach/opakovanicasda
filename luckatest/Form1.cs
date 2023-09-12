using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luckatest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Vypis(List<int> list, ListBox listek)
        {
            foreach(int k in list)
            {
                listek.Items.Add(k);
            }
        }

        public int DruheCislo(List<int> list)
        {
            int max = 0;
            int druhe = 0;
            foreach (int x in list)
            {
                if(x > max)
                {
                    druhe = max;
                    max = x;                    
                }
                else if (x > druhe && x < max)
                {
                    druhe = x;
                }
            }

            return druhe;
        }

        public bool Dokonale(int x)
        {
            if(x <= 0) { return false; }

            int celkem = 0;
            for(int i =1;i< x; i++)
            {
                if((x % i) == 0)
                {
                    celkem += i;
                }
            }

            return celkem == x;
        }

        public void Mazat(List<int> list)
        {
            for(int i = list.Count - 1; i>= 0; i--)
            {
                if (Dokonale(list[i]) == true)
                {
                    list.RemoveAt(i);
                }
            }
        }

        public int CifernySoucet(List<int> list)
        {
            int celkem = 0;
            list.Sort();
            int max = list.Last();
            for(;max != 0; )
            {
                
                celkem = celkem + (max % 10);
                max = max / 10;
            }
            return celkem;
        }

        List<int> List1 = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List1.Clear();
            Random rng = new Random();
            int n = Convert.ToInt32(textBox1.Text);
            for(int i = n;i!=0; i--)
            {
                int jj = rng.Next(-5, 100);
                List1.Add(jj);
            }

            Vypis(List1, listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mazat(List1);
            Vypis(List1, listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List1.Sort();
            Vypis(List1, listBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double prumer = 0;
            foreach(int x in List1)
            {
                prumer += x;
            }
            prumer = prumer / (List1.Count);
            label1.Text = "" + prumer;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "Druhemaximum: " + DruheCislo(List1).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Text = CifernySoucet(List1).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            List<char> znacky = new List<char>();
            foreach(int x in List1)
            {
                if(x >= 65 && x <= 90)
                {
                    znacky.Add(Convert.ToChar(x));
                }
                else
                {
                    znacky.Add('*');
                }
            }
            foreach(char c in znacky)
            {
                listBox4.Items.Add(c);
            }
        }
    }
}
