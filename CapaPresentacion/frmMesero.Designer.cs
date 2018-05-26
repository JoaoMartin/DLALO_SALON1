namespace CapaPresentacion
{
    partial class frmMesero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesero));
            this.gbMeseros = new System.Windows.Forms.GroupBox();
            this.lblBandera = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBanderaEstado = new System.Windows.Forms.Label();
            this.gbMeseros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMeseros
            // 
            this.gbMeseros.Controls.Add(this.lblBandera);
            this.gbMeseros.Controls.Add(this.lblIdUsuario);
            this.gbMeseros.Controls.Add(this.label1);
            this.gbMeseros.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMeseros.Location = new System.Drawing.Point(12, 12);
            this.gbMeseros.Name = "gbMeseros";
            this.gbMeseros.Size = new System.Drawing.Size(1008, 585);
            this.gbMeseros.TabIndex = 0;
            this.gbMeseros.TabStop = false;
            this.gbMeseros.Text = "MESEROS Y REPARTIDORES";
            // 
            // lblBandera
            // 
            this.lblBandera.AutoSize = true;
            this.lblBandera.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBandera.Location = new System.Drawing.Point(385, 0);
            this.lblBandera.Name = "lblBandera";
            this.lblBandera.Size = new System.Drawing.Size(17, 19);
            this.lblBandera.TabIndex = 11;
            this.lblBandera.Text = "0";
            this.lblBandera.Visible = false;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdUsuario.Location = new System.Drawing.Point(234, -3);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(43, 19);
            this.lblIdUsuario.TabIndex = 9;
            this.lblIdUsuario.Text = "Mesa";
            this.lblIdUsuario.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(672, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // lblBanderaEstado
            // 
            this.lblBanderaEstado.AutoSize = true;
            this.lblBanderaEstado.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanderaEstado.Location = new System.Drawing.Point(354, 9);
            this.lblBanderaEstado.Name = "lblBanderaEstado";
            this.lblBanderaEstado.Size = new System.Drawing.Size(17, 19);
            this.lblBanderaEstado.TabIndex = 10;
            this.lblBanderaEstado.Text = "0";
            this.lblBanderaEstado.Visible = false;
            // 
            // frmMesero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 609);
            this.Controls.Add(this.lblBanderaEstado);
            this.Controls.Add(this.gbMeseros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMesero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: SELECCIONAR MESERO ::.";
            this.Load += new System.EventHandler(this.frmMesero_Load);
            this.gbMeseros.ResumeLayout(false);
            this.gbMeseros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMeseros;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblIdUsuario;
        public System.Windows.Forms.Label lblBanderaEstado;
        public System.Windows.Forms.Label lblBandera;
    }
}