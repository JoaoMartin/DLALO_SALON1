namespace CapaPresentacion
{
    partial class frmDividirCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDividirCuenta));
            this.dgSepara1 = new System.Windows.Forms.DataGridView();
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importePagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button20 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroDiv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lblIdMesa = new System.Windows.Forms.Label();
            this.lblIdTrabajador = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRedondeo = new System.Windows.Forms.Label();
            this.lblTrabajador = new System.Windows.Forms.Label();
            this.lblSalon = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSepara1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSepara1
            // 
            this.dgSepara1.AllowUserToAddRows = false;
            this.dgSepara1.AllowUserToDeleteRows = false;
            this.dgSepara1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgSepara1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSepara1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod,
            this.Producto,
            this.Cantidad,
            this.precioVenta,
            this.Descuento,
            this.Importe,
            this.importePagar,
            this.Barra,
            this.Tipo});
            this.dgSepara1.Location = new System.Drawing.Point(14, 151);
            this.dgSepara1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgSepara1.Name = "dgSepara1";
            this.dgSepara1.ReadOnly = true;
            this.dgSepara1.RowTemplate.Height = 24;
            this.dgSepara1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSepara1.Size = new System.Drawing.Size(988, 486);
            this.dgSepara1.TabIndex = 5;
            // 
            // Cod
            // 
            this.Cod.HeaderText = "Cod";
            this.Cod.Name = "Cod";
            this.Cod.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 320;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cant";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 75;
            // 
            // precioVenta
            // 
            this.precioVenta.HeaderText = "Precio_Un";
            this.precioVenta.Name = "precioVenta";
            this.precioVenta.ReadOnly = true;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // importePagar
            // 
            this.importePagar.HeaderText = "Importe Pagar";
            this.importePagar.Name = "importePagar";
            this.importePagar.ReadOnly = true;
            this.importePagar.Width = 150;
            // 
            // Barra
            // 
            this.Barra.HeaderText = "Barra";
            this.Barra.Name = "Barra";
            this.Barra.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button20.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Image = global::CapaPresentacion.Properties.Resources.if_12_1874864;
            this.button20.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button20.Location = new System.Drawing.Point(761, 34);
            this.button20.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(147, 98);
            this.button20.TabIndex = 9;
            this.button20.Text = "DIVIDIR";
            this.button20.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(271, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "cuentas";
            // 
            // txtNumeroDiv
            // 
            this.txtNumeroDiv.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDiv.Location = new System.Drawing.Point(153, 54);
            this.txtNumeroDiv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumeroDiv.Name = "txtNumeroDiv";
            this.txtNumeroDiv.Size = new System.Drawing.Size(112, 38);
            this.txtNumeroDiv.TabIndex = 0;
            this.txtNumeroDiv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDiv_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dividir en";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(635, 748);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total Por Persona";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(808, 746);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(62, 25);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "00.00";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPagar.Enabled = false;
            this.btnPagar.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Image = global::CapaPresentacion.Properties.Resources.if_cashbox_45016;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPagar.Location = new System.Drawing.Point(1021, 535);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(129, 102);
            this.btnPagar.TabIndex = 12;
            this.btnPagar.Text = "COBRAR";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // lblIdMesa
            // 
            this.lblIdMesa.AutoSize = true;
            this.lblIdMesa.Location = new System.Drawing.Point(197, 462);
            this.lblIdMesa.Name = "lblIdMesa";
            this.lblIdMesa.Size = new System.Drawing.Size(54, 20);
            this.lblIdMesa.TabIndex = 13;
            this.lblIdMesa.Text = "TOTAL";
            // 
            // lblIdTrabajador
            // 
            this.lblIdTrabajador.AutoSize = true;
            this.lblIdTrabajador.Location = new System.Drawing.Point(190, 546);
            this.lblIdTrabajador.Name = "lblIdTrabajador";
            this.lblIdTrabajador.Size = new System.Drawing.Size(54, 20);
            this.lblIdTrabajador.TabIndex = 15;
            this.lblIdTrabajador.Text = "TOTAL";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(812, 676);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(55, 23);
            this.lblDescuento.TabIndex = 17;
            this.lblDescuento.Text = "00.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(690, 676);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Descuento";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(812, 641);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(55, 23);
            this.lblSubTotal.TabIndex = 19;
            this.lblSubTotal.Text = "00.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(701, 641);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "SubTotal";
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(190, 504);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(17, 20);
            this.lblIdVenta.TabIndex = 20;
            this.lblIdVenta.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(694, 711);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Redondeo";
            // 
            // lblRedondeo
            // 
            this.lblRedondeo.AutoSize = true;
            this.lblRedondeo.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedondeo.Location = new System.Drawing.Point(812, 711);
            this.lblRedondeo.Name = "lblRedondeo";
            this.lblRedondeo.Size = new System.Drawing.Size(55, 23);
            this.lblRedondeo.TabIndex = 22;
            this.lblRedondeo.Text = "00.00";
            // 
            // lblTrabajador
            // 
            this.lblTrabajador.AutoSize = true;
            this.lblTrabajador.Location = new System.Drawing.Point(264, 546);
            this.lblTrabajador.Name = "lblTrabajador";
            this.lblTrabajador.Size = new System.Drawing.Size(54, 20);
            this.lblTrabajador.TabIndex = 23;
            this.lblTrabajador.Text = "TOTAL";
            // 
            // lblSalon
            // 
            this.lblSalon.AutoSize = true;
            this.lblSalon.Location = new System.Drawing.Point(264, 491);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(54, 20);
            this.lblSalon.TabIndex = 24;
            this.lblSalon.Text = "TOTAL";
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Location = new System.Drawing.Point(264, 449);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(54, 20);
            this.lblMesa.TabIndex = 25;
            this.lblMesa.Text = "TOTAL";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.cancel2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(1021, 406);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 93);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdUsuario.Location = new System.Drawing.Point(1121, 238);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(29, 32);
            this.lblIdUsuario.TabIndex = 174;
            this.lblIdUsuario.Text = "1";
            this.lblIdUsuario.Visible = false;
            // 
            // frmDividirCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 801);
            this.ControlBox = false;
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblRedondeo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumeroDiv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgSepara1);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lblSalon);
            this.Controls.Add(this.lblTrabajador);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.lblIdTrabajador);
            this.Controls.Add(this.lblIdMesa);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDividirCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: DIVIDIR CUENTA ::.";
            this.Load += new System.EventHandler(this.frmDividirCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSepara1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgSepara1;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroDiv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagar;
        public System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblIdVenta;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblRedondeo;
        public System.Windows.Forms.Label lblTrabajador;
        public System.Windows.Forms.Label lblSalon;
        public System.Windows.Forms.Label lblMesa;
        public System.Windows.Forms.Label lblIdMesa;
        public System.Windows.Forms.Label lblIdTrabajador;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn importePagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
    }
}