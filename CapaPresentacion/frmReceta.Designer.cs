namespace CapaPresentacion
{
    partial class frmReceta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceta));
            this.lblIdProdReceta = new System.Windows.Forms.Label();
            this.lblIdDetalleR = new System.Windows.Forms.Label();
            this.lblIdProductoCom = new System.Windows.Forms.Label();
            this.lblNroFilaReceta = new System.Windows.Forms.Label();
            this.lblIdProd = new System.Windows.Forms.Label();
            this.lblIdInsumo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.lblTotalR = new System.Windows.Forms.Label();
            this.dataListadoDetalleR = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.btnQuitarInsumo = new System.Windows.Forms.Button();
            this.txtCantidadInsumo = new System.Windows.Forms.TextBox();
            this.btnEditarInsumo = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnAgregarInsumo = new System.Windows.Forms.Button();
            this.btnGuardarReceta = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtInsumo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblPlato = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.lblPosic = new System.Windows.Forms.Label();
            this.lblIdReceta = new System.Windows.Forms.Label();
            this.lblIdDetalleReceta = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalleR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdProdReceta
            // 
            this.lblIdProdReceta.AutoSize = true;
            this.lblIdProdReceta.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProdReceta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdProdReceta.Location = new System.Drawing.Point(460, 10);
            this.lblIdProdReceta.Name = "lblIdProdReceta";
            this.lblIdProdReceta.Size = new System.Drawing.Size(20, 23);
            this.lblIdProdReceta.TabIndex = 75;
            this.lblIdProdReceta.Text = "0";
            this.lblIdProdReceta.Visible = false;
            // 
            // lblIdDetalleR
            // 
            this.lblIdDetalleR.AutoSize = true;
            this.lblIdDetalleR.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDetalleR.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdDetalleR.Location = new System.Drawing.Point(775, 10);
            this.lblIdDetalleR.Name = "lblIdDetalleR";
            this.lblIdDetalleR.Size = new System.Drawing.Size(20, 23);
            this.lblIdDetalleR.TabIndex = 76;
            this.lblIdDetalleR.Text = "0";
            this.lblIdDetalleR.Visible = false;
            // 
            // lblIdProductoCom
            // 
            this.lblIdProductoCom.AutoSize = true;
            this.lblIdProductoCom.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProductoCom.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdProductoCom.Location = new System.Drawing.Point(830, 10);
            this.lblIdProductoCom.Name = "lblIdProductoCom";
            this.lblIdProductoCom.Size = new System.Drawing.Size(20, 23);
            this.lblIdProductoCom.TabIndex = 69;
            this.lblIdProductoCom.Text = "0";
            this.lblIdProductoCom.Visible = false;
            // 
            // lblNroFilaReceta
            // 
            this.lblNroFilaReceta.AutoSize = true;
            this.lblNroFilaReceta.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFilaReceta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNroFilaReceta.Location = new System.Drawing.Point(532, 10);
            this.lblNroFilaReceta.Name = "lblNroFilaReceta";
            this.lblNroFilaReceta.Size = new System.Drawing.Size(20, 23);
            this.lblNroFilaReceta.TabIndex = 74;
            this.lblNroFilaReceta.Text = "0";
            this.lblNroFilaReceta.Visible = false;
            // 
            // lblIdProd
            // 
            this.lblIdProd.AutoSize = true;
            this.lblIdProd.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdProd.Location = new System.Drawing.Point(640, 10);
            this.lblIdProd.Name = "lblIdProd";
            this.lblIdProd.Size = new System.Drawing.Size(20, 23);
            this.lblIdProd.TabIndex = 73;
            this.lblIdProd.Text = "0";
            this.lblIdProd.Visible = false;
            // 
            // lblIdInsumo
            // 
            this.lblIdInsumo.AutoSize = true;
            this.lblIdInsumo.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdInsumo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdInsumo.Location = new System.Drawing.Point(366, 10);
            this.lblIdInsumo.Name = "lblIdInsumo";
            this.lblIdInsumo.Size = new System.Drawing.Size(20, 23);
            this.lblIdInsumo.TabIndex = 71;
            this.lblIdInsumo.Text = "0";
            this.lblIdInsumo.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtUnidad);
            this.groupBox3.Controls.Add(this.lblTotalR);
            this.groupBox3.Controls.Add(this.dataListadoDetalleR);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.btnQuitarInsumo);
            this.groupBox3.Controls.Add(this.txtCantidadInsumo);
            this.groupBox3.Controls.Add(this.btnEditarInsumo);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.btnAgregarInsumo);
            this.groupBox3.Controls.Add(this.btnGuardarReceta);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtCosto);
            this.groupBox3.Controls.Add(this.txtInsumo);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Location = new System.Drawing.Point(12, 74);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(1063, 622);
            this.groupBox3.TabIndex = 70;
            this.groupBox3.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(214, 114);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 20);
            this.label21.TabIndex = 70;
            this.label21.Text = "Unidad";
            // 
            // txtUnidad
            // 
            this.txtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnidad.Enabled = false;
            this.txtUnidad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnidad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtUnidad.Location = new System.Drawing.Point(282, 100);
            this.txtUnidad.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUnidad.MaxLength = 11;
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.ReadOnly = true;
            this.txtUnidad.Size = new System.Drawing.Size(110, 30);
            this.txtUnidad.TabIndex = 69;
            // 
            // lblTotalR
            // 
            this.lblTotalR.AutoSize = true;
            this.lblTotalR.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalR.Location = new System.Drawing.Point(803, 574);
            this.lblTotalR.Name = "lblTotalR";
            this.lblTotalR.Size = new System.Drawing.Size(62, 26);
            this.lblTotalR.TabIndex = 68;
            this.lblTotalR.Text = "00.00";
            // 
            // dataListadoDetalleR
            // 
            this.dataListadoDetalleR.AllowUserToAddRows = false;
            this.dataListadoDetalleR.AllowUserToDeleteRows = false;
            this.dataListadoDetalleR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalleR.Location = new System.Drawing.Point(29, 176);
            this.dataListadoDetalleR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataListadoDetalleR.Name = "dataListadoDetalleR";
            this.dataListadoDetalleR.ReadOnly = true;
            this.dataListadoDetalleR.RowTemplate.Height = 24;
            this.dataListadoDetalleR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoDetalleR.Size = new System.Drawing.Size(875, 385);
            this.dataListadoDetalleR.TabIndex = 66;
            this.dataListadoDetalleR.Click += new System.EventHandler(this.dataListadoDetalleR_Click);
            this.dataListadoDetalleR.DoubleClick += new System.EventHandler(this.dataListadoDetalleR_DoubleClick);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(738, 581);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 20);
            this.label24.TabIndex = 67;
            this.label24.Text = "Total";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(744, 635);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 20);
            this.label16.TabIndex = 65;
            this.label16.Text = "00.00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(656, 635);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 20);
            this.label17.TabIndex = 64;
            this.label17.Text = "Total";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.Image = global::CapaPresentacion.Properties.Resources.search5;
            this.button7.Location = new System.Drawing.Point(533, 39);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 38);
            this.button7.TabIndex = 63;
            this.button7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnQuitarInsumo
            // 
            this.btnQuitarInsumo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuitarInsumo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarInsumo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuitarInsumo.Image = global::CapaPresentacion.Properties.Resources.quitar2;
            this.btnQuitarInsumo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitarInsumo.Location = new System.Drawing.Point(736, 67);
            this.btnQuitarInsumo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuitarInsumo.Name = "btnQuitarInsumo";
            this.btnQuitarInsumo.Size = new System.Drawing.Size(81, 61);
            this.btnQuitarInsumo.TabIndex = 61;
            this.btnQuitarInsumo.Text = "Quitar";
            this.btnQuitarInsumo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarInsumo.UseVisualStyleBackColor = false;
            this.btnQuitarInsumo.Click += new System.EventHandler(this.btnQuitarInsumo_Click);
            // 
            // txtCantidadInsumo
            // 
            this.txtCantidadInsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadInsumo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadInsumo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCantidadInsumo.Location = new System.Drawing.Point(476, 100);
            this.txtCantidadInsumo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCantidadInsumo.Name = "txtCantidadInsumo";
            this.txtCantidadInsumo.ReadOnly = true;
            this.txtCantidadInsumo.Size = new System.Drawing.Size(110, 30);
            this.txtCantidadInsumo.TabIndex = 58;
            this.txtCantidadInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadInsumo_KeyPress);
            // 
            // btnEditarInsumo
            // 
            this.btnEditarInsumo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditarInsumo.Enabled = false;
            this.btnEditarInsumo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarInsumo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditarInsumo.Image = global::CapaPresentacion.Properties.Resources.editar341;
            this.btnEditarInsumo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditarInsumo.Location = new System.Drawing.Point(823, 67);
            this.btnEditarInsumo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditarInsumo.Name = "btnEditarInsumo";
            this.btnEditarInsumo.Size = new System.Drawing.Size(81, 61);
            this.btnEditarInsumo.TabIndex = 62;
            this.btnEditarInsumo.Text = "Editar";
            this.btnEditarInsumo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarInsumo.UseVisualStyleBackColor = false;
            this.btnEditarInsumo.Click += new System.EventHandler(this.btnEditarInsumo_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(399, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 20);
            this.label19.TabIndex = 58;
            this.label19.Text = "Cantidad";
            // 
            // btnAgregarInsumo
            // 
            this.btnAgregarInsumo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarInsumo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarInsumo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregarInsumo.Image = global::CapaPresentacion.Properties.Resources.plus1;
            this.btnAgregarInsumo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarInsumo.Location = new System.Drawing.Point(649, 67);
            this.btnAgregarInsumo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarInsumo.Name = "btnAgregarInsumo";
            this.btnAgregarInsumo.Size = new System.Drawing.Size(81, 61);
            this.btnAgregarInsumo.TabIndex = 60;
            this.btnAgregarInsumo.Text = "Agregar";
            this.btnAgregarInsumo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarInsumo.UseVisualStyleBackColor = false;
            this.btnAgregarInsumo.Click += new System.EventHandler(this.btnAgregarInsumo_Click);
            // 
            // btnGuardarReceta
            // 
            this.btnGuardarReceta.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarReceta.Enabled = false;
            this.btnGuardarReceta.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarReceta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardarReceta.Image = global::CapaPresentacion.Properties.Resources.save21;
            this.btnGuardarReceta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarReceta.Location = new System.Drawing.Point(910, 481);
            this.btnGuardarReceta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGuardarReceta.Name = "btnGuardarReceta";
            this.btnGuardarReceta.Size = new System.Drawing.Size(119, 80);
            this.btnGuardarReceta.TabIndex = 61;
            this.btnGuardarReceta.Text = "&Guardar";
            this.btnGuardarReceta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarReceta.UseVisualStyleBackColor = false;
            this.btnGuardarReceta.Click += new System.EventHandler(this.btnGuardarReceta_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(36, 114);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 20);
            this.label18.TabIndex = 59;
            this.label18.Text = "Costo";
            // 
            // txtCosto
            // 
            this.txtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCosto.Enabled = false;
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCosto.Location = new System.Drawing.Point(97, 100);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCosto.MaxLength = 11;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(110, 30);
            this.txtCosto.TabIndex = 58;
            // 
            // txtInsumo
            // 
            this.txtInsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInsumo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsumo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInsumo.Location = new System.Drawing.Point(97, 38);
            this.txtInsumo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtInsumo.Name = "txtInsumo";
            this.txtInsumo.ReadOnly = true;
            this.txtInsumo.Size = new System.Drawing.Size(430, 30);
            this.txtInsumo.TabIndex = 57;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(25, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 20);
            this.label20.TabIndex = 19;
            this.label20.Text = "Insumo";
            // 
            // lblPlato
            // 
            this.lblPlato.AutoSize = true;
            this.lblPlato.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlato.Location = new System.Drawing.Point(73, 26);
            this.lblPlato.Name = "lblPlato";
            this.lblPlato.Size = new System.Drawing.Size(83, 37);
            this.lblPlato.TabIndex = 72;
            this.lblPlato.Text = "Plato";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 20);
            this.label15.TabIndex = 68;
            this.label15.Text = "Plato";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // lblPosic
            // 
            this.lblPosic.AutoSize = true;
            this.lblPosic.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosic.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPosic.Location = new System.Drawing.Point(918, 38);
            this.lblPosic.Name = "lblPosic";
            this.lblPosic.Size = new System.Drawing.Size(20, 23);
            this.lblPosic.TabIndex = 77;
            this.lblPosic.Text = "0";
            this.lblPosic.Visible = false;
            // 
            // lblIdReceta
            // 
            this.lblIdReceta.AutoSize = true;
            this.lblIdReceta.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdReceta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdReceta.Location = new System.Drawing.Point(997, 22);
            this.lblIdReceta.Name = "lblIdReceta";
            this.lblIdReceta.Size = new System.Drawing.Size(20, 23);
            this.lblIdReceta.TabIndex = 78;
            this.lblIdReceta.Text = "0";
            this.lblIdReceta.Visible = false;
            // 
            // lblIdDetalleReceta
            // 
            this.lblIdDetalleReceta.AutoSize = true;
            this.lblIdDetalleReceta.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDetalleReceta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIdDetalleReceta.Location = new System.Drawing.Point(690, 38);
            this.lblIdDetalleReceta.Name = "lblIdDetalleReceta";
            this.lblIdDetalleReceta.Size = new System.Drawing.Size(20, 23);
            this.lblIdDetalleReceta.TabIndex = 79;
            this.lblIdDetalleReceta.Text = "0";
            // 
            // frmReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1077, 728);
            this.Controls.Add(this.lblIdDetalleReceta);
            this.Controls.Add(this.lblIdReceta);
            this.Controls.Add(this.lblPosic);
            this.Controls.Add(this.lblIdProdReceta);
            this.Controls.Add(this.lblIdDetalleR);
            this.Controls.Add(this.lblIdProductoCom);
            this.Controls.Add(this.lblNroFilaReceta);
            this.Controls.Add(this.lblIdProd);
            this.Controls.Add(this.lblIdInsumo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblPlato);
            this.Controls.Add(this.label15);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: RECETA ::.";
            this.Load += new System.EventHandler(this.frmReceta_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalleR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblIdProdReceta;
        public System.Windows.Forms.Label lblIdDetalleR;
        public System.Windows.Forms.Label lblIdProductoCom;
        public System.Windows.Forms.Label lblNroFilaReceta;
        public System.Windows.Forms.Label lblIdProd;
        public System.Windows.Forms.Label lblIdInsumo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.Label lblTotalR;
        private System.Windows.Forms.DataGridView dataListadoDetalleR;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button btnQuitarInsumo;
        public System.Windows.Forms.TextBox txtCantidadInsumo;
        public System.Windows.Forms.Button btnEditarInsumo;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.Button btnAgregarInsumo;
        private System.Windows.Forms.Button btnGuardarReceta;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtCosto;
        public System.Windows.Forms.TextBox txtInsumo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        public System.Windows.Forms.Label lblPosic;
        public System.Windows.Forms.Label lblPlato;
        public System.Windows.Forms.Label lblIdReceta;
        public System.Windows.Forms.Label lblIdDetalleReceta;
    }
}