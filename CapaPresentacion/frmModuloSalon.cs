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
using System.Threading;

namespace CapaPresentacion
{
    public partial class frmModuloSalon : Form
    {
        Button[] btnSalon;
        Button[] btnMesa;
        DataTable dtSalon, dtMesa;
        int nroSalon, nroMesa;
        public static frmModuloSalon f3;

        public frmModuloSalon()
        {
            InitializeComponent();
            frmModuloSalon.f3 = this;
        }



        public void Limpiar()
        {
            this.lblIdMesa.Text = string.Empty;
            this.lblIdSalon.Text = string.Empty;
            this.lblNombreSalon.Text = string.Empty;
            this.lblNroMesas.Text = string.Empty;
            this.lblPrimerID.Text = string.Empty;
            this.lblPrueba.Text = string.Empty;
        }

        public void mostrarSalones()
        {
            Limpiar();
            dtSalon = NSalon.Mostrar();
            nroSalon = dtSalon.Rows.Count;
            int y = 40;
            int x = 10;
            btnSalon = new Button[nroSalon];

            for (int i = 0; i < nroSalon; i++)
            {
                DataRow row = dtSalon.Rows[i];
                if (i == 0)
                {
                    this.lblPrimerID.Text = String.Concat(row[0].ToString());
                    this.lblIdSalon.Text = String.Concat(row[0].ToString());
                    this.gbMesas.Text = string.Concat("MESAS  ", row[1].ToString());
                    this.lblNombreSalon.Text = row[1].ToString();
                    this.mostrarMesas(this.lblPrimerID.Text);
                }
                btnSalon[i] = new Button();
                btnSalon[i].Location = new Point(x, y);
                btnSalon[i].Name = string.Concat("btnSalon", i.ToString());
                btnSalon[i].Font = new Font("Roboto", 8);
                btnSalon[i].Size = new Size(120, 70);
                btnSalon[i].TabIndex = i;
                btnSalon[i].Text = row[1].ToString();
                btnSalon[i].BackColor = Color.White;

                btnSalon[i].Visible = true;
                btnSalon[i].Tag = i;
                gbSalon.Controls.Add(btnSalon[i]);
                btnSalon[i].Click += new EventHandler((sender, e) =>
                {
                    this.lblIdSalon.Text = String.Concat(row[0].ToString());

                    this.limpiarMesas();
                    this.mostrarMesas(this.lblIdSalon.Text);
                    this.gbMesas.Text = string.Concat("MESAS ", row[1].ToString());
                    this.lblIdMesa.Text = string.Empty;
                    this.lblNombreSalon.Text = row[1].ToString();
                });
                //this.Controls.Add(this.btnSalon[i]);
                y += 80;
            }

        }

