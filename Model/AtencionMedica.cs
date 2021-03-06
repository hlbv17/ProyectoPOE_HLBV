using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentalig_HLBV_ProyectoPOE
{
    public class AtencionMedica
    {

        // Variables
        private CitaHLBV cita;
        private PiezaDental piezaDental;
        private string motivoConsulta;
        private string diagnostico;

        public AtencionMedica()
        {
            this.cita = null;
            this.piezaDental = null;
            this.motivoConsulta = "";
            this.diagnostico = "";
        }

        // Constructor: Parameterized
        public AtencionMedica(CitaHLBV cita, PiezaDental piezaDental, string motivoConsulta, string diagnostico)
        {
            this.cita = cita;
            this.piezaDental = piezaDental;
            this.motivoConsulta = motivoConsulta;
            this.diagnostico = diagnostico;
        }

        public string MotivoConsulta { get => motivoConsulta; set => motivoConsulta = value; }  // Getter & Setter: cita
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }           // Getter & Setter: piezaDental
        public CitaHLBV Cita { get => cita; set => cita = value; }                                // Getter & Setter: motivoConsulta
        public PiezaDental PiezaDental { get => piezaDental; set => piezaDental = value; }    // Getter & Setter: diagnostico

        // Method: ToString
        public override string ToString()
        {
            return
                "\r\nCita: " + cita.ToString() +
                "\r\nPieca Dental: " + piezaDental.ToString() +
                "\r\nMotivo de Consulta: " + motivoConsulta +
                "\r\nDiagnostico:" + diagnostico;
        }
    }
}
