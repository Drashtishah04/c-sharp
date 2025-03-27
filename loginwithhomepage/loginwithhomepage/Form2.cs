using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginwithhomepage
{
    public partial class Form2 : Form
    {
        int tr = 0, rp = 0, id = 0;
        public static SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\login.mdf;Integrated Security=True");

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (btninsert.Text != "&Save")
            {
                if (txtsnm.Text != "" && txtmob.Text != "")
                {
                    String sql = "insert into stud_details values('" + txtsnm.Text + "','" + txtmob.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    txtsnm.Text = txtmob.Text = string.Empty;
                    txtsnm.Focus();
                    loaddata();
                }
                else
                {
                    MessageBox.Show("Please enter values", "login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtsnm.Text = txtmob.Text = string.Empty;
                txtsnm.Focus();
                btninsert.Text = "&Save";
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
            }
        }
        private void loaddata()
        {
            String sql = "select * from stud_details";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            tr = dt.Rows.Count - 1;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtsnm.Text != "" && txtmob.Text != "")
            {
                String sql = "update stud_details set student_name='" + txtsnm.Text + "',mobile_no='" + txtmob.Text + "'where id='" + id + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                loaddata();
                txtsnm.Text = txtmob.Text = string.Empty;
                txtsnm.Focus();
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            String sql = "DELETE stud_details  where id='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            loaddata();
            txtsnm.Text = txtmob.Text = string.Empty;
            txtsnm.Focus();
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (rp < tr)
            {
                rp++;
                Navigate();
                btnupdate.Enabled = true;
                btndelete.Enabled = true;
                btninsert.Text = "&Insert";
            }
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            if (rp > 0)
            {
                rp--;
                Navigate();
                btnupdate.Enabled = true;
                btndelete.Enabled = true;
                btninsert.Text = "&Insert";
            }
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            rp = tr;
            Navigate();
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            btninsert.Text = "&Insert";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rp = 0;
            Navigate();
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            btninsert.Text = "&Insert";
        }
        private void Navigate()
        {
            if (tr >= 0)
            {
                String sql = "select * from stud_details";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtsnm.Text = dt.Rows[rp][1].ToString();
                txtmob.Text = dt.Rows[rp][2].ToString();
                id = Convert.ToInt32(dt.Rows[rp]["id"]);
            }
        }
    }
}
