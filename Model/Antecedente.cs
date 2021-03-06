using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentalig_HLBV_ProyectoPOE
{
    public class Antecedente
    {
        // Variables
        private string antecedenteFamiliar;
        private string antecedentePersonal;

        // Constructor: defautl
        public Antecedente()
        {
            this.antecedenteFamiliar = "";
            this.antecedentePersonal = "";
        }

        // Constructor: parameterized
        public Antecedente(string antecedenteFamiliar, string antecedentePersonal)
        {
            this.antecedenteFamiliar = antecedenteFamiliar;
            this.antecedentePersonal = antecedentePersonal;
        }

        public string AntecedenteFamiliar { get => antecedenteFamiliar; set => antecedenteFamiliar = value; }
        public string AntecedentePersonal { get => antecedentePersonal; set => antecedentePersonal = value; }

        // Method: ToString
        public override string ToString()
        {
            return
                "\r\nAntecedente Familiar: " + antecedenteFamiliar +
                "\r\nAntecedente Personal: " + antecedentePersonal;
        }

    }
}
