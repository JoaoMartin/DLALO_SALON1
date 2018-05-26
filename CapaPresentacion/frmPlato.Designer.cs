namespace CapaPresentacion
{
    partial class frmPlato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlato));
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbCategoria = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbEliminar = new System.Windows.Forms.CheckBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.cbQuitar = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecioVentaCompues = new System.Windows.Forms.TextBox();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.lblIdProdIns = new System.Windows.Forms.Label();
            this.lblIdProductoCom = new System.Windows.Forms.Label();
            this.lblIdDetalleCom = new System.Windows.Forms.Label();
            this.dataListadoDetalle = new System.Windows.Forms.DataGridView();
            this.Quitar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnEditarComp = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductoCompuesto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbUnidad = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbImprimir = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNroFilas = new System.Windows.Forms.Label();
            this.lblPosic = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.lblIdCategoria = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btnReceta = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.gbMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(12, 52);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(986, 655);
            this.tabControl2.TabIndex = 62;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.lblTotal);
            this.tabPage2.Controls.Add(this.dataListado);
            this.tabPage2.Controls.Add(this.cbEliminar);
            this.tabPage2.Controls.Add(this.lblTipo);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPage2.Size = new System.Drawing.Size(978, 624);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Listado General";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNombre);
            this.groupBox1.Controls.Add(this.rbTodos);
            this.groupBox1.Controls.Add(this.rbCategoria);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(827, 124);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de Búsqueda";
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Location = new System.Drawing.Point(26, 34);
            this.rbNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(83, 24);
            this.rbNombre.TabIndex = 8;
            this.rbNombre.TabStop = true;
            this.rbNombre.Text = "Nombre";
            this.rbNombre.UseVisualStyleBackColor = true;
            this.rbNombre.CheckedChanged += new System.EventHandler(this.rbNombre_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(360, 34);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(126, 24);
            this.rbTodos.TabIndex = 12;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Mostrar Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // rbCategoria
            // 
            this.rbCategoria.AutoSize = true;
            this.rbCategoria.Location = new System.Drawing.Point(187, 34);
            this.rbCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbCategoria.Name = "rbCategoria";
            this.rbCategoria.Size = new System.Drawing.Size(94, 24);
            this.rbCategoria.TabIndex = 9;
            this.rbCategoria.TabStop = true;
            this.rbCategoria.Text = "Categoría";
            this.rbCategoria.UseVisualStyleBackColor = true;
            this.rbCategoria.CheckedChanged += new System.EventHandler(this.rbCategoria_CheckedChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.Navy;
            this.txtBuscar.Location = new System.Drawing.Point(26, 67);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(749, 38);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotal.Location = new System.Drawing.Point(642, 146);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 20);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "label3";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dataListado.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataListado.Location = new System.Drawing.Point(6, 174);
            this.dataListado.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 24;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(966, 440);
            this.dataListado.TabIndex = 7;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.Click += new System.EventHandler(this.dataListado_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // cbEliminar
            // 
            this.cbEliminar.AutoSize = true;
            this.cbEliminar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEliminar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbEliminar.Location = new System.Drawing.Point(18, 145);
            this.cbEliminar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbEliminar.Name = "cbEliminar";
            this.cbEliminar.Size = new System.Drawing.Size(86, 24);
            this.cbEliminar.TabIndex = 5;
            this.cbEliminar.Text = "Eliminar";
            this.cbEliminar.UseVisualStyleBackColor = true;
            this.cbEliminar.CheckedChanged += new System.EventHandler(this.cbEliminar_CheckedChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(998, 330);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(18, 20);
            this.lblTipo.TabIndex = 56;
            this.lblTipo.Text = "0";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbMenu);
            this.tabPage3.Controls.Add(this.cbUnidad);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.cbImprimir);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtDescripcion);
            this.tabPage3.Controls.Add(this.txtPrecioVenta);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txtIdProducto);
            this.tabPage3.Controls.Add(this.cbCategoria);
            this.tabPage3.Controls.Add(this.txtNombre);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.lblNroFilas);
            this.tabPage3.Controls.Add(this.lblPosic);
            this.tabPage3.Controls.Add(this.lblIdProducto);
            this.tabPage3.Controls.Add(this.lblIdCategoria);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPage3.Size = new System.Drawing.Size(978, 624);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Nuevo/Modificar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.cbQuitar);
            this.gbMenu.Controls.Add(this.label12);
            this.gbMenu.Controls.Add(this.txtPrecioVentaCompues);
            this.gbMenu.Controls.Add(this.lblTipoProducto);
            this.gbMenu.Controls.Add(this.lblIdProdIns);
            this.gbMenu.Controls.Add(this.lblIdProductoCom);
            this.gbMenu.Controls.Add(this.lblIdDetalleCom);
            this.gbMenu.Controls.Add(this.dataListadoDetalle);
            this.gbMenu.Controls.Add(this.lblTotalVenta);
            this.gbMenu.Controls.Add(this.label13);
            this.gbMenu.Controls.Add(this.btnBuscarArticulo);
            this.gbMenu.Controls.Add(this.btnQuitar);
            this.gbMenu.Controls.Add(this.btnEditarComp);
            this.gbMenu.Controls.Add(this.txtCantidad);
            this.gbMenu.Controls.Add(this.label11);
            this.gbMenu.Controls.Add(this.txtProductoCompuesto);
            this.gbMenu.Controls.Add(this.label9);
            this.gbMenu.Location = new System.Drawing.Point(431, 29);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(541, 546);
            this.gbMenu.TabIndex = 63;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Platos Menu";
            this.gbMenu.Visible = false;
            // 
            // cbQuitar
            // 
            this.cbQuitar.AutoSize = true;
            this.cbQuitar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuitar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbQuitar.Location = new System.Drawing.Point(27, 178);
            this.cbQuitar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbQuitar.Name = "cbQuitar";
            this.cbQuitar.Size = new System.Drawing.Size(72, 24);
            this.cbQuitar.TabIndex = 68;
            this.cbQuitar.Text = "Quitar";
            this.cbQuitar.UseVisualStyleBackColor = true;
            this.cbQuitar.CheckedChanged += new System.EventHandler(this.cbQuitar_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 20);
            this.label12.TabIndex = 73;
            this.label12.Text = "Precio Venta";
            // 
            // txtPrecioVentaCompues
            // 
            this.txtPrecioVentaCompues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVentaCompues.Enabled = false;
            this.txtPrecioVentaCompues.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVentaCompues.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPrecioVentaCompues.Location = new System.Drawing.Point(22, 144);
            this.txtPrecioVentaCompues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioVentaCompues.MaxLength = 11;
            this.txtPrecioVentaCompues.Name = "txtPrecioVentaCompues";
            this.txtPrecioVentaCompues.ReadOnly = true;
            this.txtPrecioVentaCompues.Size = new System.Drawing.Size(98, 30);
            this.txtPrecioVentaCompues.TabIndex = 72;
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoProducto.Location = new System.Drawing.Point(460, 43);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(18, 20);
            this.lblTipoProducto.TabIndex = 71;
            this.lblTipoProducto.Text = "0";
            this.lblTipoProducto.Visible = false;
            // 
            // lblIdProdIns
            // 
            this.lblIdProdIns.AutoSize = true;
            this.lblIdProdIns.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProdIns.Location = new System.Drawing.Point(562, 53);
            this.lblIdProdIns.Name = "lblIdProdIns";
            this.lblIdProdIns.Size = new System.Drawing.Size(18, 20);
            this.lblIdProdIns.TabIndex = 69;
            this.lblIdProdIns.Text = "0";
            // 
            // lblIdProductoCom
            // 
            this.lblIdProductoCom.AutoSize = true;
            this.lblIdProductoCom.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProductoCom.Location = new System.Drawing.Point(420, 35);
            this.lblIdProductoCom.Name = "lblIdProductoCom";
            this.lblIdProductoCom.Size = new System.Drawing.Size(18, 20);
            this.lblIdProductoCom.TabIndex = 68;
            this.lblIdProductoCom.Text = "0";
            this.lblIdProductoCom.Visible = false;
            // 
            // lblIdDetalleCom
            // 
            this.lblIdDetalleCom.AutoSize = true;
            this.lblIdDetalleCom.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDetalleCom.Location = new System.Drawing.Point(460, 23);
            this.lblIdDetalleCom.Name = "lblIdDetalleCom";
            this.lblIdDetalleCom.Size = new System.Drawing.Size(18, 20);
            this.lblIdDetalleCom.TabIndex = 67;
            this.lblIdDetalleCom.Text = "0";
            this.lblIdDetalleCom.Visible = false;
            // 
            // dataListadoDetalle
            // 
            this.dataListadoDetalle.AllowUserToAddRows = false;
            this.dataListadoDetalle.AllowUserToDeleteRows = false;
            this.dataListadoDetalle.AllowUserToOrderColumns = true;
            this.dataListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Quitar});
            this.dataListadoDetalle.Location = new System.Drawing.Point(22, 210);
            this.dataListadoDetalle.MultiSelect = false;
            this.dataListadoDetalle.Name = "dataListadoDetalle";
            this.dataListadoDetalle.ReadOnly = true;
            this.dataListadoDetalle.RowTemplate.Height = 24;
            this.dataListadoDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoDetalle.Size = new System.Drawing.Size(494, 273);
            this.dataListadoDetalle.TabIndex = 66;
            this.dataListadoDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListadoDetalle_CellContentClick);
            this.dataListadoDetalle.Click += new System.EventHandler(this.dataListadoDetalle_Click);
            this.dataListadoDetalle.DoubleClick += new System.EventHandler(this.dataListadoDetalle_DoubleClick);
            // 
            // Quitar
            // 
            this.Quitar.HeaderText = "Quitar";
            this.Quitar.Name = "Quitar";
            this.Quitar.ReadOnly = true;
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenta.Location = new System.Drawing.Point(441, 503);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(49, 20);
            this.lblTotalVenta.TabIndex = 65;
            this.lblTotalVenta.Text = "00.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(363, 503);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 64;
            this.label13.Text = "Total";
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarArticulo.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArticulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscarArticulo.Image = global::CapaPresentacion.Properties.Resources.search5;
            this.btnBuscarArticulo.Location = new System.Drawing.Point(340, 59);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(47, 30);
            this.btnBuscarArticulo.TabIndex = 63;
            this.btnBuscarArticulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarArticulo.UseVisualStyleBackColor = false;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuitar.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.quitar2;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitar.Location = new System.Drawing.Point(340, 107);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(85, 65);
            this.btnQuitar.TabIndex = 61;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnEditarComp
            // 
            this.btnEditarComp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditarComp.Enabled = false;
            this.btnEditarComp.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarComp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditarComp.Image = global::CapaPresentacion.Properties.Resources.editar341;
            this.btnEditarComp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditarComp.Location = new System.Drawing.Point(431, 107);
            this.btnEditarComp.Name = "btnEditarComp";
            this.btnEditarComp.Size = new System.Drawing.Size(85, 65);
            this.btnEditarComp.TabIndex = 62;
            this.btnEditarComp.Text = "Editar";
            this.btnEditarComp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarComp.UseVisualStyleBackColor = false;
            this.btnEditarComp.Click += new System.EventHandler(this.btnEditarComp_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCantidad.Location = new System.Drawing.Point(140, 142);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(98, 30);
            this.txtCantidad.TabIndex = 58;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(136, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 58;
            this.label11.Text = "Cantidad";
            // 
            // txtProductoCompuesto
            // 
            this.txtProductoCompuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductoCompuesto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductoCompuesto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtProductoCompuesto.Location = new System.Drawing.Point(22, 59);
            this.txtProductoCompuesto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductoCompuesto.Name = "txtProductoCompuesto";
            this.txtProductoCompuesto.ReadOnly = true;
            this.txtProductoCompuesto.Size = new System.Drawing.Size(312, 30);
            this.txtProductoCompuesto.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Producto";
            // 
            // cbUnidad
            // 
            this.cbUnidad.BackColor = System.Drawing.Color.White;
            this.cbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUnidad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbUnidad.FormattingEnabled = true;
            this.cbUnidad.Location = new System.Drawing.Point(115, 129);
            this.cbUnidad.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbUnidad.Name = "cbUnidad";
            this.cbUnidad.Size = new System.Drawing.Size(310, 31);
            this.cbUnidad.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(49, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "Medida";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(34, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 60;
            this.label14.Text = "Categoria";
            // 
            // cbImprimir
            // 
            this.cbImprimir.BackColor = System.Drawing.Color.White;
            this.cbImprimir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImprimir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImprimir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbImprimir.FormattingEnabled = true;
            this.cbImprimir.Items.AddRange(new object[] {
            "Cocina",
            "Bar"});
            this.cbImprimir.Location = new System.Drawing.Point(115, 406);
            this.cbImprimir.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbImprimir.Name = "cbImprimir";
            this.cbImprimir.Size = new System.Drawing.Size(310, 31);
            this.cbImprimir.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Enviar a:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Precio Venta";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDescripcion.Location = new System.Drawing.Point(115, 234);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(310, 107);
            this.txtDescripcion.TabIndex = 6;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPrecioVenta.Location = new System.Drawing.Point(115, 354);
            this.txtPrecioVenta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPrecioVenta.MaxLength = 11;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(110, 30);
            this.txtPrecioVenta.TabIndex = 7;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Código";
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdProducto.Location = new System.Drawing.Point(115, 29);
            this.txtIdProducto.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.ReadOnly = true;
            this.txtIdProducto.Size = new System.Drawing.Size(126, 25);
            this.txtIdProducto.TabIndex = 50;
            // 
            // cbCategoria
            // 
            this.cbCategoria.BackColor = System.Drawing.Color.White;
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(115, 80);
            this.cbCategoria.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(310, 31);
            this.cbCategoria.TabIndex = 4;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNombre.Location = new System.Drawing.Point(115, 186);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(310, 30);
            this.txtNombre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Descripción";
            // 
            // lblNroFilas
            // 
            this.lblNroFilas.AutoSize = true;
            this.lblNroFilas.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFilas.Location = new System.Drawing.Point(209, 31);
            this.lblNroFilas.Name = "lblNroFilas";
            this.lblNroFilas.Size = new System.Drawing.Size(18, 20);
            this.lblNroFilas.TabIndex = 59;
            this.lblNroFilas.Text = "0";
            // 
            // lblPosic
            // 
            this.lblPosic.AutoSize = true;
            this.lblPosic.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosic.Location = new System.Drawing.Point(193, 31);
            this.lblPosic.Name = "lblPosic";
            this.lblPosic.Size = new System.Drawing.Size(18, 20);
            this.lblPosic.TabIndex = 58;
            this.lblPosic.Text = "0";
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProducto.Location = new System.Drawing.Point(170, 31);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(18, 20);
            this.lblIdProducto.TabIndex = 57;
            this.lblIdProducto.Text = "0";
            // 
            // lblIdCategoria
            // 
            this.lblIdCategoria.AutoSize = true;
            this.lblIdCategoria.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCategoria.Location = new System.Drawing.Point(143, 31);
            this.lblIdCategoria.Name = "lblIdCategoria";
            this.lblIdCategoria.Size = new System.Drawing.Size(18, 20);
            this.lblIdCategoria.TabIndex = 55;
            this.lblIdCategoria.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(489, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 38);
            this.label1.TabIndex = 61;
            this.label1.Text = "PLATOS";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // btnReceta
            // 
            this.btnReceta.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReceta.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReceta.Image = global::CapaPresentacion.Properties.Resources.if_Recipe_Book_89064;
            this.btnReceta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReceta.Location = new System.Drawing.Point(1039, 417);
            this.btnReceta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnReceta.Name = "btnReceta";
            this.btnReceta.Size = new System.Drawing.Size(110, 74);
            this.btnReceta.TabIndex = 67;
            this.btnReceta.Text = "&Receta";
            this.btnReceta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReceta.UseVisualStyleBackColor = false;
            this.btnReceta.Click += new System.EventHandler(this.btnReceta_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.save21;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(1039, 623);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 74);
            this.btnGuardar.TabIndex = 64;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.edit4;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(1039, 127);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 74);
            this.btnEditar.TabIndex = 65;
            this.btnEditar.Text = "E&ditar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImprimir.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImprimir.Image = global::CapaPresentacion.Properties.Resources.print4;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(1039, 318);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 74);
            this.btnImprimir.TabIndex = 59;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.new4;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(1039, 37);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 74);
            this.btnNuevo.TabIndex = 63;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.trash;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(1039, 221);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 74);
            this.btnEliminar.TabIndex = 60;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.cancel2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(1039, 517);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 74);
            this.btnCancelar.TabIndex = 66;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmPlato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1161, 711);
            this.Controls.Add(this.btnReceta);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlato";
            this.Text = "..: PLATOS ::.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPlato_FormClosed);
            this.Load += new System.EventHandler(this.frmPlato_Load);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReceta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbCategoria;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.CheckBox cbEliminar;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbUnidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbImprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblNroFilas;
        public System.Windows.Forms.Label lblPosic;
        public System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Label lblIdCategoria;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.GroupBox gbMenu;
        public System.Windows.Forms.Label lblTipoProducto;
        public System.Windows.Forms.Label lblIdProdIns;
        private System.Windows.Forms.Label lblIdProductoCom;
        private System.Windows.Forms.Label lblIdDetalleCom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBuscarArticulo;
        public System.Windows.Forms.Button btnQuitar;
        public System.Windows.Forms.Button btnEditarComp;
        public System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtProductoCompuesto;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DataGridView dataListadoDetalle;
        public System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtPrecioVentaCompues;
        private System.Windows.Forms.CheckBox cbQuitar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Quitar;
    }
}