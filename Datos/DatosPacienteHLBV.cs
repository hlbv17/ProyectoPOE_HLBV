using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosPacienteHLBV
    {
        ConexionHLBV con = new ConexionHLBV();
        SqlCommand cmd = new SqlCommand();
        public Paciente ConsultarPacienteNombre(string cedula)
        {
            
            Paciente p = null;
            string sql = "Select PE.id_persona, PE.cedula, PE.id_sexo, PE.nombre, PE.fecha_nacimiento, PA. discapacidad \n" +
                "FROM Persona PE \n" +
                "INNER JOIN Paciente PA ON PE.id_persona = PA.id_persona \n"+
                "WHERE PE.cedula = '" + cedula + "'";
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
                        p = new Paciente();
                        p.Id_persona = Convert.ToInt32(dr["id_persona"]);
                        p.Cedula = dr["cedula"].ToString();
                        p.Sexo = Convert.ToChar(dr["id_sexo"]);
                        p.Nombre = dr["nombre"].ToString();
                        p.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
                        p.Discapacidad = dr["discapacidad"].ToString();
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla paciente " + ex.Message);
                }
            }
            con.Cerrar();
            return p;
        }

        public bool ConsultarPacienteCedula(string cedula)
        {
            bool flag = true;
            string sql = "Select PE.id_persona, PE.cedula, PE.id_sexo, PE.nombre, PE.fecha_nacimiento, PA. discapacidad " +
                "FROM Persona PE " +
                "INNER JOIN Paciente PA ON PE.id_persona = PA.id_persona" +
                "WHERE PE.cedula = '" + cedula + "'";
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
    }
}
