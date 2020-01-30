using SatelliteSelection;
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

namespace RocketLauncher.App
{
    public partial class RocketLauncher : Form
    {
        public RocketLauncher()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UFB73PS\\SQLEXPRESS;Initial Catalog=Rocket;Integrated Security=True");

        public void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from rocketdata", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into rocketdata values('" + txtId.Text + "','" + txtName.Text + "','" + txtVehicleType.Text + "','" + txtPurpose.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Inserted");
            Reset();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update rocketdata set Name='" + txtName.Text + "',VehicleType='" + txtVehicleType.Text + "',Purpose='" + txtPurpose.Text + "'where Id='" + txtId.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("updated");
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From rocketdata where Id='" + txtId.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("deleted");
            Reset();

        }

        private void RocketLauncher_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSatellite_Click(object sender, EventArgs e)
        {
            Satellite sat = new Satellite();
            sat.Show();
            //this.Close();
        }

        public void Reset()
        {
            txtId.Clear();
            txtName.Clear();
            txtVehicleType.Clear();
            txtPurpose.Clear();
        }
    }
}
