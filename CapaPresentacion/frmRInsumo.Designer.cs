namespace CapaPresentacion
{
    partial class frmRInsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRInsumo));
            this.cvInsumo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvInsumo
            // 
            this.cvInsumo.ActiveViewIndex = -1;
            this.cvInsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvInsumo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvInsumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvInsumo.Location = new System.Drawing.Point(0, 0);
            this.cvInsumo.Name = "cvInsumo";
            this.cvInsumo.Size = new System.Drawing.Size(1336, 662);
            this.cvInsumo.TabIndex = 1;
            // 
            // frmRInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 662);
            this.Controls.Add(this.cvInsumo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRInsumo";
            this.Text = ".:: REPORTE DE INSUMOS ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRInsumo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvInsumo;
    }
}