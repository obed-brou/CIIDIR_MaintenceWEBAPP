using pruebaCrud2.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace pruebaCrud2.Datos
{
    public class PersonaAdmin : Conexion
    {
        public void Guardar(PersonaModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@apellido", modelo.Apellido));
                comando.Parameters.Add(new SqlParameter("@edad", modelo.Edad));
                comando.ExecuteNonQuery();
                comando.Dispose();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }
        public void Actualizar(PersonaModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Actualizar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id", modelo.Id));
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@apellido", modelo.Apellido));
                comando.Parameters.Add(new SqlParameter("@edad", modelo.Edad));
                comando.ExecuteNonQuery();
                comando.Dispose();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void EliminarPersona(PersonaModel modelo)
        {
            Conectar();
            {
                SqlCommand comando = new SqlCommand("EliminarPersona", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = modelo.Id;

                try
                {
                    
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se encontró la persona para eliminar.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    
                }
                finally
                {
                    Desconectar();
                }
            }
        }
        public List<PersonaModel> Consultar() 
        {
            List<PersonaModel> lista = new List<PersonaModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Consultar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    PersonaModel modelo = new PersonaModel()
                    {
                        Id= int.Parse(lector[0]+""),
                        Nombre = lector[1]+"",
                        Apellido = lector[2]+"",
                        Edad = int.Parse(lector[3]+""),
                    };
                    lista.Add(modelo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return lista;
        }
    }
}