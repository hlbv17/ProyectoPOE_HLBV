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
            if (char.IsLetter(c) && (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            DateTime fecha = dtpFecha.Value.Date;
            admCita.llenarComboH(cmbHora);
            admCita.BuscarDatos(dgvCitas, cedula);
            admCita.DesbloquearCampos(txtCedula, dtpFecha, cmbHora, cmbOdontologo);
           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            admCita.LimpiarCampos(txtCedula, dgvCitas, dtpFecha, cmbHora, cmbOdontologo);
            //admCita.BloquearCampos(dgvCitas, txtCedula, dtpFecha, cmbHora, cmbOdontologo);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text, hora = cmbHora.Text, odontologo = cmbOdontologo.Text;
            DateTime fecha = dtpFecha.Value.Date;
            DateTime dHora = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
            errorP.Clear();
            if (admCita.Validar(txtCedula, cmbHora, cmbOdontologo, errorP))
            {
                errorP.Clear();
                admCita.Editar(1, cedula, odontologo, fecha, dHora);
            }
        }

        private void dgvCitas_CurrentCellChanged(object sender, EventArgs e)
        {
            /*int posicion = dgvCitas.CurrentRow.Index;
            int id = Convert.ToInt32(dgvCitas.Rows[posicion].Cells["col_id"].Value);
            admCita.ActualizarDatos(dgvCitas, posicion, id, lblPaciente, dtpFecha, cmbHora, cmbOdontologo, lblConsultorio);*/
        }

        private void cmbOdontologo_SelectedValueChanged(object sender, EventArgs e)
        {
            string odontologo = (string)cmbOdontologo.SelectedItem;
            admO.LabelConsultorio(odontologo, cmbOdontologo, lblConsultorio);
        }

        private void cmbHora_SelectedValueChanged(object sender, EventArgs e)
        {
            string hora = cmbHora.Text;
            DateTime fecha = dtpFecha.Value.Date;
            DateTime dHora = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
            //cmbOdontologo.Items.Clear();
            admO.llenarComboO(fecha, dHora, cmbHora, cmbOdontologo);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int posicion = dgvCitas.CurrentRow.Index;
            int id = Convert.ToInt32(dgvCitas.Rows[posicion].Cells["col_id"].Value);
            admCita.ActualizarDatos(dgvCitas, posicion, id, lblPaciente, dtpFecha, cmbHora, cmbOdontologo, lblConsultorio);
        }
    }
}
