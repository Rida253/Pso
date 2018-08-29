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
    public partial class Form7 : Form
    {
        Form2 f2 = new Form2();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Text = "Update/Delete Party Info";

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Party", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();

            

            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select ID from Party", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["ID"]);
            }
            f2.sqlConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd2 = new SqlCommand("select Party_Name from Party_Type", f2.sqlConnection1);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["Party_Name"]);
            }
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Party where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comboBox1.Text = dr["Party_Type"].ToString();
                textBox13.Text = dr["City"].ToString();
                textBox2.Text = dr["Name"].ToString();
                textBox3.Text = dr["Father_Name"].ToString();
                textBox5.Text = dr["Email"].ToString();
                textBox4.Text = dr["CNIC"].ToString();
                textBox7.Text = dr["Phone_No"].ToString();
                textBox6.Text = dr["Mobile_No"].ToString();
                textBox9.Text = dr["GST#"].ToString();
                textBox8.Text = dr["NTN#"].ToString();
                textBox11.Text = dr["Cont_Person_Name"].ToString();
                textBox12.Text = dr["Cont_Person_PH"].ToString();
                textBox13.Text = dr["Location"].ToString();


            }
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update Party set ID=@ID,Party_Type=@Party_Type,City=@City,Name=@Name,Father_Name=@Father_Name,Email=@Email,CNIC=@CNIC,Phone_No=@Phone_No,Mobile_No=@Mobile_No,GST#=@GST#,NTN#=@NTN#,Cont_Person_Name=@Cont_Person_Name,Cont_Person_PH=@Cont_Person_PH,Location=@Location  where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", comboBox2.Text);
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
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Delete from Party where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox2.Text);
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
    }
}
