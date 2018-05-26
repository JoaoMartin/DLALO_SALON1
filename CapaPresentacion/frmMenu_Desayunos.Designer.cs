namespace CapaPresentacion
{
    partial class frmMenu_Desayunos
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
            this.gbMeseros = new System.Windows.Forms.GroupBox();
            this.dataListadoDetalle = new System.Windows.Forms.DataGridView();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblIdPlato = new System.Windows.Forms.Label();
            this.dtStock = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQueda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBanderaMenu = new System.Windows.Forms.Label();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnPedido = new System.Windows.Forms.Button();
            this.lblNroFilasDataMenu = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMeseros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStock)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMeseros
            // 
            this.gbMeseros.Controls.Add(this.lblDescuento);
            this.gbMeseros.Controls.Add(this.lblPrecioUnitario);
            this.gbMeseros.Controls.Add(this.lblNota);
            this.gbMeseros.Controls.Add(this.lblIdPlato);
            this.gbMeseros.Controls.Add(this.lblBanderaMenu);
            this.gbMeseros.Controls.Add(this.lblDescripcion);
            this.gbMeseros.Controls.Add(this.lblNroFilasDataMenu);
            this.gbMeseros.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMeseros.Location = new System.Drawing.Point(444, 68);
            this.gbMeseros.Name = "gbMeseros";
            this.gbMeseros.Size = new System.Drawing.Size(739, 532);
            this.gbMeseros.TabIndex = 1;
            this.gbMeseros.TabStop = false;
            this.gbMeseros.Text = "PLATOS ";
            // 
            // dataListadoDetalle
            // 
            this.dataListadoDetalle.AllowUserToAddRows = false;
            this.dataListadoDetalle.AllowUserToDeleteRows = false;
            this.dataListadoDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dataListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalle.Location = new System.Drawing.Point(11, 78);
            this.dataListadoDetalle.Name = "dataListadoDetalle";
            this.dataListadoDetalle.ReadOnly = true;
            this.dataListadoDetalle.RowTemplate.Height = 24;
            this.dataListadoDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoDetalle.Size = new System.Drawing.Size(427, 522);
            this.dataListadoDetalle.TabIndex = 33;
            this.dataListadoDetalle.Click += new System.EventHandler(this.dataListadoDetalle_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(12, 29);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(110, 43);
            this.txtCantidad.TabIndex = 52;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIdPlato
            // 
            this.lblIdPlato.AutoSize = true;
            this.lblIdPlato.Location = new System.Drawing.Point(99, 155);
            this.lblIdPlato.Name = "lblIdPlato";
            this.lblIdPlato.Size = new System.Drawing.Size(18, 20);
            this.lblIdPlato.TabIndex = 53;
            this.lblIdPlato.Text = "0";
            this.lblIdPlato.Visible = false;
            // 
            // dtStock
            // 
            this.dtStock.AllowUserToAddRows = false;
            this.dtStock.AllowUserToDeleteRows = false;
            this.dtStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.StockQueda});
            this.dtStock.Location = new System.Drawing.Point(1199, 78);
            this.dtStock.Name = "dtStock";
            this.dtStock.ReadOnly = true;
            this.dtStock.RowTemplate.Height = 24;
            this.dtStock.Size = new System.Drawing.Size(268, 175);
            this.dtStock.TabIndex = 87;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // StockQueda
            // 
            this.StockQueda.HeaderText = "StockQueda";
            this.StockQueda.Name = "StockQueda";
            this.StockQueda.ReadOnly = true;
            // 
            // lblBanderaMenu
            // 
            this.lblBanderaMenu.AutoSize = true;
            this.lblBanderaMenu.Location = new System.Drawing.Point(169, 155);
            this.lblBanderaMenu.Name = "lblBanderaMenu";
            this.lblBanderaMenu.Size = new System.Drawing.Size(18, 20);
            this.lblBanderaMenu.TabIndex = 88;
            this.lblBanderaMenu.Text = "0";
            this.lblBanderaMenu.Visible = false;
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.LightGray;
            this.btnManual.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManual.Image = global::CapaPresentacion.Properties.Resources.if_remove_ticket_49613__1_;
            this.btnManual.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnManual.Location = new System.Drawing.Point(998, 609);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(185, 66);
            this.btnManual.TabIndex = 90;
            this.btnManual.Text = "CANCELAR";
            this.btnManual.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnPedido
            // 
            this.btnPedido.BackColor = System.Drawing.Color.LightGray;
            this.btnPedido.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedido.Image = global::CapaPresentacion.Properties.Resources.if_food_hamburder_v1_2386376;
            this.btnPedido.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPedido.Location = new System.Drawing.Point(820, 609);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(165, 68);
            this.btnPedido.TabIndex = 89;
            this.btnPedido.Text = "ACEPTAR";
            this.btnPedido.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnPedido.UseVisualStyleBackColor = false;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
            // 
            // lblNroFilasDataMenu
            // 
            this.lblNroFilasDataMenu.AutoSize = true;
            this.lblNroFilasDataMenu.Location = new System.Drawing.Point(239, 155);
            this.lblNroFilasDataMenu.Name = "lblNroFilasDataMenu";
            this.lblNroFilasDataMenu.Size = new System.Drawing.Size(18, 20);
            this.lblNroFilasDataMenu.TabIndex = 91;
            this.lblNroFilasDataMenu.Text = "0";
            this.lblNroFilasDataMenu.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(314, 155);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(18, 20);
            this.lblDescripcion.TabIndex = 92;
            this.lblDescripcion.Text = "0";
            this.lblDescripcion.Visible = false;
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(372, 155);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(18, 20);
            this.lblPrecioUnitario.TabIndex = 93;
            this.lblPrecioUnitario.Text = "0";
            this.lblPrecioUnitario.Visible = false;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(482, 155);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(18, 20);
            this.lblNota.TabIndex = 94;
            this.lblNota.Text = "0";
            this.lblNota.Visible = false;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(544, 155);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(18, 20);
            this.lblDescuento.TabIndex = 95;
            this.lblDescuento.Text = "0";
            this.lblDescuento.Visible = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.cancel2;
            this.btnQuitar.Location = new System.Drawing.Point(142, 27);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(70, 45);
            this.btnQuitar.TabIndex = 91;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(421, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 38);
            this.label1.TabIndex = 92;
            this.label1.Text = "SELECCIONE LOS PLATOS";
            // 
            // frmMenu_Desayunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1187, 687);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnPedido);
            this.Controls.Add(this.dtStock);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.dataListadoDetalle);
            this.Controls.Add(this.gbMeseros);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu_Desayunos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: SELECCIONAR PLATOS ::.";
            this.Load += new System.EventHandler(this.frmMenu_Desayunos_Load);
            this.gbMeseros.ResumeLayout(false);
            this.gbMeseros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMeseros;
        public System.Windows.Forms.DataGridView dataListadoDetalle;
        public System.Windows.Forms.TextBox txtCantidad;
        public System.Windows.Forms.Label lblIdPlato;
        private System.Windows.Forms.DataGridView dtStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQueda;
        public System.Windows.Forms.Label lblBanderaMenu;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnPedido;
        public System.Windows.Forms.Label lblNroFilasDataMenu;
        public System.Windows.Forms.Label lblDescripcion;
        public System.Windows.Forms.Label lblPrecioUnitario;
        public System.Windows.Forms.Label lblNota;
        public System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label label1;
    }
}