        public void mostrarMesas(string idSalon)
        {
            if(idSalon != "")
            {

                this.lblNroMesas.Text = "0";
                dtMesa = NMesa.Mostrar(Convert.ToInt32(idSalon));
                nroMesa = dtMesa.Rows.Count;

                int y1 = 70;
                int x1 = 6;


                btnMesa = new Button[nroMesa];

                for (int i = 0; i < nroMesa; i++)
                {
                    if (i == 7)
                    {
                        y1 = 150;
                        x1 = 6;
                    }
                    else if (i == 14)
                    {
                        y1 = 230;
                        x1 = 3;
                    }
                    else if (i == 21)
                    {
                        y1 = 310;
                        x1 = 3;
                    }
                    else if (i == 28)
                    {
                        y1 = 390;
                        x1 = 3;
                    }
                    else if (i == 35)
                    {
                        y1 = 470;
                        x1 = 3;
                    }
                    else if (i == 42)
                    {
                        y1 = 550;
                        x1 = 3;
                    }
                    else if (i == 49)
                    {
                        y1 = 630;
                        x1 = 3;
                    }
                    else if (i == 56)
                    {
                        y1 = 710;
                        x1 = 3;
                    }
                    else if (i == 63)
                    {
                        y1 = 890;
                        x1 = 3;
                    }
                    else if (i == 70)
                    {
                        y1 = 970;
                        x1 = 3;
                    }
                    else if (i == 77)
                    {
                        y1 = 1050;
                        x1 = 3;
                    }
                    DataRow row = dtMesa.Rows[i];
                    btnMesa[i] = new Button();
                    btnMesa[i].Location = new Point(x1, y1);
                    btnMesa[i].Name = string.Concat("btnMesa", i.ToString());
                    //String mesa = row[0].ToString();
                    //btnMesa[i].Name = string.Concat("btnMesa",mesa);
                    btnMesa[i].Size = new Size(100, 70);
                    btnMesa[i].Font = new Font("Roboto", 10f, FontStyle.Bold);
                    btnMesa[i].TabIndex = i;
                    btnMesa[i].Text = row[1].ToString();
                    btnMesa[i].Visible = true;
                    if (dtMesa.Rows[i][3].ToString().Equals("Libre"))
                    {
                        btnMesa[i].BackColor = Color.DarkOliveGreen;
                    }
                    else if (dtMesa.Rows[i][3].ToString().Equals("Ocupada"))
                    {
                        btnMesa[i].BackColor = Color.Red;
                    }
                    else if (dtMesa.Rows[i][3].ToString().Equals("Por Salir"))
                    {
                        btnMesa[i].BackColor = Color.Orange;
                    }


                    btnMesa[i].ForeColor = Color.White;
                    btnMesa[i].Tag = i;
                    lblNroMesas.Text = nroMesa.ToString();

                    x1 += 103;

                    gbMesas.Controls.Add(btnMesa[i]);

                    btnMesa[i].Click += new EventHandler((sender, e) =>
                    {
                        //this.btnMesa[2].BackColor = Color.Red;
                        this.lblIdMesa.Text = String.Concat(row[0].ToString());
                        this.lblPrueba.Visible = true;
                        this.lblPrueba.Text = String.Concat("Mesa ", row[1].ToString());

                        if (row[3].ToString().Equals("Ocupada") || row[3].ToString().Equals("Por Salir"))
                        {
                            /*
                            DataTable dtIdVenta;
                            frmVenta form = new frmVenta();
                            dtIdVenta = NMesa.mostrarIdVentaMesa(Convert.ToInt32(this.lblIdMesa.Text));
                            form.lblIdVenta.Text = dtIdVenta.Rows[0][0].ToString();
                            form.lblIdUsuario.Text = this.lblIdUsuario.Text;
                            this.tActualizarEstado.Enabled = false;
                            form.Show();*/
                            this.lblBanderaEstado.Text = "1";
                            //frmMesero form = new frmMesero();
                            frmVenta form = new frmVenta();
                            DataTable dtMesero = NTrabajador.MostrarMesero();
                            DataTable dtIdVenta;
                            dtIdVenta = NMesa.mostrarIdVentaMesa(Convert.ToInt32(lblIdMesa.Text));
                            form.lblBanderaEstado.Text = "1";
                            form.lblIdVenta.Text = dtIdVenta.Rows[0][0].ToString();
                            form.nroMesa = row[1].ToString();
                            form.idMesa = this.lblIdMesa.Text;

                            form.idSalon = this.lblIdSalon.Text;
                            form.nombreSalon = this.lblNombreSalon.Text;
                            form.nombreMesero = this.lblUsuario.Text;
                            form.lblIdUsuario.Text = this.lblIdUsuario.Text;
                            form.lblIdMesa.Text = this.lblIdMesa.Text;
                            form.idMesero = this.lblIdUsuario.Text;
                            this.tEstado.Enabled = false;
                            form.Show();
                        }
                        else
                        {

                            this.lblBanderaEstado.Text = "0";
                            //frmMesero form = new frmMesero();
                           
                            frmVenta form = new frmVenta();
                            form.lblBanderaEstado.Text = "0";

                            form.nroMesa = row[1].ToString();
                            form.idMesa = this.lblIdMesa.Text;
                            form.lblIdMesa.Text = this.lblIdMesa.Text;
                            form.idSalon = this.lblIdSalon.Text;
                            form.nombreSalon = this.lblNombreSalon.Text;
                            form.nombreMesero = this.lblUsuario.Text;
                            form.lblIdUsuario.Text = this.lblIdUsuario.Text;
                            form.idMesero = this.lblIdUsuario.Text;
                            this.tEstado.Enabled = false;
                            form.Show();
                        }
                        // form.lbli =


                    });

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tEstado_Tick(object sender, EventArgs e)
        {
            limpiarMesas();
            mostrarSalones();
        }

        private void frmModuloSalon_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public void limpiarMesas()
        {

            if (lblNroMesas.Text != "" )
            {
                int nro = Convert.ToInt32(lblNroMesas.Text);
                for (int j = 0; j < nro; j++)
                {
                    gbMesas.Controls.Remove(btnMesa[j]);
                }
            }
        }

        private void frmModuloSalon_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.mostrarSalones();
            tEstado.Enabled = true;
        }
    }
}
