using pruebaCrud2.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace pruebaCrud2.Datos
{
    public class Movimientos : Conexion
    {
        public void GuardarDepartamento(DepartamentoModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GuardarDepartamento", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
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
        public List<DepartamentoModel> ConsultarDepartamento()
        {
            List<DepartamentoModel> lista = new List<DepartamentoModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarDepartamento", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    DepartamentoModel modelo = new DepartamentoModel()
                    {
                        
                        Nombre = lector[0] + "",
                        Id = int.Parse(lector[1] + "")
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
        public bool ExisteUsuario(string correo)
        {
            // Aquí debes implementar la lógica para verificar si el usuario existe en la base de datos
            // Puedes utilizar consultas SQL u otros métodos de acceso a datos para realizar la verificación

            // Ejemplo de implementación utilizando consultas SQL con un SqlConnection y SqlCommand:

            Conectar();
            {// Consulta SQL para verificar si existe un usuario con el mismo correo
                string query = "SELECT COUNT(*) FROM usuarios WHERE correo = @correo";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    int count = (int)command.ExecuteScalar();

                    // Si count es mayor que 0, significa que ya existe un usuario con el mismo correo
                    return count > 0;
                }
            }
                
            
        }

        public List<string> ConsultarDepartamentos()
        {
            List<string> lista = new List<string>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarDepartamento", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    string nombreDepartamento = lector["nombre"].ToString();
                    lista.Add(nombreDepartamento);
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
        public string ObtenerUsuarioFirma(int usuarioId)
        {
            string usuarioFirma = string.Empty;
            Conectar();

            try
            {
                using (SqlCommand command = new SqlCommand("ObtenerUsuarioFirma", cnn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", usuarioId);

                    usuarioFirma = (string)command.ExecuteScalar();
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

            return usuarioFirma;
        }

        public List<UsuarioModel> ConsultarFirma()
        {
            List<UsuarioModel> lista = new List<UsuarioModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ObtenerUsuarioId", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioModel modelo = new UsuarioModel()
                    {

                        Firma = lector[0] + "",
                        
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



        public void GuardarUsuario(UsuarioModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GuardarUsuario", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@apellido", modelo.Apellido));
                comando.Parameters.Add(new SqlParameter("@correo", modelo.Correo));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Firma));
                comando.Parameters.Add(new SqlParameter("@telefono", modelo.Telefono));
                comando.Parameters.Add(new SqlParameter("@contrasena", modelo.Contraseña));
                comando.Parameters.Add(new SqlParameter("@departamento_nombre", modelo.DepartamentoNombre));
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
        public List<UsuarioModel> ConsultarUsuario()
        {
            List<UsuarioModel> lista = new List<UsuarioModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarUsuario", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioModel modelo = new UsuarioModel()
                    {
                        Id = int.Parse(lector[0] + ""),
                        Nombre = lector[1] + "",
                        Apellido = lector[2] + "",
                        Correo = lector[3] + "",
                        Telefono = int.Parse(lector[4] + ""),
                        DepartamentoNombre = lector[5] + ""
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
        public void GuardarSolicitud(RegistrarSolicitudModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GuardarSolicitud", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@proyecto", modelo.Proyecto));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_a_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_id", modelo.Usuario_id));
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
        public void AprobarSolicitud(SolicitudesAprobadas modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GuardarSolicitudAprobada", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@proyecto", modelo.Proyecto));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Usuario_firma));
                comando.Parameters.Add(new SqlParameter("@jefeDpto_firma", modelo.JefeDpto_firma));
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
        public void SolicitudEnProceso(SolicitudesProceso modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GuardarSolicitudProceso", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@proyecto", modelo.Proyecto));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Usuario_firma));
                comando.Parameters.Add(new SqlParameter("@jefeDpto_firma", modelo.jefeDpto_firma));
                comando.Parameters.Add(new SqlParameter("@administrador_firma", modelo.Administrador_firma));
                comando.Parameters.Add(new SqlParameter("@stock", modelo.Stock));
                comando.Parameters.Add(new SqlParameter("@estatus",modelo.Estatus));
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
        public void ActualizarSolicitudPendiente(SolicitudesProceso modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ActualizarSolicitudPendiente", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@folio", modelo.Folio));
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@proyecto", modelo.Proyecto));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Usuario_firma));
                comando.Parameters.Add(new SqlParameter("@jefeDpto_firma", modelo.jefeDpto_firma));
                comando.Parameters.Add(new SqlParameter("@administrador_firma", modelo.Administrador_firma));
                comando.Parameters.Add(new SqlParameter("@stock", modelo.Stock));
                comando.Parameters.Add(new SqlParameter("@estatus", modelo.Estatus));
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
        public void FinalizarSolicitudPendiente(SolicitudesProceso modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("FinalizarSolicitudPendiente", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@folio", modelo.Folio));
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@proyecto", modelo.Proyecto));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Usuario_firma));
                comando.Parameters.Add(new SqlParameter("@jefeDpto_firma", modelo.jefeDpto_firma));
                comando.Parameters.Add(new SqlParameter("@administrador_firma", modelo.Administrador_firma));
                comando.Parameters.Add(new SqlParameter("@stock", modelo.Stock));
                comando.Parameters.Add(new SqlParameter("@estatus", modelo.Estatus));
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
        public void AprobarSolicitudAdministrador(SolicitudesAprobadas modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("AprobacionJefeMantenimiento", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@folio", modelo.Folio));
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@proyecto", modelo.Proyecto));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Usuario_firma));
                comando.Parameters.Add(new SqlParameter("@jefeDpto_firma", modelo.JefeDpto_firma));
                comando.Parameters.Add(new SqlParameter("@administrador_firma", modelo.Administrador_firma));
                
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
        public void AprobarSolicitudAdministradorEstatusChanged(SolicitudesAprobadas modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("EstatusChanged", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@folio", modelo.Folio));
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@proyecto", modelo.Proyecto));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Usuario_firma));
                comando.Parameters.Add(new SqlParameter("@jefeDpto_firma", modelo.JefeDpto_firma));
                comando.Parameters.Add(new SqlParameter("@administrador_firma", modelo.Administrador_firma));
                comando.Parameters.Add(new SqlParameter("@estatus", modelo.Estatus));
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
        public void DeclinarSolicitud(SolicitudesDeclinadasModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GuardarSolicitudDeclinada", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@departamento", modelo.Departamento));
                comando.Parameters.Add(new SqlParameter("@area", modelo.Area));
                comando.Parameters.Add(new SqlParameter("@equipo", modelo.Equipo));
                comando.Parameters.Add(new SqlParameter("@actividad_realizar", modelo.ActividadARealizar));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", modelo.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fecha_final", modelo.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@sugerencias", modelo.Sugerencias));
                comando.Parameters.Add(new SqlParameter("@usuario_firma", modelo.Usuario_firma));
                comando.Parameters.Add(new SqlParameter("@administrador_firma", modelo.Administrador_firma));
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
        public List<RegistrarSolicitudModel> ConsultarSolicitud()
        {
            List<RegistrarSolicitudModel> lista = new List<RegistrarSolicitudModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitud", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    RegistrarSolicitudModel modelo = new RegistrarSolicitudModel()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Proyecto = lector[2]+"",
                        Departamento = lector[3] + "",
                        Area = lector[4] + "",
                        Equipo = lector[5] + "",
                        ActividadARealizar = lector[6] + "",
                        FechaInicio = DateTime.Parse(lector[7] + ""),
                        FechaFinal = DateTime.Parse(lector[8] + ""),
                        Sugerencias = lector[9] + "",
                        Usuario_id = int.Parse(lector[10] + "")

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
        public List<SolicitudesAprobadas> ConsultarSolicitudAprobadaJefeDpto()
        {
            List<SolicitudesAprobadas> lista = new List<SolicitudesAprobadas>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitudAprobadaJefeDpto", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    SolicitudesAprobadas modelo = new SolicitudesAprobadas()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Proyecto = lector[2] + "",
                        Departamento = lector[3] + "",
                        Area = lector[4] + "",
                        Equipo = lector[5] + "",
                        ActividadARealizar = lector[6] + "",
                        FechaInicio = DateTime.Parse(lector[7] + ""),
                        FechaFinal = DateTime.Parse(lector[8] + ""),
                        Sugerencias = lector[9] + "",
                        Usuario_firma = lector[10] + "",
                        JefeDpto_firma = lector[11]+"",
                        Estatus = lector[12] + ""

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
        public List<SolicitudesAprobadas> ConsultarSolicitudAprobadaAdministrador()
        {
            List<SolicitudesAprobadas> lista = new List<SolicitudesAprobadas>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitudAprobadaAdministrador", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    SolicitudesAprobadas modelo = new SolicitudesAprobadas()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Proyecto = lector[2] + "",
                        Departamento = lector[3] + "",
                        Area = lector[4] + "",
                        Equipo = lector[5] + "",
                        ActividadARealizar = lector[6] + "",
                        FechaInicio = DateTime.Parse(lector[7] + ""),
                        FechaFinal = DateTime.Parse(lector[8] + ""),
                        Sugerencias = lector[9] + "",
                        Usuario_firma = lector[10] + "",
                        JefeDpto_firma = lector[11] + "",
                        Administrador_firma = lector[12] +""

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
        public List<SolicitudesAprobadas> ConsultarSolicitudAprobada()
        {
            List<SolicitudesAprobadas> lista = new List<SolicitudesAprobadas>();
            Conectar();
            try 
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitudesAprobadas", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    SolicitudesAprobadas modelo = new SolicitudesAprobadas()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Departamento = lector[2] + "",
                        Area = lector[3] + "",
                        Equipo = lector[4] + "",
                        ActividadARealizar = lector[5] + "",
                        FechaInicio = DateTime.Parse(lector[6] + ""),
                        FechaFinal = DateTime.Parse(lector[7] + ""),
                        Sugerencias = lector[8] + "",
                        Usuario_firma= lector[9] + "",
                        Administrador_firma = lector[10] + ""
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
        public List<SolicitudesProceso> ConsultarSolicitudEnProceso()
        {
            List<SolicitudesProceso> lista = new List<SolicitudesProceso>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitudEnProceso", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    SolicitudesProceso modelo = new SolicitudesProceso()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Proyecto = lector[2] + "",
                        Departamento = lector[3] + "",
                        Area = lector[4] + "",
                        Equipo = lector[5] + "",
                        ActividadARealizar = lector[6] + "",
                        FechaInicio = DateTime.Parse(lector[7] + ""),
                        FechaFinal = DateTime.Parse(lector[8] + ""),
                        Sugerencias = lector[9] + "",
                        Usuario_firma = lector[10] + "",
                        jefeDpto_firma = lector[11]+ "",
                        Administrador_firma = lector[12] + "",
                        Stock = lector[13] +" ",
                        Estatus = lector[14] + " ",
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
        public List<SolicitudesProceso> ConsultarSolicitudPendiente()
        {
            List<SolicitudesProceso> lista = new List<SolicitudesProceso>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitudPendiente", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    SolicitudesProceso modelo = new SolicitudesProceso()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Proyecto = lector[2] + "",
                        Departamento = lector[3] + "",
                        Area = lector[4] + "",
                        Equipo = lector[5] + "",
                        ActividadARealizar = lector[6] + "",
                        FechaInicio = DateTime.Parse(lector[7] + ""),
                        FechaFinal = DateTime.Parse(lector[8] + ""),
                        Sugerencias = lector[9] + "",
                        Usuario_firma = lector[10] + "",
                        jefeDpto_firma = lector[11] + "",
                        Administrador_firma = lector[12] + "",
                        Stock = lector[13] + " ",
                        Estatus = lector[14] + " ",
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
        public List<SolicitudesProceso> ConsultarSolicitudFinalizada()
        {
            List<SolicitudesProceso> lista = new List<SolicitudesProceso>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitudFinalizada", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    SolicitudesProceso modelo = new SolicitudesProceso()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Proyecto = lector[2] + "",
                        Departamento = lector[3] + "",
                        Area = lector[4] + "",
                        Equipo = lector[5] + "",
                        ActividadARealizar = lector[6] + "",
                        FechaInicio = DateTime.Parse(lector[7] + ""),
                        FechaFinal = DateTime.Parse(lector[8] + ""),
                        Sugerencias = lector[9] + "",
                        Usuario_firma = lector[10] + "",
                        jefeDpto_firma = lector[11] + "",
                        Administrador_firma = lector[12] + "",
                        Stock = lector[13] + " ",
                        Estatus = lector[14] + " ",
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
        public List<SolicitudesDeclinadasModel> ConsultarSolicitudDeclinada()
        {
            List<SolicitudesDeclinadasModel> lista = new List<SolicitudesDeclinadasModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarSolicitudDeclinada", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    SolicitudesDeclinadasModel modelo = new SolicitudesDeclinadasModel()
                    {
                        Folio = int.Parse(lector[0] + ""),
                        Fecha = DateTime.Parse(lector[1] + ""),
                        Departamento = lector[2] + "",
                        Area = lector[3] + "",
                        Equipo = lector[4] + "",
                        ActividadARealizar = lector[5] + "",
                        FechaInicio = DateTime.Parse(lector[6] + ""),
                        FechaFinal = DateTime.Parse(lector[7] + ""),
                        Sugerencias = lector[8] + "",
                        Usuario_firma = lector[9] + "",
                        Administrador_firma = lector[10] + ""
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
        public void EliminarSolicitud(RegistrarSolicitudModel modelo)
        {
            Conectar();
            {
                SqlCommand comando = new SqlCommand("EliminarSolicitud", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Folio", SqlDbType.Int).Value = modelo.Folio;

                try
                {

                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se encontró la solicitud para eliminar.");
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
    }
}