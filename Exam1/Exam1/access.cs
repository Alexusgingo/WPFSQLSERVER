using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam1
{
    public partial class access : Form
    {
        Random rnd = new Random();
        public access()
        {
            InitializeComponent();
        }
        private void GenerateCapcha()
        {
            string fullAlphabet = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

            label2.Text = "";
            for (int i = 0; i < 5; ++i)
                label2.Text += fullAlphabet[rnd.Next(fullAlphabet.Length)];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == label2.Text)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
            else
            {
                textBox1.Clear();
                GenerateCapcha();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            GenerateCapcha();
        }

        private void access_Load(object sender, EventArgs e)
        {
            
            GenerateCapcha();
        }

        private void access_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
