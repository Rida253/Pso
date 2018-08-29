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
    public partial class Form5 : Form
    {
        Form2 f2 = new Form2();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Text = "Update / Delete User Info";
            this.textBox2.UseSystemPasswordChar = true;

            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select ID from Users", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ID"]);
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
            SqlCommand cmd = new SqlCommand("update Users set ID=@ID,UserName=@UserName,User_Password=@User_Password where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
            cmd.Parameters.AddWithValue("@User_Password", textBox2.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Delete from Users where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox1.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["UserName"].ToString();
                textBox2.Text = dr["User_Password"].ToString();

            }
            f2.sqlConnection1.Close();
        }
    }
}
