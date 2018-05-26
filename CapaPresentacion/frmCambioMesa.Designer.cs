namespace CapaPresentacion
{
    partial class frmCambioMesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioMesa));
            this.gbSalon = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPrueba = new System.Windows.Forms.Label();
            this.lblNombreSalon = new System.Windows.Forms.Label();
            this.lblPrimerID = new System.Windows.Forms.Label();
            this.lblIdMesa = new System.Windows.Forms.Label();
            this.lblNroMesas = new System.Windows.Forms.Label();
            this.lblIdSalon = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.plMesa = new System.Windows.Forms.Panel();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.gbSalon.SuspendLayout();
            this.plMesa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSalon
            // 
            this.gbSalon.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbSalon.Controls.Add(this.button1);
            this.gbSalon.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSalon.Location = new System.Drawing.Point(14, 16);
            this.gbSalon.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbSalon.Name = "gbSalon";
            this.gbSalon.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbSalon.Size = new System.Drawing.Size(132, 594);
            this.gbSalon.TabIndex = 1;
            this.gbSalon.TabStop = false;
            this.gbSalon.Text = "SALONES";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CapaPresentacion.Properties.Resources.salir;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(6, 506);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 77);
            this.button1.TabIndex = 9;
            this.button1.Text = "SALIR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblPrueba
            // 
            this.lblPrueba.AutoSize = true;
            this.lblPrueba.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrueba.ForeColor = System.Drawing.Color.Navy;
            this.lblPrueba.Location = new System.Drawing.Point(922, 450);
            this.lblPrueba.Name = "lblPrueba";
            this.lblPrueba.Size = new System.Drawing.Size(55, 19);
            this.lblPrueba.TabIndex = 8;
            this.lblPrueba.Text = "MESAS";
            this.lblPrueba.Visible = false;
            // 
            // lblNombreSalon
            // 
            this.lblNombreSalon.AutoSize = true;
            this.lblNombreSalon.Location = new System.Drawing.Point(1175, 323);
            this.lblNombreSalon.Name = "lblNombreSalon";
            this.lblNombreSalon.Size = new System.Drawing.Size(17, 20);
            this.lblNombreSalon.TabIndex = 22;
            this.lblNombreSalon.Text = "0";
            // 
            // lblPrimerID
            // 
            this.lblPrimerID.AutoSize = true;
            this.lblPrimerID.Location = new System.Drawing.Point(1593, 670);
            this.lblPrimerID.Name = "lblPrimerID";
            this.lblPrimerID.Size = new System.Drawing.Size(17, 20);
            this.lblPrimerID.TabIndex = 21;
            this.lblPrimerID.Text = "0";
            // 
            // lblIdMesa
            // 
            this.lblIdMesa.AutoSize = true;
            this.lblIdMesa.Location = new System.Drawing.Point(1039, 312);
            this.lblIdMesa.Name = "lblIdMesa";
            this.lblIdMesa.Size = new System.Drawing.Size(17, 20);
            this.lblIdMesa.TabIndex = 20;
            this.lblIdMesa.Text = "0";
            // 
            // lblNroMesas
            // 
            this.lblNroMesas.AutoSize = true;
            this.lblNroMesas.Location = new System.Drawing.Point(1041, 474);
            this.lblNroMesas.Name = "lblNroMesas";
            this.lblNroMesas.Size = new System.Drawing.Size(17, 20);
            this.lblNroMesas.TabIndex = 19;
            this.lblNroMesas.Text = "0";
            // 
            // lblIdSalon
            // 
            this.lblIdSalon.AutoSize = true;
            this.lblIdSalon.Location = new System.Drawing.Point(958, 479);
            this.lblIdSalon.Name = "lblIdSalon";
            this.lblIdSalon.Size = new System.Drawing.Size(17, 20);
            this.lblIdSalon.TabIndex = 18;
            this.lblIdSalon.Text = "0";
            // 
            // btnUp
            // 
            this.btnUp.Image = global::CapaPresentacion.Properties.Resources.up31;
            this.btnUp.Location = new System.Drawing.Point(906, 428);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(53, 60);
            this.btnUp.TabIndex = 48;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::CapaPresentacion.Properties.Resources.down3;
            this.btnDown.Location = new System.Drawing.Point(906, 539);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(53, 60);
            this.btnDown.TabIndex = 49;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // plMesa
            // 
            this.plMesa.Controls.Add(this.lblMesa);
            this.plMesa.Location = new System.Drawing.Point(152, 13);
            this.plMesa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plMesa.Name = "plMesa";
            this.plMesa.Size = new System.Drawing.Size(749, 586);
            this.plMesa.TabIndex = 50;
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(-3, 0);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(61, 20);
            this.lblMesa.TabIndex = 51;
            this.lblMesa.Text = "MESAS";
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(1593, 659);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(17, 20);
            this.lblIdVenta.TabIndex = 51;
            this.lblIdVenta.Text = "0";
            // 
            // frmCambioMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 612);
            this.Controls.Add(this.plMesa);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.gbSalon);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.lblNroMesas);
            this.Controls.Add(this.lblIdSalon);
            this.Controls.Add(this.lblIdMesa);
            this.Controls.Add(this.lblNombreSalon);
            this.Controls.Add(this.lblPrimerID);
            this.Controls.Add(this.lblPrueba);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioMesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: CAMBIAR MESA ::.";
            this.Load += new System.EventHandler(this.frmCambioMesa_Load);
            this.gbSalon.ResumeLayout(false);
            this.plMesa.ResumeLayout(false);
            this.plMesa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSalon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPrueba;
        private System.Windows.Forms.Label lblNombreSalon;
        private System.Windows.Forms.Label lblPrimerID;
        private System.Windows.Forms.Label lblIdMesa;
        private System.Windows.Forms.Label lblNroMesas;
        private System.Windows.Forms.Label lblIdSalon;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel plMesa;
        private System.Windows.Forms.Label lblMesa;
        public System.Windows.Forms.Label lblIdVenta;
    }
}