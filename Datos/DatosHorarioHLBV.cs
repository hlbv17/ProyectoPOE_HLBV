using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosHorarioHLBV
    {
        ConexionHLBV con = new ConexionHLBV();
        SqlCommand cmd = new SqlCommand();
        
        public Horario ConsultarHorario()
        {

            Horario h = null;
            string sql = "Select * FROM Horario ";
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
                        h = new Horario();
                        h.Id_horario = Convert.ToInt32(dr["id_horario"]);
                        h.Nombre_horario = dr["nombre_horario"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al consultar en la tabla dias " + ex.Message);
                }
            }
            con.Cerrar();
            return h;
        }

    }
}
