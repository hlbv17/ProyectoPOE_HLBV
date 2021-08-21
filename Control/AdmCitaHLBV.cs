using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using Model;

namespace Control
{
    public class AdmCitaHLBV
    {
        private ConexionHLBV con = new ConexionHLBV();
        private static AdmCitaHLBV adm = new AdmCitaHLBV();
        DatosCitaHLBV dCita = new DatosCitaHLBV();
        DatosPacienteHLBV dPaciente = new DatosPacienteHLBV();
        DatosOdontologoHLBV dOdontologo = new DatosOdontologoHLBV();

        List<Cita> citas = null;
        Validacion val = null;
        Cita c = null;
        Paciente pa = null;
        Odontologo o = null;

        public Cita C { get => c; set => c = value; }
        public List<Cita> Citas { get => citas; set => citas = value; }
        public Paciente Pa { get => pa; set => pa = value; }
        public Odontologo O { get => o; set => o = value; }

        public int TotalElementos()
        {
            return Citas.Count;
        }

        public AdmCitaHLBV()
        {
            citas = new List<Cita>();
            val = new Validacion();
        }

        public static AdmCitaHLBV GetAdm()
        {
            if (adm == null)
            {
                adm = new AdmCitaHLBV();
            }
            return adm;
        }

        public void Conectar()
        {
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                MessageBox.Show("Conexión exitosa");
            }
            else
            {
                MessageBox.Show("Error: " + mensaje);
            }
            con.Cerrar();
        }

        public void llenarComboH(ComboBox cmbHora)
        {
            cmbHora.Items.Add("--Seleccionar--");
            cmbHora.Items.Add("07:00");
            cmbHora.Items.Add("12:00");
            cmbHora.Items.Add("14:00");
            cmbHora.Items.Add("16:00");
        }


        public bool Validar(TextBox txtCedula, ComboBox cmbHora, ComboBox cmbOdontologo, ErrorProvider errorP)
        {
            bool no_error = true;
            string cedula = txtCedula.Text;
            if (String.IsNullOrEmpty(txtCedula.Text.Trim()))
            {
                errorP.SetError(txtCedula, "Ingrese una cédula");
                no_error = false;
            }
            if (cedula.Length < 10)
            {
                errorP.SetError(txtCedula, "La cédula debe ser de 10 dígitos");
                no_error = false;
            }
            if (String.IsNullOrEmpty(cmbHora.Text))
            {
                errorP.SetError(cmbHora, "Seleccione una hora");
                no_error = false;
            }
            if (String.IsNullOrEmpty(cmbOdontologo.Text))
            {
                errorP.SetError(cmbOdontologo, "Seleccione un odontólogo");
                no_error = false;
            }
            return no_error;
        }

        public void guardar(int id_cita, string cedula, string odonto, DateTime fecha, DateTime hora, string odontologo)
        {   
            //int indice = 0, id = 0;
            Cita c = null;
            Paciente pa = null;
            Odontologo o = null;
            string dia = DayOfWeek(fecha);
            pa = dPaciente.ConsultarPacienteNombre(cedula);
            o = dOdontologo.ConsultarOdontologo(odonto);
            c = new Cita(id_cita, fecha, hora, o, pa);
            citas.Add(c);
            guardarBD(c, pa);
        }

        public void guardarBD(Cita cita, Paciente p)
        {
            string mensaje = "";
            if (p != null)
            {
                mensaje = dCita.insertarCita(cita);
            }
            if (mensaje[0] == '1')
                MessageBox.Show("Ingreso de datos correctamente");
            else
                MessageBox.Show("Error: " + mensaje);
        }

        public void agregar(TextBox txtRegistro)
        {
            txtRegistro.Text += Citas[Citas.Count - 1].ToString() + "\r\n";
        }

        public string DayOfWeek(DateTime? date)
        {
            return date.Value.ToString("dddd", new CultureInfo("Es-Es"));
        }

        public void LlenarTabla(DataGridView dgvCitas)
        {
            Citas = dCita.ListarCitas();
            foreach (Cita c in citas)
            {
                dgvCitas.Rows.Add(c.Id_cita, c.Paciente.Nombre, c.Fecha.ToString("yyyy-MM-dd"), c.Hora.ToString("HH:ss"), c.Odontologo.Nombre, c.Odontologo.Consultorio);
            
            }
        }

        public void FiltrarDatos(DataGridView dgvCitas, string cedula, DateTime fecha, DateTime hora)
        {
            citas = dCita.ConsultarCitas(cedula, fecha, hora);
            foreach (Cita c in citas)
            {
                dgvCitas.Rows.Add(c.Id_cita, c.Paciente.Nombre, c.Fecha.ToString("yyyy-MM-dd"), c.Hora.ToString("HH:mm"), c.Odontologo.Nombre, c.Odontologo.Consultorio);
            }
        }

        public void BuscarDatos(DataGridView dgvCitas, string cedula)
        {
            citas = dCita.ConsultarCitasxCedula(cedula);
            foreach (Cita c in citas)
            {
                dgvCitas.Rows.Add(c.Id_cita, c.Fecha.ToString("yyyy-MM-dd"), c.Hora.ToString("HH:ss"), c.Odontologo.Nombre, c.Odontologo.Consultorio);
            }
        }

        public void ActualizarDatos(DataGridView dgvCitas, DateTimePicker dtpFecha, ComboBox cmbHora, ComboBox cmbOdontologo, Label lblConsultorio)
        {
            int posicion = dgvCitas.CurrentRow.Index, index = 0;                        //obtiene el indice de la fila seleccionada
            int id = Convert.ToInt32(dgvCitas.Rows[posicion].Cells["col_id"].Value);
            if (posicion >= 0)
            {
                foreach (Cita c in citas)
                {
                    if (c.Id_cita.CompareTo(id) == 0)
                    {
                        dtpFecha.Value = c.Fecha;
                        llenarComboH(cmbHora);
                        index = cmbHora.Items.IndexOf(c.Hora.ToString());
                        cmbHora.SelectedIndex = index;
                        index = cmbOdontologo.Items.IndexOf(c.Odontologo.ToString());
                        cmbOdontologo.SelectedIndex = index;
                        lblConsultorio.Text = c.Odontologo.Consultorio.ToString();
                    }

                }
            }
        }

        public void EliminarCita()
        {

        }

        public void BloquearCampos(TextBox txtCedula, DateTimePicker dtpFecha, ComboBox cmbHora, ComboBox cmbOdontologo)
        {
            txtCedula.Enabled = true;
            dtpFecha.Enabled = false;
            cmbHora.Enabled = false;
            cmbOdontologo.Enabled = false;
        }

        public void DesbloquearCampos(TextBox txtCedula, DateTimePicker dtpFecha, ComboBox cmbHora, ComboBox cmbOdontologo)
        {
            txtCedula.Enabled = false;
            dtpFecha.Enabled = true;
            cmbHora.Enabled = true;
            cmbOdontologo.Enabled = true;
        }

        public void LimpiarCampos(TextBox txtCedula, DataGridView dgvCitas, DateTimePicker dtpFecha, ComboBox cmbHora, ComboBox cmbOdontologo)
        {
            BloquearCampos(txtCedula, dtpFecha, cmbHora, cmbOdontologo);
            txtCedula.Clear();
            cmbHora.Text = "";
            cmbOdontologo.Text = "";
            dtpFecha.Value = DateTime.Now;
            dgvCitas.Rows.Clear();
        }

    }
}
