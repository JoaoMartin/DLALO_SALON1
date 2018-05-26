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
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            string idUnidad;
    

            this.txtIdInsumo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Insumo"].Value);
            this.txtCosto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Costo"].Value);
            idUnidad = Convert.ToString(this.dataListado.CurrentRow.Cells["idUnidadMedida"].Value);
            cbUnidad.SelectedValue = idUnidad;
            this.txtStock.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Stock"].Value);
            this.txtStockMinimo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Stock_Minimo"].Value);
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
            this.dataListado.DataSource = NInsumo.Mostrar();
    
            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.dataListado.ClearSelection();
            }
        }
    }
}
