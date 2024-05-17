using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace pruebaCrud2.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;

        protected void Conectar()
        {
            try
            {
                cnn= new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\obedr\\source\\repos\\pruebaCrud2\\pruebaCrud2\\App_Data\\basededatos.mdf;Integrated Security=True");
                cnn.Open(); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        protected void Desconectar()
        {
            try
            {
                cnn.Close();
                cnn.Dispose();  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}