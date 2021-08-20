using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Control
{
    class AdmDiasHLBV
    {
        List<Dias> dias = new List<Dias>();
        DatosDiasHLBV datosD = new DatosDiasHLBV();
        Dias dia = null;


        public List<Dias> Pacientes { get => dias; set => dias = value; }
        public Dias Dia { get => dia; set => dia = value; }


        public void ConsultarDias()
        {
            dia = datosD.ConsultarDia();
            dias.Add(dia);
        }
    }
}
