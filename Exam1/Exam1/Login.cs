using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting;

namespace Exam1
{
    public partial class Login : Form
    {
       
        string connectionString = @"Data Source=DESKTOP-A8O78SR\SQLEXPRESS;Initial Catalog=MurmanRyb;Integrated Security=True";
        public static string login;
        public static string password;
        public string labname,labrol;
        
        //public static string alg { get; set; }
        //public static string blg { get; set; }
        //public static string ulg { get; set; }

        public Login()
        {
            InitializeComponent();
        }
        public static int access = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (login1.Text != "" && password1.Text != "")
                {
                    string sqlcommand = "";
                 

                    switch(role.Text)
                    {
                        case "":
                            MessageBox.Show("Выберите роль!", "Не выбрана роль", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "Не выбрано":

                            MessageBox.Show("Выберите роль!", "Не выбрана роль", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            break;
                        case "Администратор":

                            sqlcommand = String.Format("SELECT * FROM Users WHERE Login='{0}' and Password='{1}' and Role='Администратор'", login1.Text, password1.Text);
                            
                            break;
                        case "Заказчик":
                            sqlcommand = String.Format("SELECT * FROM Users WHERE Login='{0}' and Password='{1}' and Role='Заказчик'", login1.Text, password1.Text);
                            login = login1.Text;
                            break;
                       

                    }
                    using (SqlConnection connection=new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlcommand,connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            login = login1.Text;
                            password = password1.Text;
                            while (reader.Read())
                            {
                                switch (role.Text)
                                {
                                    case "Администратор":
                                        //blg = login;
                                        Admin admin = new Admin();
                                        admin.Show();
                                        this.Hide();
                                        break;
                                    case "Заказчик":
                                        //llg = login;

                                        Customer customer = new Customer();
                                        customer.Show();
                                        this.Hide();
                                       
                                        break;
                                   

                                }
                            }
                        }
                        else
                        {
                            if (access == 0)
                            {
                                MessageBox.Show("Данные введены неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                login1.Clear();
                                password1.Clear();
                                //access++;
                            }
                            else 
                               if(access==1)
                            {
                                this.Visible = false;
                                access access = new access();
                                access.ShowDialog();
                                login1.Clear();
                                password1.Clear();
                            }
                        }
                        

                    }

            
                }
                else
                {
                    MessageBox.Show("Введите данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());          
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            



        }

        private void s(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                password1.UseSystemPasswordChar = false;
            }
            else
            {
                password1.UseSystemPasswordChar = true;
            }
        }
    }
}
