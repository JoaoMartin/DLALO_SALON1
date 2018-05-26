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
    public partial class frmRVentaCaja : Form
    {
        public frmRVentaCaja()
        {
            InitializeComponent();
        }

        private void frmRVentaCaja_Load(object sender, EventArgs e)
        {
            try
            {
                string fechaInicio = frmMostrarVentas.f1.dtpFechaInicio.Value.ToString("yyyy-MM-dd");
                string fechaFin = frmMostrarVentas.f1.dtpFechaFin.Value.ToString("yyyy-MM-dd");
               // int idTrabajador = Convert.ToInt32(frmMostrarVentas.f1.lblBarra.Text);

                ReportDocument repdoc = new ReportDocument();
                repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SISTEMAUCHPA_Barra1\CapaPresentacion\Reportes/RVentaCaja.rpt");
               // repdoc.Load(@"E:\Reportes\RVentasTrabajador.rpt");

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
