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
            int id = Convert.ToInt32(dgvCitas.Rows[posicion].Cells["col_id"].Value);
            admCita.ActualizarDatos(posicion, id, txtCedula, lblPaciente, dtpFecha, cmbHora, 
                cmbOdontologo, lblConsultorio);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmFiltrarCitasHLBV frmF = new FrmFiltrarCitasHLBV();
            frmF = new FrmFiltrarCitasHLBV();
            frmF.Visible = true;
            this.Visible = false;
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
                admCita.agregar(txtRegistro);
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
