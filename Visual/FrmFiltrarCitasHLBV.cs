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
    public partial class FrmFiltrarCitasHLBV : Form
    {
        AdmCitaHLBV admC = AdmCitaHLBV.GetAdm();
        public FrmFiltrarCitasHLBV()
        {
            InitializeComponent();
            admC.llenarComboH(cmbHora);
            cmbHora.SelectedIndex = 0;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text, hora = cmbHora.Text;
            DateTime fecha = dtpFecha.Value.Date;
            admC.FiltrarDatos(dgvCitas, cedula, fecha, hora);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            admC.LlenarTabla(dgvCitas);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            admC.LimpiarCampos(txtCedula, dgvCitas, dtpFecha, cmbHora);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int posicion = dgvCitas.Rows.Count;
            if (posicion != 1)
            {
                FrmEditar2HLBV frmE = new FrmEditar2HLBV(dgvCitas);
                frmE.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("No ha realizado la consulta");
            }   
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int posicion = dgvCitas.CurrentRow.Index;
            if (posicion >= 0)
            {
                admC.EliminarCita(dgvCitas, posicion);
            }
            else
            {
                MessageBox.Show("No ha realizado la consulta");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenuHLBV frmM = new FrmMenuHLBV();
            frmM.Visible = true;
            this.Visible = false;
        }
    }
}
