namespace CapaPresentacion
{
    partial class frmAnularComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnularComprobante));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblBandera = new System.Windows.Forms.Label();
            this.lblIdCompro = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblNro = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.cbOrigen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motivo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(86, 87);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(351, 90);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(107, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(270, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 52);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblBandera
            // 
            this.lblBandera.AutoSize = true;
            this.lblBandera.Location = new System.Drawing.Point(23, 199);
            this.lblBandera.Name = "lblBandera";
            this.lblBandera.Size = new System.Drawing.Size(17, 20);
            this.lblBandera.TabIndex = 4;
            this.lblBandera.Text = "0";
            this.lblBandera.Visible = false;
            this.lblBandera.Click += new System.EventHandler(this.lblBandera_Click);
            // 
            // lblIdCompro
            // 
            this.lblIdCompro.AutoSize = true;
            this.lblIdCompro.Location = new System.Drawing.Point(33, 157);
            this.lblIdCompro.Name = "lblIdCompro";
            this.lblIdCompro.Size = new System.Drawing.Size(17, 20);
            this.lblIdCompro.TabIndex = 5;
            this.lblIdCompro.Text = "0";
            this.lblIdCompro.Visible = false;
            this.lblIdCompro.Click += new System.EventHandler(this.lblIdCompro_Click);
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(33, 231);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(17, 20);
            this.lblSerie.TabIndex = 6;
            this.lblSerie.Text = "0";
            this.lblSerie.Visible = false;
            this.lblSerie.Click += new System.EventHandler(this.lblSerie_Click);
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(82, 216);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(17, 20);
            this.lblNro.TabIndex = 7;
            this.lblNro.Text = "0";
            this.lblNro.Visible = false;
            this.lblNro.Click += new System.EventHandler(this.lblNro_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(44, 107);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(17, 20);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "0";
            this.lblFecha.Visible = false;
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Location = new System.Drawing.Point(219, 216);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(17, 20);
            this.lblComprobante.TabIndex = 9;
            this.lblComprobante.Text = "0";
            this.lblComprobante.Visible = false;
            this.lblComprobante.Click += new System.EventHandler(this.lblComprobante_Click);
            // 
            // cbOrigen
            // 
            this.cbOrigen.AutoSize = true;
            this.cbOrigen.Checked = true;
            this.cbOrigen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOrigen.Location = new System.Drawing.Point(86, 34);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(110, 24);
            this.cbOrigen.TabIndex = 11;
            this.cbOrigen.Text = "Origen Caja";
            this.cbOrigen.UseVisualStyleBackColor = true;
            this.cbOrigen.CheckedChanged += new System.EventHandler(this.cbOrigen_CheckedChanged);
            // 
            // frmAnularComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(449, 272);
            this.Controls.Add(this.cbOrigen);
            this.Controls.Add(this.lblComprobante);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.lblIdCompro);
            this.Controls.Add(this.lblBandera);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnularComprobante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: ANULAR COMPROBANTE ::.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label lblBandera;
        public System.Windows.Forms.Label lblIdCompro;
        public System.Windows.Forms.Label lblSerie;
        public System.Windows.Forms.Label lblNro;
        public System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.CheckBox cbOrigen;
    }
}