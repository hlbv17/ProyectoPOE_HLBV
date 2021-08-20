using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {

    public class Horario {

        private int id_horario;
        private string nombre_horario;
        //private List<Dias> dias;

        public Horario()
        {
            this.id_horario = 1;
            this.nombre_horario = "";
        }

        public Horario(int id_horario, string nombre_horario)
        {
            this.id_horario = id_horario;
            this.nombre_horario = nombre_horario;
        }

        public int Id_horario { get => id_horario; set => id_horario = value; }
        public string Nombre_horario { get => nombre_horario; set => nombre_horario = value; }
        //internal List<Dias> Dias { get => dias; set => dias = value; }

        public override string ToString () {
            return "\r\nHorario: "+nombre_horario;
        }
    }
}
