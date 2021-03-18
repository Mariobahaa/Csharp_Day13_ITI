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
    public partial class DV : Form
    {
        string CString = System.Configuration.ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter DA;
        DataTable DT;
        BindingSource BSrc;
        BindingNavigator bindingNavigator;

        SqlCommand ncmd;
        SqlDataAdapter nDA;
        DataTable nDT;
        BindingSource nBSrc;

        public DV()
        {
            InitializeComponent();
        }


        private void DV_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(CString);
            cmd = new SqlCommand("select * from titles", conn);
            //cmd = new SqlCommand("select T.*, P.pub_name " +
            //          "from titles T inner join publishers P " +
            //          "on T.pub_id = P.pub_id;", conn);
            DA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            DA.Fill(DT);

            ncmd = new SqlCommand("select pub_id pid, pub_name from publishers", conn);
            nDA = new SqlDataAdapter(ncmd);
            nDT = new DataTable();
            nDA.Fill(nDT);

            BSrc = new BindingSource(DT, "");

            bindingNavigator = new BindingNavigator(true);
            this.Controls.Add(bindingNavigator);
            bindingNavigator.Dock = DockStyle.Bottom;
            bindingNavigator.BindingSource = BSrc;

            BindingSource b = new BindingSource();

            title_id.DataBindings.Add("Text",BSrc, "title_id",true);
            title.DataBindings.Add("Text", BSrc, "title",true);
            type.DataBindings.Add("Text", BSrc, "type",true);
            price.DataBindings.Add("Value", BSrc, "price",true);
            advance.DataBindings.Add("Value", BSrc, "advance",true);
            royalty.DataBindings.Add("Value", BSrc, "royalty",true);
            sales.DataBindings.Add("Value", BSrc, "ytd_sales",true);
            notes.DataBindings.Add("Text", BSrc, "notes",true);
            pubDate.DataBindings.Add("Value", BSrc, "pubdate",true);

            
            b.AddingNew += (sender,e) => b.AddNew();




            comboBox1.DataSource = nDT; //new Data Table
            comboBox1.DisplayMember = "pub_name"; //pub name from the Binding Source from new Data Table
            comboBox1.ValueMember = "pid";
            comboBox1.DataBindings.Add("SelectedValue", BSrc, "pub_id", true);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ;
        }

        SqlCommand updateCommand;
        SqlDataAdapter SaveDA;

        private void btnSave_Click(object sender, EventArgs e)
        {
            BSrc.EndEdit();
            //DT.AcceptChanges();
            foreach (DataRow dr in DT.Rows)
            {
                //Trace.WriteLine("ID: " + dr["pub_id"]);
                if (dr.RowState == DataRowState.Added)
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
                else if (dr.RowState == DataRowState.Modified)
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

                else if (dr.RowState == DataRowState.Deleted)
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

        private void advance_TextChanged(object sender, EventArgs e)
        {

        }

        private void royalty_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
    
}
