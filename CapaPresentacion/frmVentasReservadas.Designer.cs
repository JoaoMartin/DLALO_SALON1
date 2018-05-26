namespace CapaPresentacion
{
    partial class frmVentasReservadas
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
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRecoger = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.lblAdelanto = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblTotalReserva = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(12, 183);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 24;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1355, 510);
            this.dataListado.TabIndex = 9;
            this.dataListado.Click += new System.EventHandler(this.dataListado_Click);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(653, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "PEDIDOS";
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(901, 67);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(17, 19);
            this.lblIdUsuario.TabIndex = 19;
            this.lblIdUsuario.Text = "0";
            this.lblIdUsuario.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(24, 67);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(646, 38);
            this.txtBuscar.TabIndex = 20;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotal.Location = new System.Drawing.Point(1102, 97);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 20);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = "label3";
            this.lblTotal.Visible = false;
            // 
            // btnRecoger
            // 
            this.btnRecoger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecoger.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoger.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRecoger.Image = global::CapaPresentacion.Properties.Resources.save2;
            this.btnRecoger.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecoger.Location = new System.Drawing.Point(1383, 287);
            this.btnRecoger.Name = "btnRecoger";
            this.btnRecoger.Size = new System.Drawing.Size(120, 78);
            this.btnRecoger.TabIndex = 23;
            this.btnRecoger.Text = "&Recoger";
            this.btnRecoger.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecoger.UseVisualStyleBackColor = false;
            this.btnRecoger.Click += new System.EventHandler(this.btnRecoger_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(991, 39);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(17, 19);
            this.lblEstado.TabIndex = 24;
            this.lblEstado.Text = "0";
            this.lblEstado.Visible = false;
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(1155, 39);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(17, 19);
            this.lblIdVenta.TabIndex = 25;
            this.lblIdVenta.Text = "0";
            this.lblIdVenta.Visible = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCobrar.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Image = global::CapaPresentacion.Properties.Resources.if_cashbox_45016;
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCobrar.Location = new System.Drawing.Point(1383, 371);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(120, 98);
            this.btnCobrar.TabIndex = 71;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // lblAdelanto
            // 
            this.lblAdelanto.AutoSize = true;
            this.lblAdelanto.Location = new System.Drawing.Point(1370, 55);
            this.lblAdelanto.Name = "lblAdelanto";
            this.lblAdelanto.Size = new System.Drawing.Size(17, 19);
            this.lblAdelanto.TabIndex = 72;
            this.lblAdelanto.Text = "0";
            this.lblAdelanto.Visible = false;
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnular.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Image = global::CapaPresentacion.Properties.Resources.if_Cut_728989;
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnular.Location = new System.Drawing.Point(1383, 183);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(120, 98);
            this.btnAnular.TabIndex = 73;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNombre);
            this.groupBox1.Controls.Add(this.rbCodigo);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(841, 111);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de Búsqueda";
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Checked = true;
            this.rbNombre.Location = new System.Drawing.Point(24, 37);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(77, 24);
            this.rbNombre.TabIndex = 8;
            this.rbNombre.TabStop = true;
            this.rbNombre.Text = "Cliente";
            this.rbNombre.UseVisualStyleBackColor = true;
            this.rbNombre.CheckedChanged += new System.EventHandler(this.rbNombre_CheckedChanged);
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Location = new System.Drawing.Point(167, 37);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(76, 24);
            this.rbCodigo.TabIndex = 9;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.CheckedChanged += new System.EventHandler(this.rbCodigo_CheckedChanged);
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(930, 141);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(17, 19);
            this.lblSaldo.TabIndex = 75;
            this.lblSaldo.Text = "0";
            this.lblSaldo.Visible = false;
            // 
            // lblTotalReserva
            // 
            this.lblTotalReserva.AutoSize = true;
            this.lblTotalReserva.Location = new System.Drawing.Point(1379, 92);
            this.lblTotalReserva.Name = "lblTotalReserva";
            this.lblTotalReserva.Size = new System.Drawing.Size(17, 19);
            this.lblTotalReserva.TabIndex = 76;
            this.lblTotalReserva.Text = "0";
            this.lblTotalReserva.Visible = false;
            // 
            // frmVentasReservadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1507, 695);
            this.Controls.Add(this.lblTotalReserva);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.lblAdelanto);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnRecoger);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataListado);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVentasReservadas";
            this.Text = ".:: PEDIDOS ::.";
            this.Load += new System.EventHandler(this.frmVentasReservadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRecoger;
        public System.Windows.Forms.Label lblEstado;
        public System.Windows.Forms.Label lblIdVenta;
        public System.Windows.Forms.Button btnCobrar;
        public System.Windows.Forms.Label lblAdelanto;
        public System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.RadioButton rbCodigo;
        public System.Windows.Forms.Label lblSaldo;
        public System.Windows.Forms.Label lblTotalReserva;
    }
}