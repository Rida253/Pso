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
    public partial class Form8 : Form
    {
        int[] opnMtrReading = new int[50];
        int[] CloseMtrReading = new int[50];
        int Counter=0;
        Form2 f2 = new Form2();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.Text = "Add Dip Entry";

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Dip_Entry", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();

            int c = 0;
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(ID) from Dip_Entry", f2.sqlConnection1);
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
            SqlCommand cmd2 = new SqlCommand("select Shift_type from Shift_Type", f2.sqlConnection1);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["Shift_type"]);
            }
            f2.sqlConnection1.Close();

           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            f2.sqlConnection1.Open();
            SqlCommand cmd3 = new SqlCommand("select SalesMan_Name from Sales_man", f2.sqlConnection1);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3["SalesMan_Name"]);
            }
            f2.sqlConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Sales_man where SalesMan_Name=@SalesMan_Name", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@SalesMan_Name", this.comboBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["ID"].ToString();

            }
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd3 = new SqlCommand("select Tanker_Name from Tanker", f2.sqlConnection1);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox3.Items.Add(dr3["Tanker_Name"]);
            }
            f2.sqlConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd3 = new SqlCommand("select * from Products", f2.sqlConnection1);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox4.Items.Add(dr3["ID"]);
            }
            f2.sqlConnection1.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Products where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox4.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["P_Name"].ToString();

            }
            f2.sqlConnection1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Dip_Entry(ID,Entry_Date,Shift_Type,SalesMan_Name,Tank,Product_Name,Dip_mm,Dip_Litter,Open_Meter_Rearding,Close_Meter_Reading,Meter_sale)values(@ID,@Entry_Date,@Shift_Type,@SalesMan_Name,@Tank,@Product_Name,@Dip_mm,@Dip_Litter,@Open_Meter_Rearding,@Close_Meter_Reading,@Meter_sale)", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Entry_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Shift_Type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@SalesMan_Name", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Tank", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Product_Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Dip_mm", textBox4.Text);
            cmd.Parameters.AddWithValue("@Dip_Litter", textBox5.Text);
            cmd.Parameters.AddWithValue("@Open_Meter_Rearding", textBox7.Text);
            cmd.Parameters.AddWithValue("@Close_Meter_Reading", textBox6.Text);
            cmd.Parameters.AddWithValue("@Meter_sale", textBox8.Text);
            cmd.ExecuteNonQuery();
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Dip_Entry", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int opnMtrReading = 0;
            int CloseMtrReading = 0;
            opnMtrReading = Convert.ToInt32(textBox7.Text);
            CloseMtrReading = Convert.ToInt32(textBox6.Text);
            this.textBox8.Text = Convert.ToString(CloseMtrReading - opnMtrReading);
            Counter++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            
        }
    }
}
