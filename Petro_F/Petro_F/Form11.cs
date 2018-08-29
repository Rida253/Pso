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
    public partial class Form11 : Form
    {
        Form2 f2 = new Form2();
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.Text = "Update/Delete Dip Chart Info";

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Dip_Chart", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();

            

            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select ID from Dip_Chart", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ID"]);
            }
            f2.sqlConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd3 = new SqlCommand("select P_Name from Products", f2.sqlConnection1);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3["P_Name"]);
            }
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Dip_Chart where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["Dip_mm"].ToString();
                textBox3.Text = dr["Dip_Litter"].ToString();

            }
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update Dip_Chart set ID=@ID,Dip_mm=@Dip_mm,Dip_Litter=@Dip_Litter where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Dip_mm", textBox2.Text);
            cmd.Parameters.AddWithValue("@Dip_Litter", textBox3.Text);
            cmd.ExecuteNonQuery();
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Dip_Chart", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Delete from Dip_Chart where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Dip_Chart", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();
        }
    }
}
