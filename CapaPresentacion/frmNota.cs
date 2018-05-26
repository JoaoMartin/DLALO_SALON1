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
    public partial class frmNota : Form
    {
        Button[] btnTermino;
        DataTable dtTermino;
        int nroTermino;
        private int loc = 0;
        public string posicion;

        private void mostrarTerminos()
        {
            dtTermino = NTermino.Mostrar();
            nroTermino = dtTermino.Rows.Count;
            int y = 0;
            int x = 15;
            btnTermino = new Button[nroTermino];

            for (int i = 0; i < nroTermino; i++)
            {
                if (i == 3)
                {
                    y = 70;
                    x = 15;
                }
                else if (i == 6)
                {
                    y = 140;
                    x = 15;
                }
                else if (i == 9)
                {
                    y = 210;
                    x = 15;
                }
                else if (i == 12)
                {
                    y = 280;
                    x = 15;
                }
                else if (i == 15)
                {
                    y = 350;
                    x = 15;
                }
                else if (i == 18)
                {
                    y = 420;
                    x = 15;
                }
                else if (i == 21)
                {
                    y = 490;
                    x = 15;
                }
                else if (i == 24)
                {
                    y = 560;
                    x = 15;
                }
                else if (i == 27)
                {
                    y = 630;
                    x = 15;
                }
                else if (i == 30)
                {
                    y = 700;
                    x = 15;
                }
                else if (i == 33)
                {
                    y = 770;
                    x = 15;
                }

                DataRow row = dtTermino.Rows[i];

                btnTermino[i] = new Button();
                btnTermino[i].Location = new Point(x, y);
                btnTermino[i].Name = string.Concat("btnTermino", i.ToString());
                btnTermino[i].Size = new Size(120, 60);
                btnTermino[i].TabIndex = i;
                btnTermino[i].Font = new Font("Roboto", 9f, FontStyle.Regular);
                btnTermino[i].Text = row[1].ToString();
                btnTermino[i].BackColor = Color.White;
                btnTermino[i].ForeColor = Color.Black;
                btnTermino[i].FlatAppearance.BorderColor = Color.Black;
                btnTermino[i].FlatAppearance.BorderSize = 4;
                btnTermino[i].Visible = true;
                btnTermino[i].Tag = i;
                btnTermino[i].Click += new EventHandler((sender, e) =>
                {
                    this.TxtNota.Text += row[1].ToString() + " ";
                });
                //this.Controls.Add(this.btnSalon[i]);
                x += 130;

                // gbCategoria.Controls.Add(btnCategoria[i]);
                plTermino.Controls.Add(btnTermino[i]);
            }

        }


        public frmNota()
        {
            InitializeComponent();
            this.plTermino.AutoScrollPosition = new Point(90, 0);
            this.plTermino.VerticalScroll.Maximum = 900;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "/";
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "1";
        }

        private void btnDos2_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += ".";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "Q";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "W";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "E";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "R";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "T";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "Y";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "U";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "I";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "O";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "P";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "A";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "S";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "D";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "F";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "G";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "H";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "J";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "K";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "L";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "Ñ";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "Z";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "X";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "C";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "V";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "B";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "N";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += "M";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += " ";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text += ",";
        }

        private void btnRetroceso_Click(object sender, EventArgs e)
        {
            if (this.TxtNota.Text.Length == 1)
            {
                this.TxtNota.Text = string.Empty;
            }
            else if(this.TxtNota.Text.Length != 0)
            {
                this.TxtNota.Text = this.TxtNota.Text.Substring(0, this.TxtNota.Text.Length - 1);
            }
        }

        private void frmNota_Load(object sender, EventArgs e)
        {
            this.mostrarTerminos();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (loc - 250 > 0)
            {
                loc -= 276;
                plTermino.VerticalScroll.Value = loc;
            }
            else
            {
                loc = 0;
                plTermino.AutoScrollPosition = new Point(0, loc);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (loc + 150 < plTermino.VerticalScroll.Maximum)
            {
                loc += 150;
                plTermino.VerticalScroll.Value = loc;
            }
            else
            {

                loc = plTermino.VerticalScroll.Maximum;
                plTermino.AutoScrollPosition = new Point(0, loc);

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.TxtNota.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Ingrese una nota válida");
                frmVenta.f1.dataListadoDetalle.Select();
            }
            else
            {
                frmVenta.f1.dataListadoDetalle[6, Convert.ToInt32(posicion)].Value = this.TxtNota.Text.Trim();
                frmVenta.f1.lblBandera.Text = "0";
                frmVenta.f1.dataListadoDetalle.ClearSelection();
                frmVenta.f1.lblBanderaNota.Text = "1";
                frmVenta.f1.dataListadoDetalle.Select();
                this.Close();
            }
            frmVenta.f1.dataListadoDetalle.Select();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            this.TxtNota.Text = "";
        }

    
    }
}
