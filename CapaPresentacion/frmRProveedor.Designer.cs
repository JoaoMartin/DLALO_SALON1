namespace CapaPresentacion
{
    partial class frmRProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRProveedor));
            this.cvProveedor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvProveedor
            // 
            this.cvProveedor.ActiveViewIndex = -1;
            this.cvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvProveedor.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvProveedor.Location = new System.Drawing.Point(0, 0);
            this.cvProveedor.Name = "cvProveedor";
            this.cvProveedor.Size = new System.Drawing.Size(1074, 623);
            this.cvProveedor.TabIndex = 3;
            // 
            // frmRProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 623);
            this.Controls.Add(this.cvProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRProveedor";
            this.Text = ".:: REPORTE DE PROVEEDORES ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRProveedor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvProveedor;
    }
}