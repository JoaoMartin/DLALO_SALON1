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
    public partial class frmRMovimientoAlmacen : Form
    {
        public frmRMovimientoAlmacen()
        {
            InitializeComponent();
        }

        private void frmRMovimientoAlmacen_Load(object sender, EventArgs e)
        {
            try
            {
                string fechaInicio = frmMostrarMovimientoAlmacen.f1.dtpFechaInicio.Value.ToString("yyyy-MM-dd");
                string fechaFin = frmMostrarMovimientoAlmacen.f1.dtpFechaFin.Value.ToString("yyyy-MM-dd");

                ReportDocument repdoc = new ReportDocument();
                //repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SisVentas_ResAlm\CapaPresentacion\Reportes/RMovAlmacen.rpt");
                repdoc.Load(@"D:\Reportes\RMovAlmacen.rpt");
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
                /*
                crConnectionInfo.ServerName = @"EQUIPO\SQLEXPRESS";
                crConnectionInfo.DatabaseName = "db_restauranteAlmacen";
                crConnectionInfo.UserID = "martin";
                crConnectionInfo.Password = "1234";*/
                crConnectionInfo.ServerName = @"EQUIPO\SQLEXPRESS";
                crConnectionInfo.DatabaseName = "SISVENTAS_CA";
                crConnectionInfo.UserID = "admin";
                crConnectionInfo.Password = "1234";
                CrTables = repdoc.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                cvMovAlmacen.ReportSource = repdoc;
                cvMovAlmacen.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
        }
    }
}
