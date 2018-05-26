namespace CapaPresentacion
{
    partial class frmCobroDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobroDelivery));
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblRepartidos = new System.Windows.Forms.Label();
            this.dataDetalle = new System.Windows.Forms.DataGridView();
            this.lblDctoInd = new System.Windows.Forms.Label();
            this.dataCocina = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTelefono = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCocina)).BeginInit();
            this.SuspendLayout();
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(12, 92);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 24;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1361, 554);
            this.dataListado.TabIndex = 8;
            this.dataListado.Click += new System.EventHandler(this.dataListado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(524, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "DELIVERY POR COBRAR";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConfirmar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.edit4;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(1379, 466);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(129, 76);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Confirmar Pago";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEnviar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEnviar.Image = global::CapaPresentacion.Properties.Resources.new41;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEnviar.Location = new System.Drawing.Point(1379, 366);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(129, 70);
            this.btnEnviar.TabIndex = 14;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnular.Enabled = false;
            this.btnAnular.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAnular.Image = global::CapaPresentacion.Properties.Resources.trash;
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnular.Location = new System.Drawing.Point(1379, 563);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(129, 74);
            this.btnAnular.TabIndex = 12;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(949, 43);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(17, 19);
            this.lblIdVenta.TabIndex = 16;
            this.lblIdVenta.Text = "0";
            this.lblIdVenta.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(1100, 43);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(17, 19);
            this.lblEstado.TabIndex = 17;
            this.lblEstado.Text = "0";
            this.lblEstado.Visible = false;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(824, 43);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(17, 19);
            this.lblIdUsuario.TabIndex = 18;
            this.lblIdUsuario.Text = "0";
            this.lblIdUsuario.Visible = false;
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Location = new System.Drawing.Point(1356, 42);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(17, 19);
            this.lblVuelto.TabIndex = 19;
            this.lblVuelto.Text = "0";
            this.lblVuelto.Visible = false;
            this.lblVuelto.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Location = new System.Drawing.Point(38, 42);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(17, 19);
            this.lblTipoComprobante.TabIndex = 20;
            this.lblTipoComprobante.Text = "0";
            this.lblTipoComprobante.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(142, 43);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(17, 19);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = "0";
            this.lblTotal.Visible = false;
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Location = new System.Drawing.Point(38, 9);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(17, 19);
            this.lblIdCliente.TabIndex = 22;
            this.lblIdCliente.Text = "0";
            this.lblIdCliente.Visible = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(394, 55);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(17, 19);
            this.lblCliente.TabIndex = 23;
            this.lblCliente.Text = "0";
            this.lblCliente.Visible = false;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(383, 9);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(17, 19);
            this.lblDireccion.TabIndex = 24;
            this.lblDireccion.Text = "0";
            this.lblDireccion.Visible = false;
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(266, 9);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(17, 19);
            this.lblNroDoc.TabIndex = 25;
            this.lblNroDoc.Text = "0";
            this.lblNroDoc.Visible = false;
            // 
            // lblRepartidos
            // 
            this.lblRepartidos.AutoSize = true;
            this.lblRepartidos.Location = new System.Drawing.Point(433, 36);
            this.lblRepartidos.Name = "lblRepartidos";
            this.lblRepartidos.Size = new System.Drawing.Size(17, 19);
            this.lblRepartidos.TabIndex = 26;
            this.lblRepartidos.Text = "0";
            this.lblRepartidos.Visible = false;
            // 
            // dataDetalle
            // 
            this.dataDetalle.AllowUserToAddRows = false;
            this.dataDetalle.AllowUserToDeleteRows = false;
            this.dataDetalle.AllowUserToOrderColumns = true;
            this.dataDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetalle.Location = new System.Drawing.Point(28, 433);
            this.dataDetalle.MultiSelect = false;
            this.dataDetalle.Name = "dataDetalle";
            this.dataDetalle.ReadOnly = true;
            this.dataDetalle.RowTemplate.Height = 24;
            this.dataDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataDetalle.Size = new System.Drawing.Size(1260, 109);
            this.dataDetalle.TabIndex = 27;
            this.dataDetalle.Visible = false;
            // 
            // lblDctoInd
            // 
            this.lblDctoInd.AutoSize = true;
            this.lblDctoInd.Location = new System.Drawing.Point(242, 70);
            this.lblDctoInd.Name = "lblDctoInd";
            this.lblDctoInd.Size = new System.Drawing.Size(17, 19);
            this.lblDctoInd.TabIndex = 28;
            this.lblDctoInd.Text = "0";
            this.lblDctoInd.Visible = false;
            // 
            // dataCocina
            // 
            this.dataCocina.AllowUserToAddRows = false;
            this.dataCocina.AllowUserToDeleteRows = false;
            this.dataCocina.AllowUserToOrderColumns = true;
            this.dataCocina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCocina.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Cantidad,
            this.Nota});
            this.dataCocina.Location = new System.Drawing.Point(129, 270);
            this.dataCocina.MultiSelect = false;
            this.dataCocina.Name = "dataCocina";
            this.dataCocina.ReadOnly = true;
            this.dataCocina.RowTemplate.Height = 24;
            this.dataCocina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataCocina.Size = new System.Drawing.Size(690, 109);
            this.dataCocina.TabIndex = 29;
            this.dataCocina.Visible = false;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Nota
            // 
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.ReadOnly = true;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(999, 20);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(17, 19);
            this.lblTelefono.TabIndex = 30;
            this.lblTelefono.Text = "0";
            this.lblTelefono.Visible = false;
            // 
            // frmCobroDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1518, 649);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.dataCocina);
            this.Controls.Add(this.lblDctoInd);
            this.Controls.Add(this.dataDetalle);
            this.Controls.Add(this.lblRepartidos);
            this.Controls.Add(this.lblNroDoc);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblIdCliente);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTipoComprobante);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataListado);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobroDelivery";
            this.Text = ".:: DELIVERY POR COBRAR ::.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCobroDelivery_FormClosed);
            this.Load += new System.EventHandler(this.frmCobroDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCocina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label lblEstado;
        public System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.Label lblVuelto;
        public System.Windows.Forms.Label lblTipoComprobante;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblIdCliente;
        public System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.Label lblDireccion;
        public System.Windows.Forms.Label lblNroDoc;
        public System.Windows.Forms.Label lblRepartidos;
        public System.Windows.Forms.DataGridView dataDetalle;
        public System.Windows.Forms.Label lblDctoInd;
        public System.Windows.Forms.Label lblIdVenta;
        public System.Windows.Forms.DataGridView dataCocina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        public System.Windows.Forms.Label lblTelefono;
    }
}