using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ReporteCitasHLBV
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        ConexionHLBV con = null;


        private DataSet Consultar(string sentenciaSQL)
        {
            DataSet ds = null; //tabla virtual
            cmd = new SqlCommand();
            string msj = "";
            try
            {
                con = new ConexionHLBV();
                msj = con.Conectar();
                if (msj[0] == '1')
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sentenciaSQL;
                    da = new SqlDataAdapter(cmd.CommandText, cmd.Connection);
                    ds = new DataSet();
                    da.Fill(ds);
                    con.Cerrar();
                }
                else if (msj[0] == '0')
                    con.Cerrar();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return ds;


        }

        public DataSet Buscar(string cedula, DateTime fecha, string hora, int n)
        {
            string sentenciaSQL = "";

            string sql = "SELECT C.id_cita, P1.cedula, P1.nombre as paciente, P2.nombre as odontologo, C.fecha, C.hora, " +
                         "O.consultorio \n" +
                         "FROM Cita C, Odontologo O, Persona P1, Persona P2 \n" +
                         "WHERE P1.id_persona = C.id_paciente \n" +
                         "AND P2.id_persona = C.id_odontologo \n" +
                         "AND C.id_odontologo = O.consultorio \n";
            string sqlCedula = "P1.cedula = '" + cedula + "' \n";
            string sqlFecha = "C.fecha = '" + fecha.ToString("yyyy-MM-dd") + "' \n";
            string sqlHora = "C.hora = '" + hora + "' ";
            if (n == 1)
            {
                sentenciaSQL = sql + "AND " + sqlCedula;
            }
            else if (n == 2)
            {
                sentenciaSQL = sql + "AND " + sqlFecha;
            }
            else if (n == 3)
            {
                sentenciaSQL = sql + "AND " + sqlHora;
            }
            else if (n == 4)
            {
                sentenciaSQL = sql + "AND " + sqlCedula + "AND " + sqlHora;
            }
            else if (n == 5)
            {
                sentenciaSQL = sql + "AND " + sqlCedula + "AND " + sqlFecha;
            }
            else if (n == 6)
            {
                sentenciaSQL = sql + "AND " + sqlFecha + "AND " + sqlHora;
            }
            else if (n == 7)
            {
                sentenciaSQL = sql + "AND " + sqlCedula + "AND " + sqlFecha + "AND " + sqlHora;
            }
            /*if (hora == "--Seleccionar--" && cedula == "")
            {
                sentenciaSQL = sql + "AND " + sqlFecha;
            }
            else if (hora == "--Seleccionar--" && cedula != "")
            {
                sentenciaSQL = sql + "AND " + sqlFecha + "AND " + sqlCedula;
            }
            else if (hora != "--Seleccionar--" && cedula == "")
            {
                sentenciaSQL = sql + "AND " + sqlFecha + "AND " + sqlHora;
            }
            else if (hora != "--Seleccionar--" && cedula != "")
            {
                sentenciaSQL = sql + "AND " + sqlFecha + "AND " + sqlCedula + "AND " + sqlHora;
            }*/
            return Consultar(sentenciaSQL);
        }
    }
}
