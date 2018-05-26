namespace CapaPresentacion
{
    partial class frmModuloSalon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuloSalon));
            this.gbSalon = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblIdSalon = new System.Windows.Forms.Label();
            this.lblNroMesas = new System.Windows.Forms.Label();
            this.lblIdMesa = new System.Windows.Forms.Label();
            this.lblPrimerID = new System.Windows.Forms.Label();
            this.lblNombreSalon = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbMesa = new System.Windows.Forms.GroupBox();
            this.lblPrueba = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.gbMesas = new System.Windows.Forms.GroupBox();
            this.lblBanderaEstado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tEstado = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.gbSalon.SuspendLayout();
            this.gbMesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSalon
            // 
            this.gbSalon.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbSalon.Controls.Add(this.button1);
            this.gbSalon.Controls.Add(this.lblIdSalon);
            this.gbSalon.Controls.Add(this.lblNroMesas);
            this.gbSalon.Controls.Add(this.lblIdMesa);
            this.gbSalon.Controls.Add(this.lblPrimerID);
            this.gbSalon.Controls.Add(this.lblNombreSalon);
            this.gbSalon.Controls.Add(this.label5);
            this.gbSalon.Controls.Add(this.gbMesa);
            this.gbSalon.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSalon.Location = new System.Drawing.Point(12, 26);
            this.gbSalon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSalon.Name = "gbSalon";
            this.gbSalon.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSalon.Size = new System.Drawing.Size(149, 532);
            this.gbSalon.TabIndex = 0;
            this.gbSalon.TabStop = false;
            this.gbSalon.Text = "SALONES";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CapaPresentacion.Properties.Resources.salir;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(6, 832);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 80);
            this.button1.TabIndex = 9;
            this.button1.Text = "SALIR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblIdSalon
            // 
            this.lblIdSalon.AutoSize = true;
            this.lblIdSalon.Location = new System.Drawing.Point(262, 77);
            this.lblIdSalon.Name = "lblIdSalon";
            this.lblIdSalon.Size = new System.Drawing.Size(18, 20);
            this.lblIdSalon.TabIndex = 6;
            this.lblIdSalon.Text = "0";
            // 
            // lblNroMesas
            // 
            this.lblNroMesas.AutoSize = true;
            this.lblNroMesas.Location = new System.Drawing.Point(310, 77);
            this.lblNroMesas.Name = "lblNroMesas";
            this.lblNroMesas.Size = new System.Drawing.Size(18, 20);
            this.lblNroMesas.TabIndex = 7;
            this.lblNroMesas.Text = "0";
            // 
            // lblIdMesa
            // 
            this.lblIdMesa.AutoSize = true;
            this.lblIdMesa.Location = new System.Drawing.Point(333, 77);
            this.lblIdMesa.Name = "lblIdMesa";
            this.lblIdMesa.Size = new System.Drawing.Size(18, 20);
            this.lblIdMesa.TabIndex = 8;
            this.lblIdMesa.Text = "0";
            // 
            // lblPrimerID
            // 
            this.lblPrimerID.AutoSize = true;
            this.lblPrimerID.Location = new System.Drawing.Point(122, 838);
            this.lblPrimerID.Name = "lblPrimerID";
            this.lblPrimerID.Size = new System.Drawing.Size(18, 20);
            this.lblPrimerID.TabIndex = 9;
            this.lblPrimerID.Text = "0";
            // 
            // lblNombreSalon
            // 
            this.lblNombreSalon.AutoSize = true;
            this.lblNombreSalon.Location = new System.Drawing.Point(43, 858);
            this.lblNombreSalon.Name = "lblNombreSalon";
            this.lblNombreSalon.Size = new System.Drawing.Size(18, 20);
            this.lblNombreSalon.TabIndex = 17;
            this.lblNombreSalon.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 858);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "label5";
            // 
            // gbMesa
            // 
            this.gbMesa.BackColor = System.Drawing.SystemColors.Control;
            this.gbMesa.Controls.Add(this.lblPrueba);
            this.gbMesa.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMesa.Location = new System.Drawing.Point(190, 0);
            this.gbMesa.Name = "gbMesa";
            this.gbMesa.Size = new System.Drawing.Size(1362, 817);
            this.gbMesa.TabIndex = 1;
            this.gbMesa.TabStop = false;
            this.gbMesa.Text = "MESAS";
            // 
            // lblPrueba
            // 
            this.lblPrueba.AutoSize = true;
            this.lblPrueba.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrueba.ForeColor = System.Drawing.Color.Navy;
            this.lblPrueba.Location = new System.Drawing.Point(592, -11);
            this.lblPrueba.Name = "lblPrueba";
            this.lblPrueba.Size = new System.Drawing.Size(111, 38);
            this.lblPrueba.TabIndex = 8;
            this.lblPrueba.Text = "MESAS";
            this.lblPrueba.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "LIBRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(486, 580);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "OCUPADA";
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdUsuario.Location = new System.Drawing.Point(158, 3);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(43, 19);
            this.lblIdUsuario.TabIndex = 9;
            this.lblIdUsuario.Text = "Mesa";
            this.lblIdUsuario.Visible = false;
            // 
            // gbMesas
            // 
            this.gbMesas.Location = new System.Drawing.Point(167, 25);
            this.gbMesas.Name = "gbMesas";
            this.gbMesas.Size = new System.Drawing.Size(781, 539);
            this.gbMesas.TabIndex = 17;
            this.gbMesas.TabStop = false;
            this.gbMesas.Text = "groupBox1";
            // 
            // lblBanderaEstado
            // 
            this.lblBanderaEstado.AutoSize = true;
            this.lblBanderaEstado.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanderaEstado.Location = new System.Drawing.Point(61, 3);
            this.lblBanderaEstado.Name = "lblBanderaEstado";
            this.lblBanderaEstado.Size = new System.Drawing.Size(17, 19);
            this.lblBanderaEstado.TabIndex = 18;
            this.lblBanderaEstado.Text = "0";
            this.lblBanderaEstado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblBanderaEstado.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Visible = false;
            // 
            // tEstado
            // 
            this.tEstado.Interval = 8500;
            this.tEstado.Tick += new System.EventHandler(this.tEstado_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.pictureBox1.Location = new System.Drawing.Point(349, 570);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 30);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(570, 570);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Orange;
            this.pictureBox4.Location = new System.Drawing.Point(774, 570);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 30);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(683, 578);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "POR SALIR";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(285, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 19);
            this.lblUsuario.TabIndex = 20;
            this.lblUsuario.Text = "Mesa";
            this.lblUsuario.Visible = false;
            // 
            // frmModuloSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 612);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBanderaEstado);
            this.Controls.Add(this.gbMesas);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbSalon);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModuloSalon";
            this.Text = ".:: SALONES ::.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModuloSalon_FormClosed);
            this.Load += new System.EventHandler(this.frmModuloSalon_Load);
            this.gbSalon.ResumeLayout(false);
            this.gbSalon.PerformLayout();
            this.gbMesa.ResumeLayout(false);
            this.gbMesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSalon;
        private System.Windows.Forms.GroupBox gbMesa;
        private System.Windows.Forms.Label lblIdSalon;
        private System.Windows.Forms.Label lblNroMesas;
        private System.Windows.Forms.Label lblIdMesa;
        private System.Windows.Forms.Label lblPrueba;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPrimerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreSalon;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.GroupBox gbMesas;
        public System.Windows.Forms.Label lblBanderaEstado;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Timer tEstado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblUsuario;
    }
}