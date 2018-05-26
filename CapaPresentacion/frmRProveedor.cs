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
    public partial class frmRProveedor : Form
    {
        public frmRProveedor()
        {
            InitializeComponent();
        }

        private void frmRProveedor_Load(object sender, EventArgs e)
        {
            try
            {

                ReportDocument repdoc = new ReportDocument();

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;


                //D:/credicon/jmsacrcc/jmsacrcc/Mostrar_Cuotas.rpt
                //D:/credcon/Imp_Cuotas.rpt
                //repdoc.Load(@"D:/credcon/Imp_Cuotas.rpt");
                //repdoc.Load(@"D:/credcon/Imp_Cuotas.rpt");
                //repdoc.Load(@"D:/credicon/jmsacrcc/jmsacrcc/Reportes/Imprimir_Cuotas.rpt");
                //repdoc.Load(@"D:/credicon/jmsacrcc/jmsacrcc/Imp_Cuotas.rpt");
                //repdoc.Load(@"D:/credicon/jmsacrcc/jmsacrcc/Reportes/Imprimir_Cuotas.rpt");
                //repdoc.Load(@"D:/Reportes/RCliente.rpt");
                repdoc.Load(@"D:\Reportes\RProveedor.rpt");

                crConnectionInfo.ServerName = @"EQUIPO\SQLEXPRESS";
                crConnectionInfo.DatabaseName = "SISVENTAS_CA";
                crConnectionInfo.UserID = "admin";
                crConnectionInfo.Password = "1234";
                /*
                repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SisVentas_ResAlm\CapaPresentacion\Reportes/RProveedor.rpt");

                crConnectionInfo.ServerName = @"EQUIPO\SQLEXPRESS";
                crConnectionInfo.DatabaseName = "db_restauranteAlmacen";
                crConnectionInfo.UserID = "martin";
                crConnectionInfo.Password = "1234";
                */
                CrTables = repdoc.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }


                cvProveedor.ReportSource = repdoc;
                cvProveedor.Refresh();

            }

            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
