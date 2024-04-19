using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class BL_Tareas
    {
        public static Model_Layer.Result GetAll()
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Tareas.FromSqlRaw($"Get_TareasAll").ToList();

                    result.Objects = new List<Object>();

                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            Model_Layer.Tareas task = new Model_Layer.Tareas();
                            task.Cat_Estatus = new Model_Layer.Cat_Estatus();
                            task.Usuario = new Model_Layer.Usuario();

                            task.IdTarea = item.IdTarea;
                            task.Cat_Estatus.IdEstatus = (int)item.IdEstatus;
                            task.Cat_Estatus.Nombre_Estatus = item.NombreEstatos;
                            task.Descripcion = item.Descripcion;
                            task.Usuario.IdUsuario = (int)item.IdUsuario;
                            task.Usuario.Nombres = item.Nombres;
                            task.Usuario.Apellidos = item.Apellido;

                            result.Objects.Add(task);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al realizar la consulta de tareas: " + ex;
                result.exception = ex;
            }
            return result;
        }

        public static Model_Layer.Result GetById(int IdTarea)
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Tareas.FromSqlRaw($"Get_TareasById {IdTarea}").AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        Model_Layer.Tareas task = new Model_Layer.Tareas();
                        task.Cat_Estatus = new Model_Layer.Cat_Estatus();
                        task.Usuario = new Model_Layer.Usuario();

                        task.IdTarea = query.IdTarea;
                        task.Cat_Estatus.IdEstatus = (int)query.IdEstatus;
                        task.Cat_Estatus.Nombre_Estatus = query.NombreEstatos;
                        task.Descripcion = query.Descripcion;
                        task.Usuario.IdUsuario = (int)query.IdUsuario;
                        task.Usuario.Nombres = query.Nombres;
                        task.Usuario.Apellidos = query.Apellido;

                        result.Object = task;
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
                result.ErrorMessage = $"Ocurrio un errorl al buscar la tarea: {IdTarea}  " + ex;
                result.exception = ex;
            }
            return result;
        }

        public static Model_Layer.Result Insert(Model_Layer.Tareas tarea)
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"Insert_Tareas {tarea.Cat_Estatus.IdEstatus}, '{tarea.Descripcion}', {tarea.Usuario.IdUsuario}");
                    
                    if(query > 0 )
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
                result.ErrorMessage = "Ocurrio un error al realizar el registro de la tarea: " + ex;
                result.exception = ex;
            }
            return result;
        }

        public static Model_Layer.Result Update(Model_Layer.Tareas tarea)
        {
            Model_Layer.Result result = new Model_Layer.Result();
            try
            {
                using (Data_Layer.Models.TaskProyectContext context = new Data_Layer.Models.TaskProyectContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"Update_Tarea {tarea.IdTarea},{tarea.Cat_Estatus.IdEstatus}, '{tarea.Descripcion}', {tarea.Usuario.IdUsuario}");

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
                result.ErrorMessage = "";
                result.exception = ex;
            }
            return result;
        }
    }
}
