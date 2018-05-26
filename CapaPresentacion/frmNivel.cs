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
    public partial class frmNivel : Form
    {
        public frmNivel()
        {
            InitializeComponent();
        }
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private DataTable dtDetalle;

        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idNivel", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("idModulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Modulo", System.Type.GetType("System.String"));

            this.dataListadoDetalle.DataSource = this.dtDetalle;
            this.formatoTabla();
   
        }


        private void formatoTabla()
        {

            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[0].Visible = false;
            this.dataListadoDetalle.Columns[1].Visible = false;

            this.dataListadoDetalle.Columns[2].Width = 580;

            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnEliminar.Enabled = false;
               
            }
            else
            {
                
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnEliminar.Enabled = false;
             
            }
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[2].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 578;

           
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;
            this.dataListado.ClearSelection();
        }

        private void ocultarColumnasNivel()
        {
            this.dataListadoDetalle.Columns[0].Visible = false;
            this.dataListadoDetalle.Columns[1].Visible = false;
            this.dataListadoDetalle.Columns[2].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[3].Width = 578;

            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;

        }
        private void mostrarTipoTrabajador()
        {
            this.dataListado.DataSource = NTipoTrabajador.Mostrar();

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();
            }
        }

        private void mostrarNivel()
        {
            this.dtDetalle = NNivel.Mostrar(Convert.ToInt32(this.lblBandera.Text));
              
           this.dataListadoDetalle.DataSource = dtDetalle;
            this.ocultarColumnasNivel();
            this.lblNroFilas.Text = dataListadoDetalle.Rows.Count.ToString();
        }


        private void cargarModulo()
        {
            cbModulo.DataSource = NModulo.Mostrar();
            cbModulo.ValueMember = "idModulo";
            cbModulo.DisplayMember = "nomModulo";
            cbModulo.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }


        private void frmNivel_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.mostrarTipoTrabajador();
            this.Botones();
            this.btnNuevo.Focus();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if(this.lblBandera.Text != "0")
            {
                this.IsNuevo = true;
                this.IsEditar = false;
                this.Botones();
                this.tabControl2.SelectedIndex = 1;
                this.cargarModulo();
                this.crearTabla();
                this.mostrarNivel();
                this.btnGuardar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione un tipo de Usuario");
            }

        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            this.lblBandera.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.btnNuevo.Enabled = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dataListado.ClearSelection();
            this.dataListadoDetalle.ClearSelection();
            this.tabControl2.SelectedIndex = 0;
            this.mostrarTipoTrabajador();
             this.IsNuevo = false;
            this.Botones();
            this.cbEliminar.Checked = false;
            dtDetalle.Clear();
            dataListadoDetalle.DataSource = dtDetalle;
            this.lblNroFilas.Text = "0";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.cbModulo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un modulo");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idModulo"]) == Convert.ToInt32(this.cbModulo.SelectedValue.ToString()))
                        {
                            registrar = false;
                            MessageBox.Show("El módulo ya está agregado a la lista");
                        }
                    }

                    if (registrar)
                    {

                        DataRow row = this.dtDetalle.NewRow();
                        row["idModulo"] = Convert.ToInt32(this.cbModulo.SelectedValue.ToString());
                        row["Modulo"] = this.cbModulo.Text;
                        this.dtDetalle.Rows.Add(row);
                        this.btnGuardar.Enabled = true;
                    }

                    this.dataListadoDetalle.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataListadoDetalle.Rows.Count <= 0)
                {
                    MessageBox.Show("No existen filas en la tabla");
                }
                else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                {
                    int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                    int codigo;
                    
                    DataRow row = this.dtDetalle.Rows[indiceFila];

                    string idNivel = row["idNivel"].ToString();
                    if (idNivel == "")
                    {
                        this.dtDetalle.Rows.Remove(row);
                    }

                    int nro = Convert.ToInt32(this.lblNroFilas.Text);
                    if(nro == dataListadoDetalle.Rows.Count)
                    {
                        this.btnGuardar.Enabled = false;
                    }else
                    {
                        this.btnGuardar.Enabled = true;
                    }

                    this.dataListadoDetalle.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay filas para remover");
            }
        }

        private void cbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEliminar.Checked)
            {
                this.dataListadoDetalle.Columns[0].Visible = true;
            }
            else
            {
                this.btnEliminar.Enabled = false;
                this.dataListadoDetalle.Columns[0].Visible = false;
            }
        }

        private void dataListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataListadoDetalle_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoDetalle.Columns["Eliminar"].Index)
            {
                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnNuevo.Enabled = false;
                DataGridViewCheckBoxCell cbEliminar = (DataGridViewCheckBoxCell)dataListadoDetalle.Rows[e.RowIndex].Cells["Eliminar"];
                cbEliminar.Value = !Convert.ToBoolean(cbEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Está seguro de eliminar los registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NNivel.Eliminar(Convert.ToInt32(codigo));
                        }

                    }

                    if (rpta.Equals("OK"))
                    {
                        MessageBox.Show("Se eliminó correctamente el registro");
                        dtDetalle.Clear();
                        dataListadoDetalle.DataSource = dtDetalle;
                        this.tabControl2.SelectedIndex = 0;
                        cbEliminar.Checked = false;
                        this.lblBandera.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show(rpta);
                    }
                    this.mostrarTipoTrabajador();
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListadoDetalle_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void dataListadoDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           if(this.lblBandera.Text == "0")
            {
                MessageBox.Show("Seleccione un tipo de Usuario");
            }else
            {
                if (dataListadoDetalle.Rows.Count > 0)
                {
                    string rpta = "";
                    int nroFila = Convert.ToInt32(this.lblNroFilas.Text);
                    if (this.dataListadoDetalle.Rows.Count > nroFila)
                    {
                        for (int i = nroFila; i < this.dataListadoDetalle.Rows.Count; i++)
                        {
                            rpta = NNivel.Insertar(Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["idModulo"].Value.ToString()), Convert.ToInt32(this.lblBandera.Text));
                        }
                        if (rpta == "OK")
                        {
                            MessageBox.Show("Se agregó correctamente los registros");
                            this.IsNuevo = false;
                            Botones();
                            tabControl2.SelectedIndex = 0;
                            dtDetalle.Clear();
                            dataListadoDetalle.DataSource = dtDetalle;
                            this.cbModulo.SelectedIndex = -1;
                            this.lblBandera.Text = "0";
                        }
                        else
                        {
                            MessageBox.Show(rpta);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.dataListadoDetalle.Rows.Count; i++)
                        {
                            rpta = NNivel.Insertar(Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["idModulo"].Value.ToString()), Convert.ToInt32(this.lblBandera.Text));
                        }
                        if (rpta == "OK")
                        {
                            MessageBox.Show("Se registró correctamente");
                            this.IsNuevo = false;
                            Botones();
                            tabControl2.SelectedIndex = 0;
                            dtDetalle.Clear();
                            dataListadoDetalle.DataSource = dtDetalle;
                        }
                        else
                        {
                            MessageBox.Show(rpta);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Seleccione al menos un elemento");
                }
            }
        }

        private void frmNivel_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }
    }
}
