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
    public partial class Form6 : Form
    {
        Form2 f2 = new Form2();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Text = "Add New Party";

            int c = 0;
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(ID) from Party", f2.sqlConnection1);
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
            SqlCommand cmd1 = new SqlCommand("select * from Party", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd2 = new SqlCommand("select Party_Name from Party_Type", f2.sqlConnection1);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["Party_Name"]);
            }
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Party(ID,Party_Type,City,Name,Father_Name,Email,CNIC,Phone_No,Mobile_No,GST#,NTN#,Cont_Person_Name,Cont_Person_PH,Location)values(@ID,@Party_Type,@City,@Name,@Father_Name,@Email,@CNIC,@Phone_No,@Mobile_No,@GST#,@NTN#,@Cont_Person_Name,@Cont_Person_PH,@Location)", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Party_Type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@City", textBox13.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Father_Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@CNIC", textBox4.Text);
            cmd.Parameters.AddWithValue("@Phone_No", textBox7.Text);
            cmd.Parameters.AddWithValue("@Mobile_No", textBox6.Text);
            cmd.Parameters.AddWithValue("@GST#", textBox9.Text);
            cmd.Parameters.AddWithValue("@NTN#", textBox8.Text);
            cmd.Parameters.AddWithValue("@Cont_Person_Name", textBox11.Text);
            cmd.Parameters.AddWithValue("@Cont_Person_PH", textBox10.Text);
            cmd.Parameters.AddWithValue("@Location", textBox12.Text);
            cmd.ExecuteNonQuery();
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Party", f2.sqlConnection1);
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
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }
    }
}
