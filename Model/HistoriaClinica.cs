using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentalig_HLBV_ProyectoPOE
{
    public class HistoriaClinica
    {
        // Variables
        private Paciente paciente;
        private Antecedente antecedente;
        private List<AtencionMedica> atencionMedica;

        // Constructor: defautl
        public HistoriaClinica()
        {
            this.paciente = null;
            this.antecedente = null;
            this.atencionMedica = null;
        }

        // Constructor: parameterized
        public HistoriaClinica(Paciente paciente, Antecedente antecedente, List<AtencionMedica> atencionMedica)
        {
            this.paciente = paciente;
            this.antecedente = antecedente;
            this.atencionMedica = atencionMedica;
        }

        public Paciente Paciente { get => paciente; set => paciente = value; }
        public List<AtencionMedica> AtencionMedica { get => atencionMedica; set => atencionMedica = value; }
        public Antecedente Antecedente { get => antecedente; set => antecedente = value; }

        // Method: ToString
        public override string ToString()
        {
            return
                "\r\nPaciente: " + paciente.Nombre +
                "\r\nAntecedente Familiar: " + antecedente.AntecedenteFamiliar +
                "\r\nAntecedente Personal: " + antecedente.AntecedentePersonal +
                "\r\nAtención Médica: " + atencionMedica;
        }

    }
}
