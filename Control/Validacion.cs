using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    class Validacion
    {
        internal int AEntero(string entrada)
        {
            int x = 0;
            try
            {
                x = Convert.ToInt32(entrada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error: Se esperaba un número entero");
            }
            return x;
        }


        internal bool EsReal(string monto)
        {
            double x = 0.0;
            bool bandera = true;
            try
            {
                x = Convert.ToDouble(monto);
                bandera = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error: Se esperaba un número entero");
                bandera = false;
            }
            return bandera;
        }

        internal double AReal(string monto)
        {
            double x = 0.0;
            try
            {
                x = Convert.ToDouble(monto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error: Se esperaba un número entero");
            }
            return x;
        }
    }
}
