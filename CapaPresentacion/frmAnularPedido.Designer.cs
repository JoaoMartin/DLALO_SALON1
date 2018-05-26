namespace CapaPresentacion
{
    partial class frmAnularPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnularPedido));
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNro = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblIdCompro = new System.Windows.Forms.Label();
            this.lblBandera = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSI = new System.Windows.Forms.RadioButton();
            this.rbNO = new System.Windows.Forms.RadioButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Location = new System.Drawing.Point(134, 261);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(16, 17);
            this.lblComprobante.TabIndex = 21;
            this.lblComprobante.Text = "0";
            this.lblComprobante.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(35, 85);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(16, 17);
            this.lblFecha.TabIndex = 20;
            this.lblFecha.Text = "0";
            this.lblFecha.Visible = false;
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(73, 194);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(16, 17);
            this.lblNro.TabIndex = 19;
            this.lblNro.Text = "0";
            this.lblNro.Visible = false;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(24, 209);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(16, 17);
            this.lblSerie.TabIndex = 18;
            this.lblSerie.Text = "0";
            this.lblSerie.Visible = false;
            // 
            // lblIdCompro
            // 
            this.lblIdCompro.AutoSize = true;
            this.lblIdCompro.Location = new System.Drawing.Point(24, 135);
            this.lblIdCompro.Name = "lblIdCompro";
            this.lblIdCompro.Size = new System.Drawing.Size(16, 17);
            this.lblIdCompro.TabIndex = 17;
            this.lblIdCompro.Text = "0";
            this.lblIdCompro.Visible = false;
            // 
            // lblBandera
            // 
            this.lblBandera.AutoSize = true;
            this.lblBandera.Location = new System.Drawing.Point(14, 177);
            this.lblBandera.Name = "lblBandera";
            this.lblBandera.Size = new System.Drawing.Size(16, 17);
            this.lblBandera.TabIndex = 16;
            this.lblBandera.Text = "0";
            this.lblBandera.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(293, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 52);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(116, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 52);
            this.button1.TabIndex = 14;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Devolución de Dinero";
            // 
            // rbSI
            // 
            this.rbSI.AutoSize = true;
            this.rbSI.Checked = true;
            this.rbSI.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSI.Location = new System.Drawing.Point(100, 63);
            this.rbSI.Name = "rbSI";
            this.rbSI.Size = new System.Drawing.Size(44, 24);
            this.rbSI.TabIndex = 22;
            this.rbSI.TabStop = true;
            this.rbSI.Text = "SI";
            this.rbSI.UseVisualStyleBackColor = true;
            // 
            // rbNO
            // 
            this.rbNO.AutoSize = true;
            this.rbNO.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNO.Location = new System.Drawing.Point(185, 63);
            this.rbNO.Name = "rbNO";
            this.rbNO.Size = new System.Drawing.Size(51, 24);
            this.rbNO.TabIndex = 23;
            this.rbNO.Text = "NO";
            this.rbNO.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(100, 104);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(351, 90);
            this.txtDescripcion.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Motivo";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(379, 43);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(16, 17);
            this.lblEfectivo.TabIndex = 26;
            this.lblEfectivo.Text = "0";
            this.lblEfectivo.Visible = false;
            // 
            // frmAnularPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 280);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbNO);
            this.Controls.Add(this.rbSI);
            this.Controls.Add(this.lblComprobante);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.lblIdCompro);
            this.Controls.Add(this.lblBandera);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnularPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: ANULAR PEDIDO ::.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblComprobante;
        public System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.Label lblNro;
        public System.Windows.Forms.Label lblSerie;
        public System.Windows.Forms.Label lblIdCompro;
        public System.Windows.Forms.Label lblBandera;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSI;
        private System.Windows.Forms.RadioButton rbNO;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblEfectivo;
    }
}