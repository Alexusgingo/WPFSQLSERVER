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
using System.Drawing;
using System.Drawing.Printing;

namespace Exam1
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection;
        private void Сustomer_Load(object sender, EventArgs e)
        {
            Assortiment();
            posInSale();
        }
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
                    dataGridView1.Rows.Add(s);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }
        public void posInSale()
        {
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();

            SqlCommand accbio = new SqlCommand("select  Name,Product,Count from Customers,Sales,PositionInSale where Customers.[User]=Customer;", sqlConnection);
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
                    dataGridView2.Rows.Add(s);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string b="";
            string con = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            string q = login1.Text;
            string w = date1.Text;
            try
            {
                if (login1.Text != "" && date1.Text != ""  && count1.Text != "" && product1.Text != "")
                {
                    SqlCommand CrtSales = new SqlCommand("INSERT INTO Sales (Customer, Date) VALUES (@Customer, @Date)", sqlConnection);
                    CrtSales.Parameters.AddWithValue("Customer", login1.Text);
                   
                    CrtSales.Parameters.AddWithValue("Date", date1.Text);
                    CrtSales.ExecuteNonQuery();
                    ////
                    SqlCommand find = new SqlCommand("select SaleID from Sales where Customer='@Customer' and Date='@Date' ", sqlConnection);
                    find.Parameters.AddWithValue("Customer", q);

                    find.Parameters.AddWithValue("Date", w);
                    SqlDataReader reader = find.ExecuteReader();
                    
                    if (reader.Read())
                    {

                        b = reader.GetString(0);
                    }
                    reader.Close();
                    /////
                    SqlCommand crtPosInSales = new SqlCommand("INSERT INTO PositionInSale (Customer, Date) VALUES (@Product, @Count)", sqlConnection);
                    
                    //crtPosInSales.Parameters.AddWithValue("Sale", b);
                    crtPosInSales.Parameters.AddWithValue("Count", count1.Text);
                    crtPosInSales.Parameters.AddWithValue("Product", product1.Text);
                    crtPosInSales.ExecuteNonQuery();
                    

                    
                    MessageBox.Show("Заказ добавлен!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    login1.Clear();
                    date1.Clear();
                    
                    count1.Clear();
                    product1.Clear();


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
            try
            {
                if (login1.Text != "" && date1.Text != "" && count1.Text != "" && product1.Text != "")
                {
                    SqlCommand CrtSales = new SqlCommand("INSERT INTO Sales (Customer, Date) VALUES (@Customer, @Date)", sqlConnection);
                    CrtSales.Parameters.AddWithValue("Customer", login1.Text);

                    CrtSales.Parameters.AddWithValue("Date", date1.Text);
                    CrtSales.ExecuteNonQuery();
                    ////
                    SqlCommand find = new SqlCommand("select SaleID from Sales where Customer=@Customer and Date=@Date ", sqlConnection);
                    find.Parameters.AddWithValue("Customer", q);

                    find.Parameters.AddWithValue("Date", w);
                    SqlDataReader reader = find.ExecuteReader();
                    reader.Read();
                    if (reader.Read())
                    {

                        b = reader.GetString(0);
                    }
                    reader.Close();
                    /////
                    SqlCommand crtPosInSales = new SqlCommand("INSERT INTO PositionInSale (Sale,Customer, Date) VALUES (@Sale, @Product, @Count)", sqlConnection);

                    crtPosInSales.Parameters.AddWithValue("Sale", b);
                    crtPosInSales.Parameters.AddWithValue("Count", count1.Text);
                    crtPosInSales.Parameters.AddWithValue("Product", product1.Text);
                    crtPosInSales.ExecuteNonQuery();



                    MessageBox.Show("Заказ добавлен!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    login1.Clear();
                    date1.Clear();

                    count1.Clear();
                    product1.Clear();


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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
