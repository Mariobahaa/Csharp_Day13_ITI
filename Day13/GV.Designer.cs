
namespace Day13
{
    partial class GV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGV = new System.Windows.Forms.DataGridView();
            this.btnGVSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 29;
            this.DGV.Size = new System.Drawing.Size(699, 383);
            this.DGV.TabIndex = 0;
            // 
            // btnGVSave
            // 
            this.btnGVSave.Location = new System.Drawing.Point(282, 410);
            this.btnGVSave.Name = "btnGVSave";
            this.btnGVSave.Size = new System.Drawing.Size(132, 58);
            this.btnGVSave.TabIndex = 2;
            this.btnGVSave.Text = "Save";
            this.btnGVSave.UseVisualStyleBackColor = true;
            this.btnGVSave.Click += new System.EventHandler(this.btnGVSave_Click);
            // 
            // GV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Controls.Add(this.btnGVSave);
            this.Controls.Add(this.DGV);
            this.Name = "GV";
            this.Text = "GV";
            this.Load += new System.EventHandler(this.GV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button btnGVSave;
    }
}