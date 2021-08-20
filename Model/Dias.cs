using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Dias {

        private int id_dias;
        private string dia;
        private DateTime horaEntrada;
        private DateTime horaSalida;

        public Dias () {
            this.id_dias = 1;
            this.dia = "";
            this.horaEntrada = DateTime.Now;
            this.horaSalida = DateTime.Now;
        }

        public Dias (int id_dias, string dia, DateTime horaEntrada, DateTime horaSalida) {
            this.id_dias = id_dias;
            this.dia = dia;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
        }

        public string Dia { get => dia; set => dia = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }
        public int Id_dias { get => id_dias; set => id_dias = value; }

        public override string ToString () {
            return
                "\r\nDia: " + dia +
                "\r\nHora de Entrada:" + horaEntrada +
                "\r\nHora de Salida: " + horaSalida;
        }

    }
}
