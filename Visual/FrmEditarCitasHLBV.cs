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
    public partial class FrmEditarCitasHLBV : Form
    {
        AdmPacienteHLBV admPa = new AdmPacienteHLBV();
        AdmOdontologoHLBV admO = AdmOdontologoHLBV.GetAdm();
        AdmCitaHLBV admCita = AdmCitaHLBV.GetAdm();
        public FrmEditarCitasHLBV()
        {
            InitializeComponent();
            admCita.BloquearCampos(txtCedula, dtpFecha, cmbHora, cmbOdontologo);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtCedula.Text.Length >= 10)
                    admPa.ConsultarPacientes(txtCedula.Text, lblPaciente);
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            DateTime fecha = dtpFecha.Value.Date;
            admCita.BuscarDatos(dgvCitas, cedula);
            admCita.DesbloquearCampos(txtCedula, dtpFecha, cmbHora, cmbOdontologo);
            admCita.ActualizarDatos(dgvCitas, dtpFecha, cmbHora, cmbOdontologo, lblConsultorio);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            admCita.LimpiarCampos(txtCedula, dgvCitas, dtpFecha, cmbHora, cmbOdontologo);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
