using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    public class AdmOdontologoHLBV
    {
        List<Odontologo> odontologos = new List <Odontologo>();
        private static AdmOdontologoHLBV admO = new AdmOdontologoHLBV();
        DatosOdontologoHLBV datosOdonto = new DatosOdontologoHLBV();
        Odontologo odontologo = null;

        Validacion val = null;

        public List<Odontologo> Odontologos { get => odontologos; set => odontologos = value; }
        public Odontologo Odontologo { get => odontologo; set => odontologo = value; }

        public AdmOdontologoHLBV()
        {
            odontologos = new List<Odontologo>();
            val = new Validacion();
        }

        public static AdmOdontologoHLBV GetAdm()
        {
            if (admO == null)
            {
                admO = new AdmOdontologoHLBV();
            }
            return admO;
        }

        public void ConsultarOdontologos(DateTime fecha, DateTime hora, ComboBox cmbHora, ComboBox cmbOdontologo)
        {
            //string nombre = "";
            string dia = DayOfWeek(fecha);
            if (cmbHora.Text != "--Seleccionar--")
            {
                odontologos = datosOdonto.ConsultarOdontologos(dia, hora);
                foreach(Odontologo x in odontologos)
                {
                    cmbOdontologo.Items.Add(x.Nombre);
                }
            }

            if (odontologos == null)
            {
                MessageBox.Show("No existe un odontologo disponible");
            }
        }

        /*public void IndiceOdontologo()
        {

        }*/

        public string DayOfWeek(DateTime? date)
        {
            return date.Value.ToString("dddd", new CultureInfo("Es-Es"));
        }

        public void llenarComboO(DateTime fecha, DateTime hora, ComboBox cmbHora, ComboBox cmbOdontologo)
        {
            ConsultarOdontologos(fecha, hora, cmbHora, cmbOdontologo);
        }

        public void LabelConsultorio(string nombre, ComboBox cmbOdontologo, Label lblConsultorio)
        {
            int indice = 0, label = 0;
            indice = odontologos.FindIndex(x => x.Nombre == nombre);
            label = odontologos[indice].Consultorio;
            lblConsultorio.Text = label.ToString();
        }
    }
}
