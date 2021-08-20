using Control;
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
    public partial class FrmMenuHLBV : Form
    {
        AdmCitaHLBV adm = AdmCitaHLBV.GetAdm();
        public FrmMenuHLBV()
        {
            InitializeComponent();
        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adm.Conectar();
        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmRegistrarCitaHLBV frmR = new FrmRegistrarCitaHLBV();
            frmR.ShowDialog();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarCitasHLBV frmL = new FrmListarCitasHLBV();
            frmL.ShowDialog();
        }
    }
}
