namespace CapaPresentacion
{
    partial class frmRCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRCliente));
            this.cvCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvCliente
            // 
            this.cvCliente.ActiveViewIndex = -1;
            this.cvCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvCliente.Location = new System.Drawing.Point(0, 0);
            this.cvCliente.Name = "cvCliente";
            this.cvCliente.Size = new System.Drawing.Size(1346, 673);
            this.cvCliente.TabIndex = 0;
            this.cvCliente.Load += new System.EventHandler(this.cvCliente_Load);
            // 
            // frmRCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 673);
            this.Controls.Add(this.cvCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRCliente";
            this.Text = ".:: REPORTE DE CLIENTES ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvCliente;
    }
}