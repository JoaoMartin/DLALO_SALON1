namespace CapaPresentacion
{
    partial class frmMesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesa));
            this.gbSalon = new System.Windows.Forms.GroupBox();
            this.lblIdSalon = new System.Windows.Forms.Label();
            this.gbMesa = new System.Windows.Forms.GroupBox();
            this.lblPrueba = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblIdMesa = new System.Windows.Forms.Label();
            this.lblNroMesas = new System.Windows.Forms.Label();
            this.gbNuevaMesa = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbEditarMesa = new System.Windows.Forms.GroupBox();
            this.btnCancelarEdit = new System.Windows.Forms.Button();
            this.btnGuardarEdit = new System.Windows.Forms.Button();
            this.txtNombreEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNuevaMesa = new System.Windows.Forms.Button();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.gbMesa.SuspendLayout();
            this.gbNuevaMesa.SuspendLayout();
            this.gbEditarMesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSalon
            // 
            this.gbSalon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbSalon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSalon.ForeColor = System.Drawing.Color.Navy;
            this.gbSalon.Location = new System.Drawing.Point(12, 83);
            this.gbSalon.Name = "gbSalon";
            this.gbSalon.Size = new System.Drawing.Size(147, 663);
            this.gbSalon.TabIndex = 0;
            this.gbSalon.TabStop = false;
            this.gbSalon.Text = "SALONES";
            // 
            // lblIdSalon
            // 
            this.lblIdSalon.AutoSize = true;
            this.lblIdSalon.Location = new System.Drawing.Point(145, 18);
            this.lblIdSalon.Name = "lblIdSalon";
            this.lblIdSalon.Size = new System.Drawing.Size(0, 20);
            this.lblIdSalon.TabIndex = 5;
            // 
            // gbMesa
            // 
            this.gbMesa.Controls.Add(this.lblPrueba);
            this.gbMesa.Controls.Add(this.btnCancel);
            this.gbMesa.Controls.Add(this.btnEliminar);
            this.gbMesa.Controls.Add(this.btnEditar);
            this.gbMesa.Controls.Add(this.lblIdMesa);
            this.gbMesa.Controls.Add(this.lblNroMesas);
            this.gbMesa.Controls.Add(this.gbNuevaMesa);
            this.gbMesa.Controls.Add(this.btnNuevaMesa);
            this.gbMesa.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMesa.Location = new System.Drawing.Point(165, 18);
            this.gbMesa.Name = "gbMesa";
            this.gbMesa.Size = new System.Drawing.Size(1054, 728);
            this.gbMesa.TabIndex = 6;
            this.gbMesa.TabStop = false;
            this.gbMesa.Text = "MESAS";
            // 
            // lblPrueba
            // 
            this.lblPrueba.AutoSize = true;
            this.lblPrueba.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrueba.ForeColor = System.Drawing.Color.Navy;
            this.lblPrueba.Location = new System.Drawing.Point(570, -4);
            this.lblPrueba.Name = "lblPrueba";
            this.lblPrueba.Size = new System.Drawing.Size(111, 38);
            this.lblPrueba.TabIndex = 7;
            this.lblPrueba.Text = "MESAS";
            this.lblPrueba.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Image = global::CapaPresentacion.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(950, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 78);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.delete;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(827, 58);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(117, 78);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar Mesa";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEditar.Enabled = false;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.editar1;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(713, 58);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(108, 78);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar Mesa";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblIdMesa
            // 
            this.lblIdMesa.AutoSize = true;
            this.lblIdMesa.Location = new System.Drawing.Point(657, 88);
            this.lblIdMesa.Name = "lblIdMesa";
            this.lblIdMesa.Size = new System.Drawing.Size(0, 26);
            this.lblIdMesa.TabIndex = 3;
            // 
            // lblNroMesas
            // 
            this.lblNroMesas.AutoSize = true;
            this.lblNroMesas.Location = new System.Drawing.Point(988, 26);
            this.lblNroMesas.Name = "lblNroMesas";
            this.lblNroMesas.Size = new System.Drawing.Size(0, 26);
            this.lblNroMesas.TabIndex = 2;
            // 
            // gbNuevaMesa
            // 
            this.gbNuevaMesa.Controls.Add(this.btnCancelar);
            this.gbNuevaMesa.Controls.Add(this.gbEditarMesa);
            this.gbNuevaMesa.Controls.Add(this.btnGuardar);
            this.gbNuevaMesa.Controls.Add(this.txtNombre);
            this.gbNuevaMesa.Controls.Add(this.label3);
            this.gbNuevaMesa.Location = new System.Drawing.Point(120, 44);
            this.gbNuevaMesa.Name = "gbNuevaMesa";
            this.gbNuevaMesa.Size = new System.Drawing.Size(456, 85);
            this.gbNuevaMesa.TabIndex = 1;
            this.gbNuevaMesa.TabStop = false;
            this.gbNuevaMesa.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(349, 26);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 49);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbEditarMesa
            // 
            this.gbEditarMesa.Controls.Add(this.btnCancelarEdit);
            this.gbEditarMesa.Controls.Add(this.btnGuardarEdit);
            this.gbEditarMesa.Controls.Add(this.txtNombreEdit);
            this.gbEditarMesa.Controls.Add(this.label2);
            this.gbEditarMesa.Location = new System.Drawing.Point(34, 7);
            this.gbEditarMesa.Name = "gbEditarMesa";
            this.gbEditarMesa.Size = new System.Drawing.Size(455, 85);
            this.gbEditarMesa.TabIndex = 7;
            this.gbEditarMesa.TabStop = false;
            this.gbEditarMesa.Visible = false;
            // 
            // btnCancelarEdit
            // 
            this.btnCancelarEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelarEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelarEdit.Image = global::CapaPresentacion.Properties.Resources.cancelar;
            this.btnCancelarEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelarEdit.Location = new System.Drawing.Point(349, 26);
            this.btnCancelarEdit.Name = "btnCancelarEdit";
            this.btnCancelarEdit.Size = new System.Drawing.Size(101, 49);
            this.btnCancelarEdit.TabIndex = 9;
            this.btnCancelarEdit.Text = "&Cancelar";
            this.btnCancelarEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarEdit.UseVisualStyleBackColor = false;
            this.btnCancelarEdit.Click += new System.EventHandler(this.btnCancelarEdit_Click);
            // 
            // btnGuardarEdit
            // 
            this.btnGuardarEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardarEdit.Image = global::CapaPresentacion.Properties.Resources.guardar1;
            this.btnGuardarEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarEdit.Location = new System.Drawing.Point(252, 26);
            this.btnGuardarEdit.Name = "btnGuardarEdit";
            this.btnGuardarEdit.Size = new System.Drawing.Size(97, 49);
            this.btnGuardarEdit.TabIndex = 12;
            this.btnGuardarEdit.Text = "&Guardar";
            this.btnGuardarEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarEdit.UseVisualStyleBackColor = false;
            this.btnGuardarEdit.Click += new System.EventHandler(this.btnGuardarEdit_Click);
            // 
            // txtNombreEdit
            // 
            this.txtNombreEdit.Location = new System.Drawing.Point(86, 36);
            this.txtNombreEdit.Name = "txtNombreEdit";
            this.txtNombreEdit.Size = new System.Drawing.Size(160, 31);
            this.txtNombreEdit.TabIndex = 1;
            this.txtNombreEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEdit_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.guardar1;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(252, 26);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 49);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(86, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 31);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // btnNuevaMesa
            // 
            this.btnNuevaMesa.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNuevaMesa.Enabled = false;
            this.btnNuevaMesa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaMesa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNuevaMesa.Image = global::CapaPresentacion.Properties.Resources.nuevo3;
            this.btnNuevaMesa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevaMesa.Location = new System.Drawing.Point(6, 50);
            this.btnNuevaMesa.Name = "btnNuevaMesa";
            this.btnNuevaMesa.Size = new System.Drawing.Size(108, 72);
            this.btnNuevaMesa.TabIndex = 0;
            this.btnNuevaMesa.Text = "Nueva Mesa";
            this.btnNuevaMesa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevaMesa.UseVisualStyleBackColor = false;
            this.btnNuevaMesa.Click += new System.EventHandler(this.btnNuevaMesa_Click);
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "MESAS";
            // 
            // frmMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1233, 753);
            this.Controls.Add(this.gbMesa);
            this.Controls.Add(this.lblIdSalon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbSalon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMesa";
            this.Text = "Mesas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMesa_FormClosed);
            this.Load += new System.EventHandler(this.frmMesa_Load);
            this.gbMesa.ResumeLayout(false);
            this.gbMesa.PerformLayout();
            this.gbNuevaMesa.ResumeLayout(false);
            this.gbNuevaMesa.PerformLayout();
            this.gbEditarMesa.ResumeLayout(false);
            this.gbEditarMesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSalon;
        private System.Windows.Forms.Label lblIdSalon;
        private System.Windows.Forms.GroupBox gbMesa;
        private System.Windows.Forms.Button btnNuevaMesa;
        private System.Windows.Forms.GroupBox gbNuevaMesa;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label lblIdMesa;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbEditarMesa;
        private System.Windows.Forms.Button btnCancelarEdit;
        private System.Windows.Forms.Button btnGuardarEdit;
        private System.Windows.Forms.TextBox txtNombreEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNroMesas;
        private System.Windows.Forms.Label lblPrueba;
    }
}