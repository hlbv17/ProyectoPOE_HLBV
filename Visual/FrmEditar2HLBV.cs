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
    public partial class FrmEditar2HLBV : Form
    {
        AdmOdontologoHLBV admO = AdmOdontologoHLBV.GetAdm();
        AdmCitaHLBV admCita = AdmCitaHLBV.GetAdm();
        public FrmEditar2HLBV(DataGridView dgvCitas)
        {
            InitializeComponent();
            txtCedula.Enabled = false;
            int posicion = dgvCitas.CurrentRow.Index;
            string cedula = Convert.ToString(dgvCitas.Rows[posicion].Cells["col_cedula"].Value),
                day = Convert.ToString(dgvCitas.Rows[posicion].Cells["col_fecha"].Value),
                hour = Convert.ToString(dgvCitas.Rows[posicion].Cells["col_hora"].Value);
            admCita.ActualizarDatos(posicion, cedula, day, hour, txtCedula, lblPaciente, dtpFecha, cmbHora, cmbOdontologo, lblConsultorio);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmFiltrarCitasHLBV frmF = new FrmFiltrarCitasHLBV();
            frmF.Visible = true;
            this.Close();
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
                admCita.Editar(cedula, odontologo, fecha, dHora, txtRegistro);
            }
            
        }

        private void cmbHora_SelectedValueChanged(object sender, EventArgs e)
        {
            string hora = cmbHora.Text;
            DateTime fecha = dtpFecha.Value.Date;
            DateTime dHora = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
            cmbOdontologo.Items.Clear();
            admO.llenarComboO(fecha, dHora, cmbHora, cmbOdontologo);
        }

        private void cmbOdontologo_SelectedValueChanged(object sender, EventArgs e)
        {
            string odontologo = (string)cmbOdontologo.SelectedItem;
            admO.LabelConsultorio(odontologo, cmbOdontologo, lblConsultorio);
        }
    }
}
