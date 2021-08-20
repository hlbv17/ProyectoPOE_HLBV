using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosDiasHLBV
    {
        ConexionHLBV con = new ConexionHLBV();
        SqlCommand cmd = new SqlCommand();
        public Dias ConsultarDia()
        {

            Dias d = null;
            string sql = "Select * FROM Dias ";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        d = new Dias();
                        d.Id_dias = Convert.ToInt32(dr["id_dias"]);
                        d.Dia = dr["dia"].ToString();
                        d.HoraEntrada = Convert.ToDateTime(dr["hora_entrada"]);
                        d.HoraSalida = Convert.ToDateTime(dr["hora_salida"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla dias " + ex.Message);
                }
            }
            con.Cerrar();
            return d;
        }


        /*public bool ConsultarDias(string dia)
        {
            bool flag = true;
            string sql = "Select PE.id_persona, PE.cedula, PE.id_sexo, PE.nombre, PE.fecha_nacimiento, PA. discapacidad " +
                "FROM Persona PE " +
                "INNER JOIN Paciente PA ON PE.id_persona = PA.id_persona" +
                "WHERE PE.cedula = '" + dia + "'";
            SqlDataReader dr = null;
            Console.WriteLine(sql);
            string mensaje = "";
            mensaje = con.Conectar();
            if (mensaje[0] == '1')
            {
                try
                {
                    cmd.Connection = con.Cn;
                    cmd.CommandText = sql;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        flag = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla paciente " + ex.Message);
                    flag = false;
                }
            }
            con.Cerrar();
            return flag;
        }*/

    }
}
