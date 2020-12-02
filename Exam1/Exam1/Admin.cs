using Exam1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam1
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection;
        private void Admin_Load(object sender, EventArgs e)
        {
            
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();

            SqlCommand accbio = new SqlCommand("SELECT * from Users", sqlConnection);
            SqlDataReader sqlReader = accbio.ExecuteReader();
            try
            {
                List<string[]> data = new List<string[]>();

                while (sqlReader.Read())
                {
                    data.Add(new string[7]);

                    data[data.Count - 1][0] = sqlReader[0].ToString();
                    data[data.Count - 1][1] = sqlReader[1].ToString();
                    data[data.Count - 1][2] = sqlReader[2].ToString();
                    

                }

                sqlReader.Close();



                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
            Assortiment();
            customers();
            sales();
            store();


        }



        //////////Ассортимент
        public void Assortiment()
        {
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();

            SqlCommand accbio = new SqlCommand("SELECT * from Assortiment", sqlConnection);
            SqlDataReader sqlReader = accbio.ExecuteReader();
            try
            {
                List<string[]> data = new List<string[]>();

                while (sqlReader.Read())
                {
                    data.Add(new string[7]);

                    data[data.Count - 1][0] = sqlReader[0].ToString();
                    data[data.Count - 1][1] = sqlReader[1].ToString();
                    data[data.Count - 1][2] = sqlReader[2].ToString();
                    data[data.Count - 1][3] = sqlReader[3].ToString();
                    data[data.Count - 1][4] = sqlReader[4].ToString();


                }

                sqlReader.Close();



                foreach (string[] s in data)
                    dataGridView2.Rows.Add(s);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }



        //////////Заказчики
        public void customers()
        {
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();

            SqlCommand accbio = new SqlCommand("SELECT * from Customers", sqlConnection);
            SqlDataReader sqlReader = accbio.ExecuteReader();
            try
            {
                List<string[]> data = new List<string[]>();

                while (sqlReader.Read())
                {
                    data.Add(new string[7]);

                    data[data.Count - 1][0] = sqlReader[0].ToString();
                    data[data.Count - 1][1] = sqlReader[1].ToString();
                    data[data.Count - 1][2] = sqlReader[2].ToString();
                    data[data.Count - 1][3] = sqlReader[3].ToString();
                    data[data.Count - 1][4] = sqlReader[4].ToString();


                }

                sqlReader.Close();



                foreach (string[] s in data)
                    dataGridView3.Rows.Add(s);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }


        //////////Продажи
        public void sales()
        {
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();

            SqlCommand accbio = new SqlCommand("SELECT * from Sales", sqlConnection);
            SqlDataReader sqlReader = accbio.ExecuteReader();
            try
            {
                List<string[]> data = new List<string[]>();

                while (sqlReader.Read())
                {
                    data.Add(new string[7]);

                    data[data.Count - 1][0] = sqlReader[0].ToString();
                    data[data.Count - 1][1] = sqlReader[1].ToString();
                    data[data.Count - 1][2] = sqlReader[2].ToString();
         


                }

                sqlReader.Close();



                foreach (string[] s in data)
                    dataGridView4.Rows.Add(s);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }

        //////////Склад
        public void store()
        {
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();

            SqlCommand accbio = new SqlCommand("SELECT * from Store", sqlConnection);
            SqlDataReader sqlReader = accbio.ExecuteReader();
            try
            {
                List<string[]> data = new List<string[]>();

                while (sqlReader.Read())
                {
                    data.Add(new string[7]);

                    data[data.Count - 1][0] = sqlReader[0].ToString();
                    data[data.Count - 1][1] = sqlReader[1].ToString();
                    data[data.Count - 1][2] = sqlReader[2].ToString();
                    data[data.Count - 1][3] = sqlReader[3].ToString();
                


                }

                sqlReader.Close();



                foreach (string[] s in data)
                    dataGridView5.Rows.Add(s);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
             sqlConnection.Open();
            try
            {
                if (login1.Text!="" && telephone1.Text != "" && email1.Text != "" && address1.Text != "" && name1.Text != "")
                {
                    SqlCommand CrtCst = new SqlCommand("INSERT INTO Customers ([User], Name, Telephone, Email, Address) VALUES (@User, @Name, @Telephone, @Email, @Address)", sqlConnection);
                    CrtCst.Parameters.AddWithValue("User", login1.Text);
                    CrtCst.Parameters.AddWithValue("Name", name1.Text);
                    CrtCst.Parameters.AddWithValue("Telephone", telephone1.Text);
                    CrtCst.Parameters.AddWithValue("Email", email1.Text);
                    CrtCst.Parameters.AddWithValue("Address", address1.Text);

                    CrtCst.ExecuteNonQuery();
                    MessageBox.Show("Заказчик добавлен!", "Готово",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    login1.Clear();
                    telephone1.Clear();
                    email1.Clear();
                    address1.Clear();
                    name1.Clear();


                }
                else
                {
                    MessageBox.Show("Заполните все необходимые поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

       

    }
}
