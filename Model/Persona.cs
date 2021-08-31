using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public abstract class Persona {

        // Variables
        private int id_persona;
        private string cedula;
        private char sexo;
        private string nombre;
        private DateTime fechaNacimiento;

        public Persona () {
            this.id_persona = 1;
            this.cedula = "";
            this.sexo = ' ';
            this.nombre = "";
            this.fechaNacimiento = DateTime.Now;
        }

        public string Cedula { get => cedula; set => cedula = value; }                              // Getter & Setter: cedula
        public char Sexo { get => sexo; set => sexo = value; }                                      // Getter & Setter: sexo
        public string Nombre { get => nombre; set => nombre = value; }                              // Getter & Setter: nombre
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; } // Getter & Setter: fechaNacimiento
        public int Id_persona { get => id_persona; set => id_persona = value; }


        protected Persona(int id_persona, string cedula, char sexo, string nombre, DateTime fechaNacimiento)
        {
            this.id_persona = id_persona;
            this.cedula = cedula;
            this.sexo = sexo;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
        }

        // Method: LeerEdad
        public int LeerEdad () {
            int output = 0;
            // ¿?
            output = (int)Math.Round ((DateTime.Now.Date - fechaNacimiento.Date).TotalDays, MidpointRounding.AwayFromZero);
            output = output / 365;
            return output;
        }

        // Method: Leersexo
        public string LeerSexo () {
            String output = "";
            if (sexo == 'F') {
                output = "Femenino";
            } else if (sexo == 'M') {
                output = "Masculino";
            }
            return output;
        }
        
        // Method: ToString
        public override string ToString () {
            return
                "\r\nSexo: " + LeerSexo () +
                "\r\nNombre: " + nombre +
                "\r\nFecha de nacimiento: " + fechaNacimiento+
                "\r\nEdad: " + LeerEdad ();
        }

    }
}
