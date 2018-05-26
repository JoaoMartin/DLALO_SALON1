namespace CapaPresentacion
{
    partial class frmRMostrarCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRMostrarCompras));
            this.cvCompras = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvCompras
            // 
            this.cvCompras.ActiveViewIndex = -1;
            this.cvCompras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvCompras.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvCompras.Location = new System.Drawing.Point(0, 0);
            this.cvCompras.Name = "cvCompras";
            this.cvCompras.Size = new System.Drawing.Size(426, 325);
            this.cvCompras.TabIndex = 4;
            // 
            // frmRMostrarCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 325);
            this.Controls.Add(this.cvCompras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRMostrarCompras";
            this.Text = ".:: MOSTRAR COMPRAS ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRMostrarCompras_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvCompras;
    }
}