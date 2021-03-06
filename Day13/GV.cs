using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Day13
{
    public partial class GV : Form
    {
        string CString = System.Configuration.ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter DA;
        DataTable DT;
        public GV()
        {
            InitializeComponent();
        }

        private void GV_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(CString);
            cmd = new SqlCommand("select T.*, P.pub_name " +
                  "from titles T inner join publishers P " +
                  "on T.pub_id = P.pub_id;",conn);
            DA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            DA.Fill(DT);
            DGV.DataSource = DT;
            //DataGridViewCo
            //DGV.Columns["pub_id"].Visible = false;
            DGV.Columns["title_id"].ReadOnly = true;
            DGV.Columns["pub_id"].DataPropertyName = "pub_name";
            //DGV.Columns["pub_id"].CellType = Type.of DataGridViewComboBoxCell();
            DGV.Columns["pub_name"].Visible = false;

        }
    }
}
