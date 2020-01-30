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

namespace SatelliteSelection
{
    public partial class Satellite : Form
    {
        public Satellite()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UFB73PS\\SQLEXPRESS;Initial Catalog=Rocket;Integrated Security=True");

        public void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Satellitedata",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        public void Satellite_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into satellitedata values('" + txtId.Text + "','" + txtPlace.Text + "','" + txtCode.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Inserted");
            Reset();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update satellitedata set Place='" + txtPlace.Text + "',StationCode='" + txtCode.Text + "' where Id='" + txtId.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("updated");
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From satellitedata where Id='" + txtId.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("deleted");
            Reset();
        }
        public void Reset()
        {
            txtId.Clear();
            txtCode.Clear();
            txtPlace.Clear();
        }

        private void Satellite_Load_1(object sender, EventArgs e)
        {
            Display();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
