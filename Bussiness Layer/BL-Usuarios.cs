using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class BL_Usuarios
    {
        public static Model_Layer.Result GetAll()
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using(Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"Usuario_GetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Model_Layer.Usuario user = new Model_Layer.Usuario();
                            user.IdUsuario = item.IdUsuario;
                            user.Nombres = item.Nombres;
                            user.Apellidos = item.Apellido;
                            user.NumeroEmpleado = (int)item.NumeroEmpleado;
                            user.Contraseña = item.Contrasena;

                            result.Objects.Add(user);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La consulta de los Usuarios se encuentra vacia / o no Esta Disponible";
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al realizar la consulta de Usuarios: " + ex.Message;
                result.exception = ex;
            }
            return result;
        }

        public static Model_Layer.Result GetById(int IdUsuario)
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"Usuario_GetById {IdUsuario}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        Model_Layer.Usuario user = new Model_Layer.Usuario();

                        user.IdUsuario = query.IdUsuario;
                        user.Nombres = query.Nombres;
                        user.Apellidos = query.Apellido;
                        user.NumeroEmpleado = (int)query.NumeroEmpleado;
                        user.Contraseña = query.Contrasena;

                        result.Object = user;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = $"Ocurrio un error al realizar la consulta del Usuario: {IdUsuario} " + ex.Message;
                result.exception = ex;
            }
            return result;
        }

        public static Model_Layer.Result Delete(int IdUsuario)
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"Delete_Usuario {IdUsuario}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = $"Ocurrio un error al Eliminar el Usuario: {IdUsuario} " + ex.Message;
                result.exception = ex;
            }
            return result;
        }

        public static Model_Layer.Result Update(Model_Layer.Usuario usuario)
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"Update_Usuario {usuario.IdUsuario},'{usuario.Nombres}','{usuario.Apellidos}', {usuario.NumeroEmpleado}, '{usuario.Contraseña}'");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = $"Ocurrio un error al realizar la Operacion Update del usuario {usuario.Nombres}: " + ex.Message;
                result.exception = ex;
            }
            return result;
        }

        public static Model_Layer.Result Insert(Model_Layer.Usuario usuario)
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"Insert_Usuario '{usuario.Nombres}','{usuario.Apellidos}', {usuario.NumeroEmpleado}, '{usuario.Contraseña}'");

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = $"Ocurrio un error al realizar la Operacion Insertar del usuario {usuario.Nombres}: " + ex.Message;
                result.exception = ex;
            }
            return result;
        }

    }
}
