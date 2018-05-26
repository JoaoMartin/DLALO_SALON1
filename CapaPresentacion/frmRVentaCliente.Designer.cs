namespace CapaPresentacion
{
    partial class frmRVentaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRVentaCliente));
            this.cvVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvVentas
            // 
            this.cvVentas.ActiveViewIndex = -1;
            this.cvVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvVentas.Location = new System.Drawing.Point(0, 0);
            this.cvVentas.Name = "cvVentas";
            this.cvVentas.Size = new System.Drawing.Size(470, 331);
            this.cvVentas.TabIndex = 6;
            // 
            // frmRVentaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 331);
            this.Controls.Add(this.cvVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRVentaCliente";
            this.Text = ".:: REPORTE DE VENTAS POR CLIENTE ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRVentaCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvVentas;
    }
}