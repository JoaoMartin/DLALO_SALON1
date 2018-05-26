using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmMesa : Form
    {
        Button[] btnSalon;
        Button[] btnMesa;
        DataTable dtSalon, dtMesa;
        int nroSalon, nroMesa;

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.lblIdMesa.Text = string.Empty;
            this.lblPrueba.Text = string.Empty;
            //this.lblIdSalon.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.btnNuevaMesa.Enabled = !valor;
            this.gbNuevaMesa.Visible = valor;
            this.gbEditarMesa.Visible = valor;
        }

        private void habilitarBotones(bool valor)
        {
            this.btnEditar.Enabled = valor;
            this.btnEliminar.Enabled = valor;
            this.btnCancel.Enabled = valor;
            this.btnCancel.Enabled = valor;
            
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la mesa");
                }
                else
                {
                    rpta = NMesa.Insertar(this.txtNombre.Text.Trim().ToUpper(), "Libre", Convert.ToInt32(this.lblIdSalon.Text), "A");
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se insertó correcatamente");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                }

                gbNuevaMesa.Visible = false;
                this.Limpiar();
                //this.limpiarBotones();
                this.mostrarMesas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Editar()
        {
            try
            {
                string rpta = "";
                if (this.txtNombreEdit.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese la mesa");
                }
                else
                {
                    rpta = NMesa.Editar(Convert.ToInt32(this.lblIdMesa.Text), this.txtNombreEdit.Text.Trim().ToUpper(), "Libre", Convert.ToInt32(this.lblIdSalon.Text), "A");
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se actualizó correcatamente");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                }

                gbNuevaMesa.Visible = false;
                gbEditarMesa.Visible = false;
                this.Habilitar(false);
                this.limpiarMesas();
                this.mostrarMesas();
                this.Limpiar();
                this.habilitarBotones(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public frmMesa()
        {
            InitializeComponent();
        }

        private void mostrarSalones()
        {
            dtSalon = NSalon.Mostrar();
            nroSalon = dtSalon.Rows.Count;
            int y = 40;
            int x = 4;
            btnSalon = new Button[nroSalon];

            for (int i = 0; i < nroSalon; i++)
            {
                DataRow row = dtSalon.Rows[i];
                btnSalon[i] = new Button();
                btnSalon[i].Location = new Point(x, y);
                btnSalon[i].Name = string.Concat("btnSalon", i.ToString());
                btnSalon[i].Size = new Size(130, 80);
                btnSalon[i].TabIndex = i;
                btnSalon[i].Text = row[1].ToString();
                btnSalon[i].BackColor = Color.White;

                btnSalon[i].Visible = true;
                btnSalon[i].Tag = i;
                btnSalon[i].Click += new EventHandler((sender, e) =>
                {
                    this.lblIdSalon.Text = String.Concat(row[0].ToString());
                    this.Habilitar(false);
                    this.habilitarBotones(false);
                    this.limpiarMesas();
                    this.mostrarMesas();
                    this.gbMesa.Text = string.Concat("MESAS DEL ", row[1].ToString());
                    this.Limpiar();
                });
                //this.Controls.Add(this.btnSalon[i]);
                y += 90;

                gbSalon.Controls.Add(btnSalon[i]);

            }

        }

        private void mostrarMesas()
        {
            this.lblNroMesas.Text = "0";
            dtMesa = NMesa.Mostrar(Convert.ToInt32(lblIdSalon.Text));
            nroMesa = dtMesa.Rows.Count;
 
            int y1 = 170;
            int x1 = 3;
   

            btnMesa = new Button[nroMesa];

            for (int i = 0; i < nroMesa; i++)
            {
                if (i == 7)
                {
                    y1 = 270;
                    x1 = 3;
                }else if(i == 14)
                {
                    y1 = 370;
                    x1 = 3;
                }else if (i == 21)
                {
                    y1 = 470;
                    x1 = 3;
                }
                else if(i == 28)
                {
                    y1 = 570;
                    x1 = 3;
                }
                else if (i == 35)
                {
                    y1 = 670;
                    x1 = 3;
                }
                else if (i == 42)
                {
                    y1 = 770;
                    x1 = 3;
                }
                else if (i == 49)
                {
                    y1 = 870;
                    x1 = 3;
                }
                else if (i == 56)
                {
                    y1 = 970;
                    x1 = 3;
                }
                DataRow row = dtMesa.Rows[i];
                btnMesa[i] = new Button();
                btnMesa[i].Location = new Point(x1, y1);
                btnMesa[i].Name = string.Concat("btnMesa", i.ToString());
                //String mesa = row[0].ToString();
                //btnMesa[i].Name = string.Concat("btnMesa",mesa);
                btnMesa[i].Size = new Size(135,90);
                btnMesa[i].TabIndex = i;
                btnMesa[i].Text = row[1].ToString();
                btnMesa[i].Visible = true;
                btnMesa[i].BackColor = Color.DarkOliveGreen;
                btnMesa[i].ForeColor = Color.White;
                btnMesa[i].Tag = i;
                lblNroMesas.Text = nroMesa.ToString();

                x1 += 150;

                gbMesa.Controls.Add(btnMesa[i]);

                btnMesa[i].Click += new EventHandler((sender, e) =>
                {
                    //this.btnMesa[2].BackColor = Color.Red;
                    
                    this.lblIdMesa.Text = String.Concat(row[0].ToString());
                    this.lblPrueba.Visible = true;
                    this.lblPrueba.Text = String.Concat("Mesa ", row[1].ToString());
                    this.txtNombreEdit.Text = String.Concat(row[1].ToString());
                    this.habilitarBotones(true);
                    this.gbNuevaMesa.Visible = false;

                });

            }

        }

        private void limpiarMesas()
        {
            
            if(lblNroMesas.Text != "")
            {
                int nro = Convert.ToInt32(lblNroMesas.Text);
                for (int j = 0; j < nro; j++)
                {
                    gbMesa.Controls.Remove(btnMesa[j]);
                }
            }
        }

        private void frmMesa_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            mostrarSalones();
        }

        private void btnNuevaMesa_Click(object sender, EventArgs e)
        {
           
            if (this.lblIdSalon.Text.Equals(""))
            {
                MensajeError("Selecciona un salón");
            }
            else
            {
                this.gbNuevaMesa.Visible = true;
                this.txtNombre.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarMesas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.gbEditarMesa.Visible = true;
            this.gbNuevaMesa.Visible = false;
            this.txtNombreEdit.Focus();
        }

        private void btnCancelarEdit_Click(object sender, EventArgs e)
        {
            gbEditarMesa.Visible = false;
            this.txtNombreEdit.Text = string.Empty;
        }

        private void btnGuardarEdit_Click(object sender, EventArgs e)
        {
            this.Editar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.lblIdMesa.Text != "")
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("Está seguro de eliminar la mesa " + this.txtNombreEdit.Text + "?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (opcion == DialogResult.OK)
                    {
                        string codigo;
                        string rpta = "";
                        if (this.lblIdMesa.Text != "")
                        {
                            codigo = Convert.ToString(this.lblIdMesa.Text);
                            rpta = NMesa.Eliminar(Convert.ToInt32(codigo));
                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se eliminó correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }
                            gbNuevaMesa.Visible = false;
                            gbEditarMesa.Visible = false;
                            this.Limpiar();
                            this.limpiarMesas();
                            this.mostrarMesas();
                            this.habilitarBotones(false);
                            this.lblPrueba.Visible = false;
                            this.lblIdMesa.Text = string.Empty;
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una Mesa");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Guardar();
            }
        }

        private void txtNombreEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Editar();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.gbNuevaMesa.Visible = false;
            this.txtNombre.Text = string.Empty;
        }

        private void frmMesa_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.habilitarBotones(false);
            this.lblPrueba.Visible = false;
            this.gbEditarMesa.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }
    }
}
