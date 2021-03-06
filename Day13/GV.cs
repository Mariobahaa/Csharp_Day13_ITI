using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Day13
{
    public partial class GV : Form
    {
        string CString = System.Configuration.ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
        public GV()
        {
            InitializeComponent();
        }

        private void GV_Load(object sender, EventArgs e)
        {

        }
    }
}
