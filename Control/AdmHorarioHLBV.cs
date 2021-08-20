using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Control
{
    public class AdmHorarioHLBV
    {
        List<Horario> horarios = new List<Horario>();
        DatosHorarioHLBV datosH = new DatosHorarioHLBV();
        Horario horario = null;


        public List<Horario> Pacientes { get => horarios; set => horarios = value; }
        public Horario Horario { get => horario; set => horario = value; }


        public void ConsultarHorarios()
        {
            horario = datosH.ConsultarHorario();
            horarios.Add(horario);
        }
    }
}
