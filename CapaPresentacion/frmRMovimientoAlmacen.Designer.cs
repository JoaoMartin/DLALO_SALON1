namespace CapaPresentacion
{
    partial class frmRMovimientoAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRMovimientoAlmacen));
            this.cvMovAlmacen = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvMovAlmacen
            // 
            this.cvMovAlmacen.ActiveViewIndex = -1;
            this.cvMovAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvMovAlmacen.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvMovAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvMovAlmacen.Location = new System.Drawing.Point(0, 0);
            this.cvMovAlmacen.Name = "cvMovAlmacen";
            this.cvMovAlmacen.Size = new System.Drawing.Size(825, 531);
            this.cvMovAlmacen.TabIndex = 3;
            // 
            // frmRMovimientoAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 531);
            this.Controls.Add(this.cvMovAlmacen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRMovimientoAlmacen";
            this.Text = ".:: REPORTE MOVIMIENTO ALMACEN ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRMovimientoAlmacen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvMovAlmacen;
    }
}