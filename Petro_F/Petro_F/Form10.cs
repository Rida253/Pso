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
    public partial class Form10 : Form
    {
        Form2 f2 = new Form2();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.Text = "Dip Chart";

            int c = 0;
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(ID) from Dip_Chart", f2.sqlConnection1);
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
            SqlCommand cmd3 = new SqlCommand("select P_Name from Products", f2.sqlConnection1);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3["P_Name"]);
            }
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Dip_Chart", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Dip_Chart(ID,Dip_mm,Dip_Litter)values(@ID,@Dip_mm,@Dip_Litter)", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
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
            textBox2.Clear();
            textBox3.Clear();
        }


    }
}
