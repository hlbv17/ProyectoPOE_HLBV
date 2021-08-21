using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Odontologo : Persona {

        //private int id_odontologo;
        private int especialidad;
        private Horario horario;
        private int consultorio;

        public Odontologo() : base(1, "", ' ', "", DateTime.Now)
        {
            //this.id_odontologo = 1;
            this.especialidad = 1;
            this.horario = new Horario();
            this.consultorio = 1;
        }

        public Odontologo (int id_persona, string cedula, char sexo, string nombre, DateTime fechaNacimiento, 
            /*int id_odontologo,*/int especialidad, Horario horario, int consultorio) : 
            base(id_persona, cedula, sexo, nombre, fechaNacimiento)
        {
            //this.id_odontologo = id_odontologo;
            this.especialidad = especialidad;
            this.horario = horario;
            this.consultorio = consultorio;
        }

        public int Especialidad { get => especialidad; set => especialidad = value; }
        public int Consultorio { get => consultorio; set => consultorio = value; }

        //public int Id_odontologo { get => id_odontologo; set => id_odontologo = value; }

        public Horario Horario { get => horario; set => horario = value; }

        public override string ToString () {
            return
                "\r\nDatos personales: " + base.ToString() +
                "\r\nEspecialidad: " + especialidad +
                /*"\r\nHorario: " + horario.Nombre_horario +*/
                "\r\nConsultorio: " + consultorio;
        }

    }
}
