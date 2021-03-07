using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            //cmd = new SqlCommand("select T.*, P.pub_name " +
            //      "from titles T inner join publishers P " +
            //      "on T.pub_id = P.pub_id;",conn);
            cmd = new SqlCommand("select * from publishers", conn);
            DA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            DA.Fill(DT);
            DGV.DataSource = DT;

            DGV.Columns["title_id"].ReadOnly = true;
            DGV.Columns["pub_id"].DataPropertyName = "pub_name";
            DGV.Columns["pub_id"].ReadOnly = true;

            DGV.Columns["pub_name"].Visible = false;

            DA.InsertCommand = new SqlCommand("Insert into titles values " +
                        "(@a, @b, @c, @d, @e, @f, @g, @h, @i, @j)");

            DA.DeleteCommand = new SqlCommand("Delete from titles where title_id = @tid");

            //DA.UpdateCommand = new SqlCommand("Update titles set ")

            //DGV.Columns["pub_id"].Visible = false;
            ////DGV.Columns["pub_id"].CellType = Type.of DataGridViewComboBoxCell();
        }

        private void btnGVSave_Click(object sender, EventArgs e)
        {

            foreach (DataRow dr in DT.Rows)
            {
                if (dr.RowState == DataRowState.Added)
                {
                   
                    DT.AcceptChanges();
                    DA.Update(DT);
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    
                    DT.AcceptChanges();
                    DA.Update(DT);
                }
                else if (dr.RowState == DataRowState.Deleted)
                {
                    
                    DT.AcceptChanges();
                    DA.Update(DT);
                }

            }

           //
           
            
        }
    }
}
