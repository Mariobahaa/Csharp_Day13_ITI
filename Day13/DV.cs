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
    public partial class DV : Form
    {
        string CString = System.Configuration.ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter DA;
        DataTable DT;
        BindingSource BSrc;
        BindingNavigator bindingNavigator;
       
        public DV()
        {
            InitializeComponent();
        }


        private void DV_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(CString);
            cmd = new SqlCommand("select T.*, P.pub_name " +
                      "from titles T inner join publishers P " +
                      "on T.pub_id = P.pub_id;", conn);
            DA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            DA.Fill(DT);


            BSrc = new BindingSource(DT, "");

            bindingNavigator = new BindingNavigator(true);
            this.Controls.Add(bindingNavigator);
            bindingNavigator.Dock = DockStyle.Bottom;
            bindingNavigator.BindingSource = BSrc;


            title_id.DataBindings.Add("Text",BSrc, "title_id");
            title.DataBindings.Add("Text", BSrc, "title");
            type.DataBindings.Add("Text", BSrc, "type");
            publisher.DataBindings.Add("Text", BSrc, "pub_id");
            price.DataBindings.Add("Text", BSrc, "price");
            advance.DataBindings.Add("Text", BSrc, "advance");
            royalty.DataBindings.Add("Text", BSrc, "royalty");
            sales.DataBindings.Add("Text", BSrc, "ytd_sales");
            notes.DataBindings.Add("Text", BSrc, "notes");
            pubDate.DataBindings.Add("Text", BSrc, "pubdate");

        }

        private void label6_Click(object sender, EventArgs e)
        {
            ;
        }
    }
}
