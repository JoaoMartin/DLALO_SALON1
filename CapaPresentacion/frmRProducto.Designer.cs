namespace CapaPresentacion
{
    partial class frmRProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRProducto));
            this.cvProducto = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvProducto
            // 
            this.cvProducto.ActiveViewIndex = -1;
            this.cvProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvProducto.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvProducto.Location = new System.Drawing.Point(0, 0);
            this.cvProducto.Name = "cvProducto";
            this.cvProducto.Size = new System.Drawing.Size(1230, 668);
            this.cvProducto.TabIndex = 2;
            this.cvProducto.Load += new System.EventHandler(this.cvProducto_Load);
            // 
            // frmRProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 668);
            this.Controls.Add(this.cvProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRProducto";
            this.Text = ".:: REPORTE PRODUCTOS ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRProducto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvProducto;
    }
}