namespace CapaPresentacion
{
    partial class frmReporteVentasTipoComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteVentasTipoComprobante));
            this.lblCant = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBandera = new System.Windows.Forms.Label();
            this.rbElegir = new System.Windows.Forms.RadioButton();
            this.rbAperturaCaja = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.lblTotalIgv = new System.Windows.Forms.Label();
            this.lblTotalDcto = new System.Windows.Forms.Label();
            this.lblTotalEfectivo = new System.Windows.Forms.Label();
            this.lblTotalTarjeta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Location = new System.Drawing.Point(1510, 651);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(49, 20);
            this.lblCant.TabIndex = 92;
            this.lblCant.Text = "00.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1025, 653);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 91;
            this.label5.Text = "TOTAL";
            // 
            // lblBandera
            // 
            this.lblBandera.AutoSize = true;
            this.lblBandera.Location = new System.Drawing.Point(877, 71);
            this.lblBandera.Name = "lblBandera";
            this.lblBandera.Size = new System.Drawing.Size(17, 19);
            this.lblBandera.TabIndex = 90;
            this.lblBandera.Text = "0";
            this.lblBandera.Visible = false;
            // 
            // rbElegir
            // 
            this.rbElegir.AutoSize = true;
            this.rbElegir.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbElegir.Location = new System.Drawing.Point(28, 148);
            this.rbElegir.Name = "rbElegir";
            this.rbElegir.Size = new System.Drawing.Size(107, 23);
            this.rbElegir.TabIndex = 89;
            this.rbElegir.Text = "Elegir Fecha";
            this.rbElegir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbElegir.UseVisualStyleBackColor = true;
            this.rbElegir.CheckedChanged += new System.EventHandler(this.rbElegir_CheckedChanged);
            // 
            // rbAperturaCaja
            // 
            this.rbAperturaCaja.AutoSize = true;
            this.rbAperturaCaja.Checked = true;
            this.rbAperturaCaja.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAperturaCaja.Location = new System.Drawing.Point(28, 119);
            this.rbAperturaCaja.Name = "rbAperturaCaja";
            this.rbAperturaCaja.Size = new System.Drawing.Size(117, 23);
            this.rbAperturaCaja.TabIndex = 88;
            this.rbAperturaCaja.TabStop = true;
            this.rbAperturaCaja.Text = "Apertura Caja";
            this.rbAperturaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAperturaCaja.UseVisualStyleBackColor = true;
            this.rbAperturaCaja.CheckedChanged += new System.EventHandler(this.rbAperturaCaja_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 86;
            this.label1.Text = "Fecha Inicio";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(151, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 107);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 52;
            this.label2.Text = "Fecha Inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(97, 14);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(198, 27);
            this.dtpFechaInicio.TabIndex = 50;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(94, 66);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(198, 27);
            this.dtpFechaFin.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 19);
            this.label6.TabIndex = 53;
            this.label6.Text = "Fecha Fin";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(775, 50);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(17, 19);
            this.lblCaja.TabIndex = 85;
            this.lblCaja.Text = "0";
            this.lblCaja.Visible = false;
            // 
            // cbProducto
            // 
            this.cbProducto.BackColor = System.Drawing.Color.White;
            this.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Items.AddRange(new object[] {
            "TODOS",
            "TICKET",
            "BOLETA",
            "FACTURA",
            "ANULADA"});
            this.cbProducto.Location = new System.Drawing.Point(535, 152);
            this.cbProducto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(359, 31);
            this.cbProducto.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 19);
            this.label3.TabIndex = 83;
            this.label3.Text = "Seleccione Compbobante/Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(576, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(500, 28);
            this.label4.TabIndex = 82;
            this.label4.Text = "REPORTE DE VENTAS POR TIPO DE COMPROBANTE";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotal.Location = new System.Drawing.Point(1354, 210);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 20);
            this.lblTotal.TabIndex = 81;
            this.lblTotal.Text = "Total Registros:";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(24, 234);
            this.dataListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1576, 415);
            this.dataListado.TabIndex = 78;
            // 
            // lblTotalIgv
            // 
            this.lblTotalIgv.AutoSize = true;
            this.lblTotalIgv.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIgv.Location = new System.Drawing.Point(1399, 651);
            this.lblTotalIgv.Name = "lblTotalIgv";
            this.lblTotalIgv.Size = new System.Drawing.Size(49, 20);
            this.lblTotalIgv.TabIndex = 93;
            this.lblTotalIgv.Text = "00.00";
            // 
            // lblTotalDcto
            // 
            this.lblTotalDcto.AutoSize = true;
            this.lblTotalDcto.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDcto.Location = new System.Drawing.Point(1301, 651);
            this.lblTotalDcto.Name = "lblTotalDcto";
            this.lblTotalDcto.Size = new System.Drawing.Size(49, 20);
            this.lblTotalDcto.TabIndex = 94;
            this.lblTotalDcto.Text = "00.00";
            // 
            // lblTotalEfectivo
            // 
            this.lblTotalEfectivo.AutoSize = true;
            this.lblTotalEfectivo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEfectivo.Location = new System.Drawing.Point(1105, 653);
            this.lblTotalEfectivo.Name = "lblTotalEfectivo";
            this.lblTotalEfectivo.Size = new System.Drawing.Size(49, 20);
            this.lblTotalEfectivo.TabIndex = 95;
            this.lblTotalEfectivo.Text = "00.00";
            // 
            // lblTotalTarjeta
            // 
            this.lblTotalTarjeta.AutoSize = true;
            this.lblTotalTarjeta.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTarjeta.Location = new System.Drawing.Point(1213, 652);
            this.lblTotalTarjeta.Name = "lblTotalTarjeta";
            this.lblTotalTarjeta.Size = new System.Drawing.Size(49, 20);
            this.lblTotalTarjeta.TabIndex = 96;
            this.lblTotalTarjeta.Text = "00.00";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CapaPresentacion.Properties.Resources.if_Generate_tables_85519;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button1.Location = new System.Drawing.Point(899, 109);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 74);
            this.button1.TabIndex = 80;
            this.button1.Text = "Generar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImprimir.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImprimir.Image = global::CapaPresentacion.Properties.Resources.print4;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(1504, 107);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(96, 74);
            this.btnImprimir.TabIndex = 79;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmReporteVentasTipoComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1620, 725);
            this.Controls.Add(this.lblTotalTarjeta);
            this.Controls.Add(this.lblTotalEfectivo);
            this.Controls.Add(this.lblTotalDcto);
            this.Controls.Add(this.lblTotalIgv);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblBandera);
            this.Controls.Add(this.rbElegir);
            this.Controls.Add(this.rbAperturaCaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCaja);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dataListado);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteVentasTipoComprobante";
            this.Text = ".:: Reporte de Ventas por Tipo de Documento ::.";
            this.Load += new System.EventHandler(this.frmReporteVentasTipoComprobante_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblBandera;
        private System.Windows.Forms.RadioButton rbElegir;
        private System.Windows.Forms.RadioButton rbAperturaCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpFechaInicio;
        public System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblCaja;
        public System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label lblTotalIgv;
        private System.Windows.Forms.Label lblTotalDcto;
        private System.Windows.Forms.Label lblTotalEfectivo;
        private System.Windows.Forms.Label lblTotalTarjeta;
    }
}