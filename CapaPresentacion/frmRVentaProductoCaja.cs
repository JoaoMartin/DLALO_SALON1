using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmRVentaProductoCaja : Form
    {
        public frmRVentaProductoCaja()
        {
            InitializeComponent();
        }

        private void frmRVentaProductoCaja_Load(object sender, EventArgs e)
        {
            try
            {
                string bandera = frmReporteVentaCliente.f1.lblBandera.Text;
                string fechaInicio = "";
                string fechaFin = "";
                DateTime fecIn;
                if (bandera == "1")
                {
                    fechaInicio = frmReporteVentaCliente.f1.dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                    fechaFin = frmReporteVentaCliente.f1.dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
                }
                else
                {
                    fecIn = Convert.ToDateTime(frmPrincipal.f1.lblFechaApertura.Text);
                    fechaInicio = fecIn.ToString("yyyy-MM-dd HH:mm:ss");

                    fechaFin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                int idProducto = Convert.ToInt32(frmReporteVentasProducto.f1.cbProducto.SelectedValue);
                int nroCaja = Convert.ToInt32(frmReporteVentasProducto.f1.lblCaja.Text);

                ReportDocument repdoc = new ReportDocument();
                repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SISTEMAUCHPA_Barra1\CapaPresentacion\Reportes/RVentaProductoCaja.rpt");
                //repdoc.Load(@"E:\Reportes\RVentaProducto.rpt");

                ParameterFieldDefinitions pfds;
                ParameterFieldDefinition pfd;

                ParameterValues pvs = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();

                pdv.Value = Convert.ToDateTime(fechaInicio + " 00:00:00");
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@fechaInicio"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);


                pdv.Value = Convert.ToDateTime(fechaFin + " 23:59:59");
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@fechaFin"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                pdv.Value = idProducto;
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@idProducto"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                pdv.Value = nroCaja;
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@nroCaja"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;
                crConnectionInfo.ServerName = @"UCHPABAR\SQLUCHPA";
                crConnectionInfo.DatabaseName = "db_SISTEMAUCHPA";
                crConnectionInfo.UserID = "sa";
                crConnectionInfo.Password = "adminUCHPA";

                CrTables = repdoc.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }


                cvVentas.ReportSource = repdoc;
                cvVentas.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
        }
    }
}
