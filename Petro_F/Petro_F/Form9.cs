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
    public partial class Form9 : Form
    {
        int[] opnMtrReading = new int[50];
        int[] CloseMtrReading = new int[50];
        int Counter = 0;
        Form2 f2 = new Form2();
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.Text = "Update / Delete Dip Info";

            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Dip_Entry", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd2 = new SqlCommand("select ID from Dip_Entry", f2.sqlConnection1);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox5.Items.Add(dr2["ID"]);
            }
            f2.sqlConnection1.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Dip_Entry where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox5.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dateTimePicker1.Text = dr["Entry_Date"].ToString();
                comboBox1.Text = dr["Shift_Type"].ToString();
                comboBox2.Text = dr["SalesMan_Name"].ToString();
                comboBox3.Text = dr["Tank"].ToString();
                textBox3.Text = dr["Product_Name"].ToString();
                textBox4.Text = dr["Dip_mm"].ToString();
                textBox5.Text = dr["Dip_Litter"].ToString();
                textBox7.Text = dr["Open_Meter_Rearding"].ToString();
                textBox6.Text = dr["Close_Meter_Reading"].ToString();
                textBox8.Text = dr["Meter_sale"].ToString();
                

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update Dip_Entry set ID=@ID,Entry_Date=@Entry_Date,Shift_Type=@Shift_Type,SalesMan_Name=@SalesMan_Name,Tank=@Tank,Product_Name=@Product_Name,Dip_mm=@Dip_mm,Dip_Litter=@Dip_Litter,Open_Meter_Rearding=@Open_Meter_Rearding,Close_Meter_Reading=@Close_Meter_Reading,Meter_sale=@Meter_sale  where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", comboBox5.Text);
            cmd.Parameters.AddWithValue("@Entry_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Shift_Type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@SalesMan_Name", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Tank", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Product_Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Dip_mm", textBox4.Text);
            cmd.Parameters.AddWithValue("@Dip_Litter", textBox5.Text);
            cmd.Parameters.AddWithValue("@Open_Meter_Rearding", textBox7.Text);
            cmd.Parameters.AddWithValue("@Close_Meter_Reading", textBox6.Text);
            cmd.Parameters.AddWithValue("@Meter_Sale", textBox8.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {

            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Delete from Dip_Entry where ID=@ID", f2.sqlConnection1);
            cmd.Parameters.AddWithValue("@ID", this.comboBox5.Text);
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
    }
}
