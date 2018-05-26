namespace CapaPresentacion
{
    partial class frmMostrarComprobanteAnulado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostrarComprobanteAnulado));
            this.rbElegir = new System.Windows.Forms.RadioButton();
            this.rbAperturaCaja = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSumaTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.lblFechaGene = new System.Windows.Forms.Label();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblIdComprobante = new System.Windows.Forms.Label();
            this.lblRedondeo = new System.Windows.Forms.Label();
            this.lblForma = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.lblDcto = new System.Windows.Forms.Label();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblBandera = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // rbElegir
            // 
            this.rbElegir.AutoSize = true;
            this.rbElegir.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbElegir.Location = new System.Drawing.Point(51, 130);
            this.rbElegir.Name = "rbElegir";
            this.rbElegir.Size = new System.Drawing.Size(107, 23);
            this.rbElegir.TabIndex = 101;
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
            this.rbAperturaCaja.Location = new System.Drawing.Point(51, 101);
            this.rbAperturaCaja.Name = "rbAperturaCaja";
            this.rbAperturaCaja.Size = new System.Drawing.Size(117, 23);
            this.rbAperturaCaja.TabIndex = 100;
            this.rbAperturaCaja.TabStop = true;
            this.rbAperturaCaja.Text = "Apertura Caja";
            this.rbAperturaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAperturaCaja.UseVisualStyleBackColor = true;
            this.rbAperturaCaja.CheckedChanged += new System.EventHandler(this.rbAperturaCaja_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 98;
            this.label1.Text = "Fecha Inicio";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(174, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 107);
            this.groupBox1.TabIndex = 99;
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
            this.dtpFechaInicio.Location = new System.Drawing.Point(126, 21);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(198, 27);
            this.dtpFechaInicio.TabIndex = 50;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(126, 65);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(485, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(290, 28);
            this.label4.TabIndex = 83;
            this.label4.Text = "COMPROBANTES ANULADOS";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotal.Location = new System.Drawing.Point(1136, 152);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 20);
            this.lblTotal.TabIndex = 82;
            this.lblTotal.Text = "Total Registros:";
            // 
            // lblSumaTotal
            // 
            this.lblSumaTotal.AutoSize = true;
            this.lblSumaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumaTotal.Location = new System.Drawing.Point(1215, 692);
            this.lblSumaTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSumaTotal.Name = "lblSumaTotal";
            this.lblSumaTotal.Size = new System.Drawing.Size(54, 20);
            this.lblSumaTotal.TabIndex = 79;
            this.lblSumaTotal.Text = "00.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1126, 692);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 78;
            this.label3.Text = "TOTAL";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(13, 175);
            this.dataListado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1271, 498);
            this.dataListado.TabIndex = 77;
            // 
            // lblFechaGene
            // 
            this.lblFechaGene.AutoSize = true;
            this.lblFechaGene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaGene.Location = new System.Drawing.Point(746, 202);
            this.lblFechaGene.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaGene.Name = "lblFechaGene";
            this.lblFechaGene.Size = new System.Drawing.Size(19, 20);
            this.lblFechaGene.TabIndex = 88;
            this.lblFechaGene.Text = "0";
            this.lblFechaGene.Visible = false;
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobante.Location = new System.Drawing.Point(792, 219);
            this.lblComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(19, 20);
            this.lblComprobante.TabIndex = 87;
            this.lblComprobante.Text = "0";
            this.lblComprobante.Visible = false;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(834, 263);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(19, 20);
            this.lblNumero.TabIndex = 86;
            this.lblNumero.Text = "0";
            this.lblNumero.Visible = false;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(766, 175);
            this.lblSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(19, 20);
            this.lblSerie.TabIndex = 85;
            this.lblSerie.Text = "0";
            this.lblSerie.Visible = false;
            // 
            // lblIdComprobante
            // 
            this.lblIdComprobante.AutoSize = true;
            this.lblIdComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdComprobante.Location = new System.Drawing.Point(860, 202);
            this.lblIdComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdComprobante.Name = "lblIdComprobante";
            this.lblIdComprobante.Size = new System.Drawing.Size(19, 20);
            this.lblIdComprobante.TabIndex = 84;
            this.lblIdComprobante.Text = "0";
            this.lblIdComprobante.Visible = false;
            // 
            // lblRedondeo
            // 
            this.lblRedondeo.AutoSize = true;
            this.lblRedondeo.Location = new System.Drawing.Point(696, 200);
            this.lblRedondeo.Name = "lblRedondeo";
            this.lblRedondeo.Size = new System.Drawing.Size(17, 19);
            this.lblRedondeo.TabIndex = 97;
            this.lblRedondeo.Text = "0";
            this.lblRedondeo.Visible = false;
            // 
            // lblForma
            // 
            this.lblForma.AutoSize = true;
            this.lblForma.Location = new System.Drawing.Point(652, 217);
            this.lblForma.Name = "lblForma";
            this.lblForma.Size = new System.Drawing.Size(17, 19);
            this.lblForma.TabIndex = 96;
            this.lblForma.Text = "0";
            this.lblForma.Visible = false;
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(824, 243);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(17, 19);
            this.lblTarjeta.TabIndex = 95;
            this.lblTarjeta.Text = "0";
            this.lblTarjeta.Visible = false;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(758, 219);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(17, 19);
            this.lblEfectivo.TabIndex = 94;
            this.lblEfectivo.Text = "0";
            this.lblEfectivo.Visible = false;
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Location = new System.Drawing.Point(758, 176);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(17, 19);
            this.lblVuelto.TabIndex = 93;
            this.lblVuelto.Text = "0";
            this.lblVuelto.Visible = false;
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Location = new System.Drawing.Point(707, 238);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(17, 19);
            this.lblTotalVenta.TabIndex = 92;
            this.lblTotalVenta.Text = "0";
            this.lblTotalVenta.Visible = false;
            // 
            // lblIgv
            // 
            this.lblIgv.AutoSize = true;
            this.lblIgv.Location = new System.Drawing.Point(652, 200);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(17, 19);
            this.lblIgv.TabIndex = 91;
            this.lblIgv.Text = "0";
            this.lblIgv.Visible = false;
            // 
            // lblDcto
            // 
            this.lblDcto.AutoSize = true;
            this.lblDcto.Location = new System.Drawing.Point(670, 243);
            this.lblDcto.Name = "lblDcto";
            this.lblDcto.Size = new System.Drawing.Size(17, 19);
            this.lblDcto.TabIndex = 90;
            this.lblDcto.Text = "0";
            this.lblDcto.Visible = false;
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(784, 186);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(17, 19);
            this.lblIdVenta.TabIndex = 89;
            this.lblIdVenta.Text = "0";
            this.lblIdVenta.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CapaPresentacion.Properties.Resources.if_Generate_tables_85519;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(957, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 72);
            this.button1.TabIndex = 81;
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
            this.btnImprimir.Location = new System.Drawing.Point(1109, 72);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(175, 72);
            this.btnImprimir.TabIndex = 80;
            this.btnImprimir.Text = "&Imprimir Reporte";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBandera
            // 
            this.lblBandera.AutoSize = true;
            this.lblBandera.Location = new System.Drawing.Point(766, 123);
            this.lblBandera.Name = "lblBandera";
            this.lblBandera.Size = new System.Drawing.Size(17, 19);
            this.lblBandera.TabIndex = 102;
            this.lblBandera.Text = "0";
            this.lblBandera.Visible = false;
            // 
            // frmMostrarComprobanteAnulado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1323, 721);
            this.Controls.Add(this.lblBandera);
            this.Controls.Add(this.rbElegir);
            this.Controls.Add(this.rbAperturaCaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblSumaTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataListado);
            this.Controls.Add(this.lblFechaGene);
            this.Controls.Add(this.lblComprobante);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.lblIdComprobante);
            this.Controls.Add(this.lblRedondeo);
            this.Controls.Add(this.lblForma);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.lblTotalVenta);
            this.Controls.Add(this.lblIgv);
            this.Controls.Add(this.lblDcto);
            this.Controls.Add(this.lblIdVenta);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMostrarComprobanteAnulado";
            this.Text = ".::COMPROBANTES ANULADOS::.";
            this.Load += new System.EventHandler(this.frmMostrarComprobanteAnulado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbElegir;
        private System.Windows.Forms.RadioButton rbAperturaCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpFechaInicio;
        public System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblSumaTotal;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dataListado;
        public System.Windows.Forms.Label lblFechaGene;
        public System.Windows.Forms.Label lblComprobante;
        public System.Windows.Forms.Label lblNumero;
        public System.Windows.Forms.Label lblSerie;
        public System.Windows.Forms.Label lblIdComprobante;
        public System.Windows.Forms.Label lblRedondeo;
        public System.Windows.Forms.Label lblForma;
        public System.Windows.Forms.Label lblTarjeta;
        public System.Windows.Forms.Label lblEfectivo;
        public System.Windows.Forms.Label lblVuelto;
        public System.Windows.Forms.Label lblTotalVenta;
        public System.Windows.Forms.Label lblIgv;
        public System.Windows.Forms.Label lblDcto;
        public System.Windows.Forms.Label lblIdVenta;
        public System.Windows.Forms.Label lblBandera;
    }
}