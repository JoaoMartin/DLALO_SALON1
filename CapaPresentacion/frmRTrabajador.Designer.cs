namespace CapaPresentacion
{
    partial class frmRTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRTrabajador));
            this.cvTrabajador = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvTrabajador
            // 
            this.cvTrabajador.ActiveViewIndex = -1;
            this.cvTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvTrabajador.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvTrabajador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvTrabajador.Location = new System.Drawing.Point(0, 0);
            this.cvTrabajador.Name = "cvTrabajador";
            this.cvTrabajador.Size = new System.Drawing.Size(966, 452);
            this.cvTrabajador.TabIndex = 3;
            // 
            // frmRTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 452);
            this.Controls.Add(this.cvTrabajador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRTrabajador";
            this.Text = ".:: REPORTE DE TRABAJADORES ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRTrabajador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvTrabajador;
    }
}