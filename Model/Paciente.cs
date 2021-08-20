using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Paciente : Persona {

        //private int id_paciente;
        private string discapacidad;
        //private int  id_etapa_edad;
        public Paciente() : base ( 1,"",' ', "", DateTime.Now)
        {
            //this.id_paciente = 1;
            this.discapacidad = "";
        }

        public Paciente(int id_persona, string cedula, char sexo, string nombre, DateTime fechaNacimiento/*,
            int id_paciente*/, string discapacidad) : 
            base(id_persona, cedula, sexo, nombre, fechaNacimiento)
        {
            //this.id_paciente = id_paciente;
            this.discapacidad = discapacidad;
        }

        public string Discapacidad { get => discapacidad; set => discapacidad = value; }
        //public int Id_etapa_edad { get => id_etapa_edad; set => id_etapa_edad = value; }

        //public int Id_paciente { get => id_paciente; set => id_paciente = value; }

        public string CategoriaEdad()
        {
            string categoria_edad = "";
            int edad = base.LeerEdad();

            if (edad >= 0 && edad <= 1)
            {
                categoria_edad = "bebé";
            }
            else if (edad > 1 && edad <= 12)
            {
                categoria_edad = "niño";
            }
            else if (edad > 12 && edad <= 18)
            {
                categoria_edad = "adolescente";
            }
            else if (edad > 18 && edad <= 25)
            {
                categoria_edad = "adulto joven";
            }
            else if (edad > 25 && edad <= 65)
            {
                categoria_edad = "adulto";
            }
            else if (edad > 65 && edad <= 80)
            {
                categoria_edad = "adulto mayor";
            }
            else if (edad > 80 && edad <= 130)
            {
                categoria_edad = "anciano";
            }
            return categoria_edad;
        }

        // Method: ToString
        public override string ToString () {
            return base.ToString () + 
                "\r\nDiscapacidad: " + discapacidad;
        }
    }
}
