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
    public partial class Form1: Form
    {
        public static SqlConnection cn=new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\login.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtunm.Text != "" && txtpwd.Text != "")
            {
                string sql = "select * from login_details where username='" + txtunm.Text + "' and password ='" + txtpwd.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
            }
        }
    }
}
