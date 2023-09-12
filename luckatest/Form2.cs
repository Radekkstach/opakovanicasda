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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public bool Prvocislo(int cislo)
        {
            if(cislo <= 1)
            {
                return false;
            }
            for(int i = 2; i <= (Math.Sqrt(cislo));i++)
            {
                if(cislo % i == 0)
                {
                    return false;
                }
            }
            return true;

        }

        public bool PoslPrvocislo(int[] pole, out int posledniPrvocislo, out int pozicePrvocislo)
        {
            posledniPrvocislo = 0;
            pozicePrvocislo= 0;

            for(int i = pole.Length - 1; i >= 0; i--)
            {
                if (Prvocislo(pole[i])== true)
                {
                    posledniPrvocislo = pole[i];
                    pozicePrvocislo = i;
                    return true;
                }
            }
             return false;
        }

        public void Vymen(int[] pole)
        {
            int pomocna = 0;
            pomocna = pole[0];
            pole[0] = pole[pole.Length-1];
            pole[pole.Length - 1] = pomocna;
        }
        public void Vypis(int[] pole, ListBox listecek)
        {
            foreach(int i in pole)
            {
                listecek.Items.Add(i);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int posledniPrvocislo = 0;
            int pozicePrvocislo = 0;
            int n = (int)numericUpDown1.Value;
            int[] pole = new int[n];
            Random rng = new Random();
            for(int i = 0; i < n; i++)
            {
                pole[i] = rng.Next(0, 25);
            }
            Vypis(pole, listBox1);
            PoslPrvocislo(pole,out posledniPrvocislo,out pozicePrvocislo);
            label2.Text = "posledni: " + posledniPrvocislo;
            pozicePrvocislo++;
            label3.Text = "pozice: " + pozicePrvocislo;
            Vymen(pole);
            Vypis(pole, listBox2);



        }
    }
}
