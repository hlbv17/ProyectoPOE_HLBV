using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual
{
    public partial class FrmReporteCitaHLBV : Form
    {  
        //ReporteCitasHLBV reporte = new ReporteCitasHLBV();
        public FrmReporteCitaHLBV(string cedula, DateTime fecha, string hora, int n)
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ReporteCitasHLBV reporte = new ReporteCitasHLBV();
            ds = reporte.Buscar(cedula, fecha, hora, n);
            //rptCitas.SetDataSource(ds.Tables[0]);     //nombre de la herramienta de Crystal q arrastre
        }
    }
}
