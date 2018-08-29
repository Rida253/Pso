using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace Petro_F
{
    public partial class Form4 : Form
    {
        Form2 f2 = new Form2();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "Add New User";
            //textBox3.PasswordChar = "*";
            this.textBox3.UseSystemPasswordChar=true;
            int c = 0;
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(ID) from Users", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            {
                textBox1.Text = "00" + c.ToString();
            }

            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Users", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Users(ID,UserName,User_Password)values(@ID,@UserName,@User_Password)", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@UserName", textBox2.Text);
            cmd.Parameters.AddWithValue("@User_Password", textBox3.Text);
            cmd.ExecuteNonQuery();
            f2.sqlConnection1.Close();


            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Users", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
