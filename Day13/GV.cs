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

        SqlCommand tcmd;
        SqlDataAdapter tDA;
        DataTable tDT;
        public GV()
        {
            InitializeComponent();
        }

        private void GV_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(CString);
            cmd = new SqlCommand("select * from titles", conn);
            DA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            DA.Fill(DT);
            DGV.DataSource = DT;


            tcmd = new SqlCommand("select pub_id pid, pub_name from publishers ", conn);
            tDA = new SqlDataAdapter(tcmd);
            tDT = new DataTable();
            tDA.Fill(tDT);

            DataGridViewComboBoxColumn CBC = new DataGridViewComboBoxColumn();
            CBC.DataSource = tDT;
            CBC.HeaderText = "Publisher";
            CBC.DataPropertyName = "pub_id";
            CBC.ValueMember = "pid";
            CBC.DisplayMember = "pub_name";

            DGV.Columns.Add(CBC);

            DGV.Columns["pub_id"].Visible = false;
        }


        
        SqlCommand updateCommand;
        SqlDataAdapter SaveDA;
        
        private void btnGVSave_Click(object sender, EventArgs e)
        {

            foreach (DataRow dr in DT.Rows)
            {
                //Trace.WriteLine("ID: " + dr["pub_id"]);
                if(dr.RowState == DataRowState.Added)
                {
                    updateCommand = new SqlCommand("insert into titles values(@a, @b, @c, @d, @e, @f, @g, @h, @i, @j)", conn);
                    //insertCommand.CommandType = CommandType.StoredProcedure;
                    updateCommand.Parameters.Add("@a", SqlDbType.VarChar);
                    updateCommand.Parameters["@a"].Value = dr["title_id"];
                    updateCommand.Parameters.Add("@b", SqlDbType.VarChar);
                    updateCommand.Parameters["@b"].Value = dr["title"];
                    updateCommand.Parameters.Add("@c", SqlDbType.Char);
                    updateCommand.Parameters["@c"].Value = dr["type"];
                    updateCommand.Parameters.Add("@d", SqlDbType.Char);
                    updateCommand.Parameters["@d"].Value = dr["pub_id"];
                    updateCommand.Parameters.Add("@e", SqlDbType.Money);
                    updateCommand.Parameters["@e"].Value = dr["price"];
                    updateCommand.Parameters.Add("@f", SqlDbType.Money);
                    updateCommand.Parameters["@f"].Value = dr["advance"];
                    updateCommand.Parameters.Add("@g", SqlDbType.Int);
                    updateCommand.Parameters["@g"].Value = dr["royalty"];
                    updateCommand.Parameters.Add("@h", SqlDbType.Int);
                    updateCommand.Parameters["@h"].Value = dr["ytd_sales"];
                    updateCommand.Parameters.Add("@i", SqlDbType.VarChar);
                    updateCommand.Parameters["@i"].Value = dr["notes"];
                    updateCommand.Parameters.Add("@j", SqlDbType.DateTime);
                    updateCommand.Parameters["@j"].Value = dr["pubdate"];

                    SaveDA = new SqlDataAdapter(updateCommand);
                    SaveDA.InsertCommand = updateCommand;
                    SaveDA.Update(DT);


                }
                else if(dr.RowState == DataRowState.Modified)
                {
                    updateCommand =
                    new SqlCommand("update titles " +
                    " set[title] = @b, [type] = @c, [pub_id] = @d,[price] = @e, " +
                    " [advance] = @f, [royalty] = @g, [ytd_sales] = @h, " +
                    " [notes] = @i, [pubdate] = @j " +
                    " where[title_id] = @a", conn);
                    //insertCommand.CommandType = CommandType.StoredProcedure;
                    updateCommand.Parameters.Add("@a", SqlDbType.VarChar);
                    updateCommand.Parameters["@a"].Value = dr["title_id"];
                    updateCommand.Parameters.Add("@b", SqlDbType.VarChar);
                    updateCommand.Parameters["@b"].Value = dr["title"];
                    updateCommand.Parameters.Add("@c", SqlDbType.Char);
                    updateCommand.Parameters["@c"].Value = dr["type"];
                    updateCommand.Parameters.Add("@d", SqlDbType.Char);
                    updateCommand.Parameters["@d"].Value = dr["pub_id"];
                    updateCommand.Parameters.Add("@e", SqlDbType.Money);
                    updateCommand.Parameters["@e"].Value = dr["price"];
                    updateCommand.Parameters.Add("@f", SqlDbType.Money);
                    updateCommand.Parameters["@f"].Value = dr["advance"];
                    updateCommand.Parameters.Add("@g", SqlDbType.Int);
                    updateCommand.Parameters["@g"].Value = dr["royalty"];
                    updateCommand.Parameters.Add("@h", SqlDbType.Int);
                    updateCommand.Parameters["@h"].Value = dr["ytd_sales"];
                    updateCommand.Parameters.Add("@i", SqlDbType.VarChar);
                    updateCommand.Parameters["@i"].Value = dr["notes"];
                    updateCommand.Parameters.Add("@j", SqlDbType.DateTime);
                    updateCommand.Parameters["@j"].Value = dr["pubdate"];

                    SaveDA = new SqlDataAdapter(updateCommand);
                    SaveDA.UpdateCommand = updateCommand;
                    SaveDA.Update(DT);
                }

                else if(dr.RowState == DataRowState.Deleted)
                {
                    Trace.WriteLine(dr["title_id", DataRowVersion.Original]);
                    updateCommand =
                       new SqlCommand(
                                      "delete from titles where title_id = @a", conn);
                    updateCommand.Parameters.Add("@a", SqlDbType.VarChar);
                    updateCommand.Parameters["@a"].Value = dr["title_id", DataRowVersion.Original];
                    //BSrc.Remove(BSrc.Current);


                    SaveDA = new SqlDataAdapter(updateCommand);
                    SaveDA.DeleteCommand = updateCommand;
                    SaveDA.Update(DT);
                }
            }

            
        }
    }
}
