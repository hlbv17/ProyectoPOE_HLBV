using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    class DatosPersonaHLBV
    {

        ConexionHLBV con = new ConexionHLBV();
        SqlCommand cmd = new SqlCommand();
        /*public Persona ConsultarPersonaNombre(string cedula)
        {

            Persona pe = null;
            string sql = "Select nombre from Paciente PA, Persona PE " +
                "where PE.cedula = '" + cedula + "' AND PE.id_persona = PA.id_persona";
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
                        pe = new Persona();
                        pe.Nombre = dr["nombre"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla paciente " + ex.Message);
                }
            }
            con.Cerrar();
            return nombre;
        }

        public bool ConsultarPacienteCedula(string cedula)
        {
            bool flag = true;
            string sql = "Select nombre from Paciente PA, Persona PE " +
                "where PE.cedula = '" + cedula + "' AND PE.id_persona = PA.id_persona";
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
        }
    }*/
}
}
