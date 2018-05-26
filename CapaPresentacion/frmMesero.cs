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
    public partial class frmMesero : Form
    {
        Button[] btnMesero;
        public string nroMesa, idMesa, idSalon, nombreSalon;
        DataTable dtMesero;
        int nroMesero;

        public frmMesero()
        {
            InitializeComponent();
           
        }
        private void mostrarMeseros()
        {
            dtMesero = NTrabajador.MostrarMesero();
            nroMesero = dtMesero.Rows.Count;
            int y = 40;
            int x = 20;
            btnMesero = new Button[nroMesero];

            for (int i = 0; i < nroMesero; i++)
            {
                if (i == 5)
                {
                    y = 40;
                    x = 190;
                }
                else if (i == 10)
                {
                    y = 40;
                    x = 360;
                }
                else if (i == 15)
                {
                    y = 40;
                    x = 530;
                }
                else if (i == 20)
                {
                    y = 40;
                    x = 700;
                }
                else if (i == 25)
                {
                    y = 40;
                    x = 870;
                }
                else if (i == 30)
                {
                    y = 40;
                    x = 1040;
                }
                else if (i == 35)
                {
                    y = 40;
                    x = 1210;
                }

                else if (i == 40)
                {
                    y = 40;
                    x = 1380;
                }

                else if (i == 45)
                {
                    y = 40;
                    x = 1550;
                }
                else if (i == 50)
                {
                    y = 40;
                    x = 1720;
                }


                DataRow row = dtMesero.Rows[i];
                btnMesero[i] = new Button();
                btnMesero[i].Location = new Point(x, y);
                btnMesero[i].Name = string.Concat("Mesero", i.ToString());
                btnMesero[i].Size = new Size(148, 80);
                btnMesero[i].TabIndex = i;
                btnMesero[i].Text = row[1].ToString();
                btnMesero[i].BackColor = Color.FromArgb(240, 240, 240);

                btnMesero[i].Visible = true;
                btnMesero[i].Tag = i;
                btnMesero[i].Click += new EventHandler((sender, e) =>
                {
                    if(lblBandera.Text == "0")
                    {

                        if (this.lblBanderaEstado.Text == "0")
                        {
                            frmVenta form = new frmVenta();
                            form.idMesa = idMesa;
                            form.lblIdMesa.Text = idMesa;
                            form.nroMesa = nroMesa;

                            form.idMesero = row[0].ToString();
                            form.lblIdTrabajador.Text = row[0].ToString();
                            form.nombreMesero = row[1].ToString();

                            form.idSalon = idSalon;
                            form.nombreSalon = nombreSalon;
                            form.lblIdUsuario.Text = row[0].ToString();
                            form.Show();
                            this.Dispose();
                        }
                        else
                        {
                            DataTable dtIdVenta;
                            frmVenta form = new frmVenta();
                            dtIdVenta = NMesa.mostrarIdVentaMesa(Convert.ToInt32(idMesa));
                            form.lblIdVenta.Text = dtIdVenta.Rows[0][0].ToString();
                            form.lblIdUsuario.Text = row[0].ToString();
                            form.idMesero = row[0].ToString();
                            form.nombreMesero = row[1].ToString();
                            form.Show();
                            this.Dispose();
                        }
                    }else
                    {

                        if (this.lblBanderaEstado.Text == "0")
                        {
                            frmDelivery form = new frmDelivery();
                            form.idMesa = idMesa;
                            form.lblIdMesa.Text = idMesa;
                            form.nroMesa = "DELIVERY";

                            form.idMesero = row[0].ToString();
                            form.lblIdTrabajador.Text = row[0].ToString();
                            form.nombreMesero = row[1].ToString();
                            form.lblIdUsuario.Text = this.lblIdUsuario.Text;
                            form.idSalon = idSalon;
                            form.nombreSalon = "DELIVERY";
                           // form.lblIdUsuario.Text = this.lblIdUsuario.Text;
                            form.Show();
                            this.Dispose();
                        }
                        else
                        {
                            DataTable dtIdVenta;
                            frmDelivery form = new frmDelivery();
                            dtIdVenta = NMesa.mostrarIdVentaMesa(Convert.ToInt32(idMesa));
                            form.lblIdVenta.Text = dtIdVenta.Rows[0][0].ToString();
                            form.lblIdUsuario.Text = row[0].ToString();
                            form.nombreMesero = row[1].ToString();
                            form.idMesero = row[0].ToString();
                            form.Show();
                            this.Dispose();
                        }
                    }

              
                });
                //this.Controls.Add(this.btnSalon[i]);
                y += 90;

                gbMeseros.Controls.Add(btnMesero[i]);

            }

        }


        private void frmMesero_Load(object sender, EventArgs e)
        {
            this.mostrarMeseros();
  
        }
    }
}
